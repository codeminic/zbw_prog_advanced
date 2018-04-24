using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace SqlBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // read file from args[0]
            var content = File.ReadAllText(args[0]);

            // first line is connection string
            var connectionString = content.Substring(0, content.IndexOf(Environment.NewLine, StringComparison.Ordinal));

            // the following contents are statement, teminated with a semicolon
            var statements = content.Substring(content.IndexOf(Environment.NewLine, StringComparison.Ordinal))
                .Replace(Environment.NewLine, " ")
                .Split(';')
                .Select(s => s.Trim())
                .Where(s => s.Length > 0);

            using (var connection = new OleDbConnection { ConnectionString = connectionString })
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine($"Opening database with connection: {connectionString}");
                connection.Open();
                OleDbTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                try
                {
                    foreach (var statement in statements)
                    {
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine(statement);
                        Console.WriteLine("----------------------------------------------------");
                        var command = connection.CreateCommand();
                        command.CommandText = statement + ";";
                        command.Transaction = transaction;

                        if (statement.ToLower().StartsWith("select"))
                            ExecuteQuery(command);
                        else
                            ExecuteNonQuery(command);

                    }
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("Commit");
                    Console.WriteLine("----------------------------------------------------");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine($"Error: {ex}");
                    transaction.Rollback();
                    Console.WriteLine("Rollback");
                    Console.WriteLine("----------------------------------------------------");
                }
            }

            Console.ReadKey();
        }

        private static void ExecuteNonQuery(IDbCommand command)
        {
            var affectedRows = command.ExecuteNonQuery();
            Console.WriteLine($"Affected rows: {affectedRows}");
        }

        private static void ExecuteQuery(IDbCommand command)
        {
            var reader = command.ExecuteReader();
            var row = new object[reader.FieldCount];

            while (reader.Read())
            {
                int columnCount = reader.GetValues(row);
                for (var i = 0; i < columnCount; i++)
                    Console.Write($"{row[i]}\t|");
                Console.WriteLine();
            }
        }
    }
}
