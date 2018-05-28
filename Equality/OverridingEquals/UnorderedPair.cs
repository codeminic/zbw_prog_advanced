namespace OverridingEquals
{
    public class UnorderedPair : IPair
    {
        public UnorderedPair(int i, int i1)
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
            if (ReferenceEquals(this, obj)) return true;

            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return (First is null ? 0 : First.GetHashCode() ) ^ (Second is null ? 0 : Second.GetHashCode());}
    }
}