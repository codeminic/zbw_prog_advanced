using System;

namespace NumericIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            var steps = Convert.ToInt32(args[0]);
            var distance = Integrator.Integrate(d => d, steps);
            Console.WriteLine($"Distance: {distance}");
            Console.ReadKey();
        }
    }
}
