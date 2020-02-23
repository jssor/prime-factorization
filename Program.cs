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
        /// 134109847012397401
        /// 123523465345764537
        /// 617617326728822689
        /// 134103495123459132
        /// 131249812354125335
        /// 134009870193402141
        /// 098697845487658768
        /// 987587649869797045
        /// 901823410293481324
        /// 998234023490870907
        /// 986986713040981024
        /// 907812341043204713
        /// 919238471293412342
        /// 
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

            if (number < 4)
            {
                list.Add(number);
            }
            else if ((number & 1) == 0)
            {
                list.Add(2);
                list.AddRange(Factorize(number / 2));
            }
            else
            {
                long x = (long)Math.Sqrt(number);
                long y = x;
                long remainder = number - x * y;

                if (remainder < 0)
                {
                    y--;
                    x--;
                    remainder = 2 * x;
                }
                
                x += remainder / y;
                remainder = remainder % y;

                while (remainder > 0 && y > 3)
                {
                    y--;
                    remainder += x;

                    x += remainder / y;
                    remainder = remainder % y;
                }

                if (remainder > 0)
                {
                    list.Add(number);
                }
                else
                {
                    list.AddRange(Factorize(y));
                    list.AddRange(Factorize(number / y));
                }
            }

            return list;
        }
    }
}