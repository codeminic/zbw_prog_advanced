using System;
using System.Diagnostics;
using System.Linq;

namespace SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var primalNumbers = SieveOfEratothenes.GetPrimeNumbers(10000).ToArray();
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

            for (var i = 0; i < primalNumbers.Length; i++)
            {
                var primalNumber = primalNumbers[i];
                if (i % 10 == 0)
                    Console.Write(Environment.NewLine);

                Console.Write($"  {primalNumber}\t|");
            }

            Console.ReadKey();
        }
    }
}
