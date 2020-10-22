using System;
using System.Collections.Generic;

namespace w5d3m4
{
    class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("Throwing 1d6 " + DiceRoll("1d6"));
                Console.WriteLine("Throwing 2d8 " + DiceRoll("2d8"));
                Console.WriteLine("Throwing 3d6+8 " + DiceRoll("3d6+8"));
                Console.WriteLine("Throwing 1d4+4 " + DiceRoll("1d4+4"));
                Console.ReadLine();
                Console.Clear();
            }


        }

        static Random random = new Random();
        static int DiceRoll(int numberOfDices, int sidesOfDice, int fixedBonus = 0)
        {
            int dicescore = 0;
            for (int i = 0; i < numberOfDices; i++)
            {
                dicescore += random.Next(1, sidesOfDice + 1);
            }
            dicescore += fixedBonus;
            return dicescore;
        }

        static int DiceRoll(string diceNotation)
        {
            if (findNumberOfIntsInString(diceNotation) < 3) return DiceRoll(findInt(diceNotation, 1), findInt(diceNotation, 2));
            if (findNumberOfIntsInString(diceNotation) > 2) return DiceRoll(findInt (diceNotation, 1), findInt(diceNotation, 2), findInt(diceNotation, 3));
            return -1;
        }

        static int findNumberOfIntsInString(string diceNotation)
        {
            int count = 0;
            foreach (char c in diceNotation)
            {
                if (c >= '1' && c <= '9') count++;
            }
            return count;
        }

        static int findInt(string diceNotation, int index)
        {
            int count = 0;
            foreach (char c in diceNotation)
            {
                if (c >= '1' && c <= '9')
                {
                    count++;
                    if (count == index)
                    {
                        return Convert.ToInt32(new string(c, 1));
                    }
                }
            }
            return -1;
        }
    }
}
