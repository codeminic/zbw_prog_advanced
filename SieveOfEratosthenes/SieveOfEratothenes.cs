using System.Collections.Generic;
using System.Linq;

namespace SieveOfEratosthenes
{
    public static class SieveOfEratothenes
    {
        private const int FirstPossiblePrimeNumber = 2;

        public static IEnumerable<int> GetPrimeNumbers(int upperLimit)
        {
            upperLimit = upperLimit - FirstPossiblePrimeNumber;
            var numbersToCheck = new PrimalNumber[upperLimit];
            for (var i = 0; i < upperLimit; i++)
                numbersToCheck[i] = new PrimalNumber(i, true);

            var divisors = numbersToCheck.Where(p => p.Number > 1).Select(p => p.Number);

            for (var i = 0; i < upperLimit; i++)
            {
                var numberToCheck = numbersToCheck[i];
                if (!numberToCheck.IsPrime )
                    continue;

                foreach (var divisor in divisors)
                {
                    if (divisor == numberToCheck.Number || divisor > numberToCheck.Number)
                        continue;

                    if (numberToCheck.Number % divisor == 0)
                        numberToCheck.IsPrime = false;
                }
            }

            return numbersToCheck.Where(n => n.IsPrime).Select(n => n.Number);
        }
    }
}