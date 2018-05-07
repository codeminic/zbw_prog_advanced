using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector
    {
        private readonly IDictionary<int, double> _coefficients;

        public Vector(double x, double y, double z)
        {
            _coefficients = new Dictionary<int, double> {{0, x}, {1, y}, {2, z}};
        }

        public double this[int i]
        {
            get
            {
                if (_coefficients.ContainsKey(i))
                    return _coefficients[i];

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (_coefficients.ContainsKey(i))
                    _coefficients[i] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
        
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a._coefficients[0] + b._coefficients[0], 
                a._coefficients[1] + b._coefficients[1],
                a._coefficients[2] + b._coefficients[2]);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a._coefficients[0] - b._coefficients[0],
                a._coefficients[1] - b._coefficients[1],
                a._coefficients[2] - b._coefficients[2]);
        }

        /// <summary>
        /// Calculates the cross product of <param name="a"></param> and <param name="b"></param>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a._coefficients[1] * b._coefficients[2] - a._coefficients[2] * b._coefficients[1],
                a._coefficients[2] * b._coefficients[0] - a._coefficients[0] * b._coefficients[2],
                a._coefficients[0] * b._coefficients[1] - a._coefficients[1] * b._coefficients[1]);
        }

        /// <summary>
        /// Returns a vector where each of the component parts is multiplied by the scalar value <param name="b"></param>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a._coefficients[0] * b,
                a._coefficients[1] * b,
                a._coefficients[2] * b);
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return a._coefficients[0] == b._coefficients[0] &&
                   a._coefficients[1] == b._coefficients[1] &&
                   a._coefficients[2] == b._coefficients[2];
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        public bool Equals(Vector other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Vector)obj);
        }

        public override int GetHashCode()
        {
            return _coefficients.GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"x: {_coefficients[0]}");
            sb.AppendLine($"y: {_coefficients[1]}");
            sb.AppendLine($"z: {_coefficients[2]}");
            return sb.ToString();
        }

        public double Magnitude => Math.Sqrt(
            Math.Pow(_coefficients[0], 2) +
            Math.Pow(_coefficients[1], 2) +
            Math.Pow(_coefficients[2], 2));

        public static explicit operator double(Vector value)
        {
            return value.Magnitude;
        }

        public static implicit operator Vector(double value)
        {
            return new Vector(value, 0, 0);
        }
    }
}