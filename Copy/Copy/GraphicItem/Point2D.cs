using System;

namespace Copy.GraphicItem
{
    public class Point2D : ICloneable
    {
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int  X { get; set; }

        public int Y { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}