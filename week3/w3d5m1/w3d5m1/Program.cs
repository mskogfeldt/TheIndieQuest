using System;
using System.Collections.Generic;

namespace w3d5m1
{
    class Program
    {
        static void Main(string[] args)
        {
            var scoreBoard = new List<int> { };
            var scoreBoardString = new List<string> { };
            int score = 0;
            //var pinns = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int frame = 1;

            void presentBeforThrowing(List<int> ,string stringOne, string stringTwo)
            {
                var pinns = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                printTheFrame(stringOne, stringTwo);
                PrintPinns(pinns);
                printGraphicsForTrowingTheBall();
            }

            /*  int laneToThrowTheBall = letPlayerChoseWhereToTrowTheBall();
              knockPinns(laneToThrowTheBall);
              score += calculateScore(pinns);

              printTheFrame();
              PrintPinns(pinns);
              printGraphicsForTrowingTheBall();
              int laneToThrowTheBall2 = letPlayerChoseWhereToTrowTheBall();
              knockPinns(laneToThrowTheBall);
              score += calculateScore(pinns);*/

            //playFrame(pinns, score);
            void printTheFrame(string throwOne, string ThrowTwo)
            {
                int frame = 1;
                // var listForPrintingFrame = new List<string> { "FRAME ", "+-----+", $"| | | |", "| ----|", "|     |", "+-----+" };
                Console.WriteLine($"FRAME " + frame);
                Console.WriteLine("+-----+");
                //Console.WriteLine($"| |/*{}*/|/*{}*/|");
                Console.WriteLine($"| | | |");
                Console.WriteLine("| ----|");
                Console.WriteLine("|     |");
                Console.WriteLine("+-----+");
            }

            void PrintPinns(List<int> pinnsToBePrinted)
            {
                Console.WriteLine($"{isPinStanding(pinnsToBePrinted, 6)} {isPinStanding(pinnsToBePrinted, 7)} {isPinStanding(pinnsToBePrinted, 8)} {isPinStanding(pinnsToBePrinted, 9)}");
                Console.WriteLine($" {isPinStanding(pinnsToBePrinted, 3)} {isPinStanding(pinnsToBePrinted, 4)} {isPinStanding(pinnsToBePrinted, 5)}");
                Console.WriteLine($"  {isPinStanding(pinnsToBePrinted, 1)} {isPinStanding(pinnsToBePrinted, 2)}");
                Console.WriteLine($"   {isPinStanding(pinnsToBePrinted, 0)}");
            }

            void printGraphicsForTrowingTheBall()
            {
                Console.WriteLine("1234567");
                Console.WriteLine("Please chose one lande where to trow the ball");
            }

            void playFrame(List<int> pins, int score)
            {
                string throwOne = " ";
                string throwTwo = " ";
                presentBeforThrowing();
                int laneToThrowTheBall = letPlayerChoseWhereToTrowTheBall();
                knockPins(pins, laneToThrowTheBall);
                int result = calculateScore(pins);
                score += result;
                if(result != 10)
                {
                    presentBeforThrowing();
                    int laneToThrowTheSecondBall = letPlayerChoseWhereToTrowTheBall();
                    knockPins(pins, laneToThrowTheBall);
                    int resultForSecondBall = calculateScore(pins);
                    score += resultForSecondBall;
                }
            }

            int calculateScore(List<int> standingPinns)
            {
                int results = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (standingPinns[i] > 0) results++; 
                }
                return results;
            }

            void knockPins(List<int> pins, int lane)
            {
                if (lane < 1 || lane > 7) Console.WriteLine("Ha MISS!");
                if (lane == 1) pins[6] = 0;
                if (lane == 2) pins[3] = 0;
                if (lane == 3 && pins[1] == 0) pins[7] = 0;
                if (lane == 3 && pins[1] > 0) pins[1] = 0;
                if (lane == 4 && pins[0] == 0) pins[4] = 0;
                if (lane == 4 && pins[0] > 0) pins[0] = 0;
                if (lane == 5 && pins[2] == 0) pins[8] = 0;
                if (lane == 5 && pins[2] > 0) pins[2] = 0;
                if (lane == 6) pins[5] = 0;
                if (lane == 7) pins[9] = 0;

            }

            string takeIntMakeString(int number)
            {
                string word = number.ToString();
                return word;
            }
            
            string isPinStanding(List<int> pins, int indexOfPins)
            {
                if (pins[indexOfPins] > 0) return "0";
                else return " ";
            }

            
            int letPlayerChoseWhereToTrowTheBall() 
            {
                string numberText = Console.ReadLine();
                int lane = Int32.Parse(numberText);
                return lane;
            }
        }
    }
}
