using System;
using System.Collections.Generic;
using System.Text;

namespace w3d5m1
{
    public class userIo
    {
        Service service = new Service();
        
        public void printTheFrame(string f, string s, int frame)
        {
            Console.WriteLine($"FRAME " + frame);
            Console.WriteLine("+-----+");
            Console.WriteLine($"| |{f}|{s}|");
            Console.WriteLine("| ----|");
            Console.WriteLine("|     |");
            Console.WriteLine("+-----+");
        }


        public void tellPlayerHeMissed()
        {
            Console.WriteLine("Ha MISS!");
        }

        public void PrintPinns(List<int> pinnsToBePrinted)
        {
            Console.WriteLine($"{service.isPinStanding(pinnsToBePrinted, 6)} {service.isPinStanding(pinnsToBePrinted, 7)} {service.isPinStanding(pinnsToBePrinted, 8)} {service.isPinStanding(pinnsToBePrinted, 9)}");
            Console.WriteLine($" {service.isPinStanding(pinnsToBePrinted, 3)} {service.isPinStanding(pinnsToBePrinted, 4)} {service.isPinStanding(pinnsToBePrinted, 5)}");
            Console.WriteLine($"  {service.isPinStanding(pinnsToBePrinted, 1)} {service.isPinStanding(pinnsToBePrinted, 2)}");
            Console.WriteLine($"   {service.isPinStanding(pinnsToBePrinted, 0)}");
        }

        public void printGraphicsForTrowingTheBall()
        {
            Console.WriteLine("1234567");
            Console.WriteLine("Please chose one lande where to trow the ball");
        }

        public int letPlayerChoseWhereToTrowTheBall()
        {
            string numberText = Console.ReadLine();
            int lane = Int32.Parse(numberText);
            return lane;
        }
    }
}
