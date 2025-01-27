using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOP_PRIMES.Models
{
    public class PrimeChecker
    {
        public static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            if (number == 2 || number == 3)
                return true;

            if (number % 2 == 0)
                return false;

            int sqrt = (int)Math.Sqrt(number);

            for (int i = 3; i <= sqrt; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}



