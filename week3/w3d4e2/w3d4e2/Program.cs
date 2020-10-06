using System;
using System.Collections.Generic;

namespace w3d4e2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var factorialNumbers = new List<int>;

            Console.WriteLine(Factorial(0));
            Console.WriteLine(Factorial(1));
            Console.WriteLine(Factorial(3));
            Console.WriteLine(Factorial(4));
            Console.WriteLine(Factorial(5));
            Console.WriteLine(Factorial(6));
            
        }

        static int Factorial2(int n)
        {
            int startingValue = 1;
            for (int i = 0; i < n + 1; i++)
            {
                if (i == 0)
                {
                    startingValue = 1 * startingValue;
                }
                else
                {
                    startingValue = startingValue * i;
                }
            }
            return startingValue;
        }

        // 1. if n is 0, return 1
        // 2. otherwise, return [n × factorial(n - 1)]

        static int Factorial(int n)
        {
            return n == 0 ? 1 : n * Factorial(n - 1);
        }

        /*
         for (int i = 0; i < n; i++)
                int startingvalue = 1;
        {
                    if (i == 0)
                    {
                        startinValue = 1 * startinValue;
                    }
                    else
                    {
                        startinValue = startinValue * i;
                    }
        */

        static void printNumbers()
        {
            int startinValue = 1;

            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    startinValue = 1 * startinValue;
                }
                else
                {
                    startinValue = startinValue * i;
                }
                Console.WriteLine("I = " + i);
                Console.WriteLine("Factorial = " + startinValue);

            }

            static void printNumbers()
            {
                int startinValue = 1;

                for (int i = 0; i < 11; i++)
                {
                    if (i == 0)
                    {
                        startinValue = 1 * startinValue;
                    }
                    else
                    {
                        startinValue = startinValue * i;
                    }
                    Console.WriteLine("I = " + i);
                    Console.WriteLine("Factorial = " + startinValue);

                }

                //return returnNumber;
                /*
                             *n! = n * (n - 1)!
                             *
                0! = 1
                1! = 1
                2! = 2
                3! = 6
                4! = 24
                5! = 120
                6! = 720
                7! = 5040
                8! = 40320
                9! = 362880
                10! = 3628800*/
            }
        }
    }

}
