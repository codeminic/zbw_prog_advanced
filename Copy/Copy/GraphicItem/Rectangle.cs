using System.Drawing;

namespace Copy.GraphicItem
{
    public class Rectangle : IShape
    {
        private readonly int _width;
        private readonly int _height;

        public Rectangle(Point2D corner, int width, int height, Color color)
        {
            Location = corner;
            _width = width;
            _height = height;
            AreaColor = color;
        }

        public Color AreaColor { get; set; }

        public Point2D Location { get; }

        public IGraphicItem CopyShallow()
        {
            return (IGraphicItem) this.MemberwiseClone();
        }

        public IGraphicItem CopyDeep()
        {
            var locationCopy = (Point2D) Location.Clone();

            return new Rectangle(locationCopy, _width, _height, AreaColor);
        }
    }
}