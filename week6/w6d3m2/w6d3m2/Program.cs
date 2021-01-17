
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace w6d2m2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string diceNotation = Console.ReadLine();
                var listOfRolls = new List<int> { };
                int numberOfThrows = 10;
                if (IsStandardDiceNotation(diceNotation))
                {
                    for (int throws = 0; throws < numberOfThrows; throws++)
                    {
                        listOfRolls.Add(DiceRoll(diceNotation));
                    }
                    Console.WriteLine($"Throwing {diceNotation} ... {string.Join(" ", listOfRolls)}");
                }
                else
                {
                    Console.WriteLine($"Can't throw {diceNotation}, it is not in standard dice notation.");
                }
            }
        }

        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            var random = new Random();
            int diceSide;
            int sum = 0;
            for (var i = 0; i < numberOfRolls; i++)
            {
                diceSide = random.Next(1, diceSides + 1);
                sum += diceSide;
            }

            return sum + fixedBonus;
        }


        static int DiceRoll(string diceNotation)
        {
            string[] valuesOfDiceNotation = diceNotation.Split('d', '+', '-');

            string numberOfRollsString = valuesOfDiceNotation[0];
            string diceSidesString = valuesOfDiceNotation[1];

            if (numberOfRollsString == "")
            {
                numberOfRollsString = "1";
            }
            int numberOfRolls = Int32.Parse(numberOfRollsString);
            int diceSides = Int32.Parse(diceSidesString);

            string fixedBonusString;
            int fixedBonus = 0;
            if (valuesOfDiceNotation.Length > 2)
            {
                fixedBonusString = valuesOfDiceNotation[2];
                fixedBonus = Int32.Parse(fixedBonusString);

                if (diceNotation.Contains('-'))
                {
                    fixedBonus = 0 - fixedBonus;
                }
            }

            return DiceRoll(numberOfRolls, diceSides, fixedBonus);
        }

        static bool IsStandardDiceNotation(string text)
        {
            bool diceNotation = false;

            string diceNotationPattern = "^\\d*d\\d+[+-]?\\d*$";
            if (Regex.IsMatch(text, diceNotationPattern))
            {
                diceNotation = true;
            }

            return diceNotation;
        }

    }
}
KD