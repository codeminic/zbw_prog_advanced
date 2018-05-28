using System.Drawing;

namespace Copy.GraphicItem
{
    public class Circle : IShape
    {
        private readonly int _radius;

        public Circle(Point2D center, int radius, Color color)
        {
            Location = center;
            _radius = radius;
            AreaColor = color;
        }

        public int Radius => Radius;

        public Color AreaColor { get; set; }

        public Point2D Location { get; }

        public IGraphicItem CopyShallow()
        {
            return (IGraphicItem)this.MemberwiseClone();
        }

        public IGraphicItem CopyDeep()
        {
            var locationCopy = (Point2D) Location.Clone();

            return new Circle(locationCopy, Radius, AreaColor);
        }
    }
}