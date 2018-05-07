using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = Convert.ToDouble(args[0]);
            var y1 = Convert.ToDouble(args[1]);
            var z1 = Convert.ToDouble(args[2]);

            var x2 = Convert.ToDouble(args[3]);
            var y2 = Convert.ToDouble(args[4]);
            var z2 = Convert.ToDouble(args[5]);

            var vector1 = new Vector(x1, y1, z1);
            var vector2 = new Vector(x2, y2, z2);
            Console.WriteLine("Vector 1");
            Console.Write(vector1.ToString());
            Console.WriteLine($"magnitude: {Math.Round(vector1.Magnitude, 3)}");

            Console.WriteLine("Vector 2");
            Console.Write(vector2.ToString());
            Console.WriteLine($"magnitude: {Math.Round(vector2.Magnitude, 3)}");
            
            Console.WriteLine("Vector 1 + Vector 2");
            Console.Write((vector1 + vector2).ToString());

            Console.WriteLine("Vector 1 - Vector 2");
            Console.Write((vector1 - vector2).ToString());

            Console.WriteLine("Vector 1 * Vector 2 (cross product)");
            Console.Write((vector1 - vector2).ToString());

            Console.ReadKey();
        }
    }
}
