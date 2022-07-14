using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class PrimeOperationsKata
    {
        public static int PrimeOperations(long x, long y)
        {
            if (x == y)
                return 0;
            long factor;
            List<long> xFactors = new List<long>();
            List<long> yFactors = new List<long>();
            while ((factor = PrimeCheck(x)) != -1)
            {
                x /= factor;
                xFactors.Add(factor);
            }
            if (x != 1)
                xFactors.Add(x);
            while ((factor = PrimeCheck(y)) != -1)
            {
                y /= factor;
                if (xFactors.Contains(factor))
                    xFactors.Remove(factor);
                else
                    yFactors.Add(factor);
            }
            if (y != 1)
                if (xFactors.Contains(y))
                    xFactors.Remove(y);
                else
                    yFactors.Add(y);
            return xFactors.Count + yFactors.Count;
        }

        static long PrimeCheck(long x)
        {
            if (x == 2)
                return -1;
            if (x % 2 == 0)
                return 2;
            for (long i = 3; i < Math.Sqrt(x) + 1; i += 2)
            {
                if (x % i == 0)
                    return i;
            }
            return -1;
        }
    }
}
