using System;

namespace w5d3m2
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0;

            while (i <= 22)
            {
                Console.Write(i + " = " + (char)i);

                if (i < 22)
                {
                    Console.Write((char)10);
                }

                i++;
            }

            Console.Write("Please press any key to turn page");

            Console.ReadKey();

            while (i > 22 && i <= 44)
            {
                Console.Write(i + " = " + (char)i);

                if (i < 44)
                {
                    Console.Write((char)10);
                }

                i++;
            }

            Console.Write("Please press any key to turn page");

            Console.ReadKey();
        }
    }
}
