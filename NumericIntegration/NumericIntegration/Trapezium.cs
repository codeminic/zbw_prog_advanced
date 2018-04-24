namespace NumericIntegration
{
    public class Trapezium
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _height;

        public Trapezium(double a, double b, double height)
        {
            _a = a;
            _b = b;
            _height = height;
        }

        public double Area()
        {
            return (_a + _b) / 2 * _height;
        }
    }
}