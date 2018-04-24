namespace SieveOfEratosthenes
{
    public class PrimalNumber
    {
        public PrimalNumber(int number, bool isPrime)
        {
            Number = number;
            IsPrime = isPrime;
        }

        public int Number { get; }

        public bool IsPrime { get; set; }
    }
}