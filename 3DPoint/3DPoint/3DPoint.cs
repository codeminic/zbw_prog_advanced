using System;

namespace _3DPoint
{
    class _3DPoint
    {
        public _3DPoint(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return X;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public static _3DPoint operator +(_3DPoint a , _3DPoint b)
        {
            return new _3DPoint(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
    }
}
