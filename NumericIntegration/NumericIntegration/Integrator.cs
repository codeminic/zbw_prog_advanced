using System;

namespace NumericIntegration
{
    public class Integrator
    {
        public static double Integrate(Func<double, double> function, int amountOfSteps)
        {
            double distance = 0;

            for (var i = 0; i < amountOfSteps - 1; i++)
            {
                var a = function(i);
                var b = function(i + 1);
                var area = new Trapezium(a, b, 1).Area();
                distance += area;
            }

            return distance;    
        }
    }
}