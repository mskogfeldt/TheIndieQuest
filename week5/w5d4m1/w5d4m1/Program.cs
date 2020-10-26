using System;
using System.Collections.Generic;

namespace w5d4m1
{
    class Program
    {
        static void Main(string[] args)
        {

            string d6 = "d6 ";
            string Oned6 = "1d6 ";
            string twoD8 = "2d8 ";
            string threeD6PlusEight = "3d6+8 ";

            int testOne = DiceRoll(d6);
            int testOneB = DiceRoll(Oned6);
            int testTwo = DiceRoll(twoD8);
            int testThree = DiceRoll(threeD6PlusEight);

            Console.WriteLine(d6 + " " + testOne);
            Console.WriteLine(Oned6 + " " + testOneB);
            Console.WriteLine(twoD8 + " " + testTwo);
            Console.WriteLine(threeD6PlusEight + " " + testThree);
            char[] splitting = { 'd', '+', '-' };


        }
        public static Random random = new Random();
        public static char[] splitting = { 'd', '+', '-' };

        public static int DiceRoll(int sidesOfDice, int numberOfDices = 1, int fixedBonus = 0)
        {
            int dicescore = 0;
            for (int i = 0; i < numberOfDices; i++)
            {
                dicescore += random.Next(1, sidesOfDice + 1);
            }
            dicescore += fixedBonus;
            return dicescore;
        }

        public static int DiceRoll(string diceNotation)
        {
            string[] sortedNumbers = TakeStringMakeArray(diceNotation);
            if (sortedNumbers.Length == 3 && DetectMinus(diceNotation) == true) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[0]), takeStringMakeInt(sortedNumbers[2]) * -1);
            else if (sortedNumbers.Length == 3 && DetectPlus(diceNotation) == true) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[0]), takeStringMakeInt(sortedNumbers[2]));
            else if (sortedNumbers.Length == 2 && DetectMinus(diceNotation) == true) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[2]) * -1);
            else if (sortedNumbers.Length == 2 && DetectPlus(diceNotation) == true) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[2]));
            else return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[0]));
        }


        public static bool DetectMinus(string diceNotation)
        {
            foreach (char s in diceNotation)
            {
                if (s == '-') return true;
            }
            return false;
        }

        public static bool DetectPlus(string diceNotation)
        {
            foreach (char s in diceNotation)
            {
                if (s == '+') return true;
            }
            return false;
        }

        public static int takeStringMakeInt(string number)
        {
            return Int32.Parse(number);
        }

        public static string[] TakeStringMakeArray(string diceNotation)
        {
            string[] sortedNumbers = diceNotation.Split(splitting);
            if (sortedNumbers[0] == "") sortedNumbers[0] = "1";
            foreach(string s in sortedNumbers)
            {
                Console.WriteLine(s);
            }
            return sortedNumbers;
        }
    }
}
