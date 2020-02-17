/*
* author: jssor
*/

using System;
using System.Collections.Generic;

namespace PrimeFactorisation
{
    class Program
    {
        /// <summary>
        /// example numbers
        /// 288230376151711743 (2^58-1)
        /// 576460752303423487 (2^59-1)
        /// 1152921504606846975 (2^60-1)
        /// 2305843009213693951 (2^61-1)
        /// 4611686018427387903 (2^62-1)
        /// 9223372036854775807 (2^63-1)
        /// </summary>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input Number: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || input.ToLower() == "exit" || input.ToLower() == "quit")
                {
                    break;
                }

                long number = 0;

                try
                {
                    number = long.Parse(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                    continue;
                }

                DateTime beforeFactorize = DateTime.Now;

                List<long> list = Factorize(number);

                DateTime afterFactorize = DateTime.Now;
                Console.WriteLine(string.Format("Time Elapsed: {0}", afterFactorize - beforeFactorize));

                if (list.Count == 1)
                {
                    Console.WriteLine("Prime Number");
                }
                else
                {
                    list.Sort();
                    Console.WriteLine(string.Join(" * ", list));
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prime Factorization (2d space hit algorithm)
        /// </summary>
        private static List<long> Factorize(long number)
        {
            List<long> list = new List<long>();

            double sqrt = Math.Sqrt(number);
            long x = (long)sqrt;
            long y = x;

            if(y > 1)
            {
                long remainder = number - x * y;

                while (remainder != 0)
                {
                    y--;

                    remainder += x;
                    long mode = remainder % y;
                    x += remainder / y;
                    remainder = mode;
                }
            }

            if (y == 1)
            {
                list.Add(number);
            }
            else
            {
                list.AddRange(Factorize(x));
                list.AddRange(Factorize(y));
            }

            return list;
        }
    }
}