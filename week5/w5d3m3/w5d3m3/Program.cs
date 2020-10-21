using System;
using System.Text;

namespace w5d3m3
{
    class Program
    {
        public static void Main()
        {
            bool a = checkString("batman");
            bool b = checkString("player1");
            bool c = checkString("1234");
            bool d = checkString("deathEATER");
            bool e = checkString("warrior - princess");

            Console.WriteLine("batman = " + a);
            Console.WriteLine("player1 = " + b);
            Console.WriteLine("1234 = " + c);
            Console.WriteLine("deathEATER = " + d);
            Console.WriteLine("warrior - princess = " + e);
            bool checkString(string test)
            {
                foreach (char c in test)
                {
                    if (c >= 'a' && c <= 'z' || c >= '1' && c <= '9') continue;
                    else return false;
                }
                return true;
            }
        }
    }
}
