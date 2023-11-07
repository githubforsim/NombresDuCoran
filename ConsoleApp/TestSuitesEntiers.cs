using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class TestSuitesEntiers
    {
        // *** PUBLIC ********************************

        public static bool Test(int[] suite, int[] nbCaractéristiques)
        {
            Console.WriteLine("Test la suite : " + SuiteAsString(suite));

            if (true == TestSommesAsPrimeNumber(suite))
            {
                return true;
            }
            if (true == TestSommesAsNombresCaractéristique(suite, nbCaractéristiques))
            {
                return true;
            }

            return false;
        }

        // *** RESTRICTED ****************************

        private static bool TestSommesAsPrimeNumber(int[] suite)
        {
            BigInteger S = 0;
            for (int p = 1; p <= 4; p++)
            {
                for (int i = 0; i < suite.Length; i++)
                {
                    S += Puissance(suite[i], p);
                }

                if (IsPremier(S, out BigInteger diviseur))
                {
                    Console.WriteLine($"La puissance {p} est première");
                }
                else
                {
                    Console.WriteLine($"La puissance {p} n'est pas première");
                    return false;
                }
            }

            return true;
        }

        private static bool TestSommesAsNombresCaractéristique(int[] suite, int[] nbCaractéristiques)
        {
            BigInteger S = 0;
            for (int i = 0; i < suite.Length; i++)
            {
                S += suite[i];
            }

            foreach(int nb in nbCaractéristiques)
            {
                if (S == nb)
                {
                    Console.WriteLine($"S == {nb}");
                    return true;
                }
            }
            Console.WriteLine($"S == {S} != tous les nb caractéristiques");

            return false;
        }

        private static string SuiteAsString(int[] suite)
        {
            string output = string.Empty;
            bool isFirst = true;
            foreach (int i in suite) 
            {
                if (false == isFirst)
                {
                    output += " ; ";
                }
                output += i;
                isFirst = false;
            }

            return output;
        }

        private static bool IsPremier(BigInteger n, out BigInteger diviseur)
        {
            diviseur = 0;

            if (n % 2 == 0)
            {
                diviseur = 2;
                return (n == 2);
            }
            for (BigInteger d = 3; d * d <= n; d = d + 2)
            {
                if (n % d == 0)
                {
                    diviseur = d;
                    return false;
                }
            }

            return true;
        }

        private static BigInteger Puissance(int entier, int puissance)
        {
            if (puissance == 0)
            {
                return 1;
            }
            else if (puissance == 1) 
            {
                return entier;
            }

            BigInteger p = entier;
            for(int i = 2; i <= puissance; i++) 
            {
                p *= entier;
            }

            return p;
        }
    }
}
