using System;
using System.Data.OleDb;
using System.IO;

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
            var statements = content.Substring(content.IndexOf(Environment.NewLine, StringComparison.Ordinal)).Trim().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            using (var connection = new OleDbConnection { ConnectionString = connectionString })
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine($"Opening database with connection: {connectionString}");
                connection.Open();

                foreach (var statement in statements)
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine(statement);
                    Console.WriteLine("----------------------------------------------------");
                    var command = new OleDbCommand(statement + ";") {Connection = connection};
                    var reader = command.ExecuteReader();
                    var row = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        int cols = reader.GetValues(row);
                        for (var i = 0; i < cols; i++)
                            Console.Write($"{row[i]}\t|");
                        Console.WriteLine();
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
