using System;
using System.Collections.Generic;

namespace w5d3m4
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            Console.WriteLine("Throwing 1d6 " + DiceRoll("Throwing 1d6"));
            Console.WriteLine("Throwing 2d8 " + DiceRoll("Throwing 2d8"));
            Console.WriteLine("Throwing 3d6+8 " + DiceRoll("Throwing 3d6+8"));
            Console.WriteLine("Throwing 1d4+4 " + DiceRoll("Throwing 1d4+4"));
           
    

            int DiceRoll(string diceNotation)
            {
                if (findNumberOfIntsInString(diceNotation) < 3) return findInt(diceNotation, 1) * random.Next(1, findInt(diceNotation, 2));
                if (findNumberOfIntsInString(diceNotation) > 2) return findInt(diceNotation, 1) * random.Next(1, findInt(diceNotation, 2)) + findInt(diceNotation, 3);
                return -1;
            }
    
            int findNumberOfIntsInString(string diceNotation)
            {
                int count = 0;
                foreach (char c in diceNotation)
                {
                    if (c >= '1' && c <= '9') count ++;
                }
                return count;
            }

            int findInt(string diceNotation, int index)
            {
                int count = 0;
                foreach(char c in diceNotation)
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
}
