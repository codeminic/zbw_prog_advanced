using System;

namespace OverridingEquals
{
    public class OrderedPair : IPair
    {
        public OrderedPair(int i, int i1)
        {
            First = i;
            Second = i1;
        }

        public object First { get; set; }
        public object Second { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != GetType()) return false;

            return Equals((OrderedPair) obj);
        }

        private bool Equals(OrderedPair other)
        {
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public override int GetHashCode()
        {
            const int hashSeed = 7;
            const int hashMultiplier = 13;

            var hash = hashSeed;
            hash = (hash * hashMultiplier) ^ First.GetHashCode();
            hash = (hash * hashMultiplier) ^ Second.GetHashCode();

            return hash;
        }
    }
}