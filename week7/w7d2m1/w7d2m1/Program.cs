using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace w7d2m1
{
    class Program
    {
        static void Main(string[] args)
        {
            Pressentation();
            RunTheProgramLoop("");
        }

        public static void RunTheProgramLoop(string diceNotationGoingInToTheMethod)
        {

            bool keepAtIt = true;
            bool sucsessfullDiceNotation = true;
            string usersDiceNotation = "";
            while (keepAtIt == true)
            {
                if (diceNotationGoingInToTheMethod == "")
                {
                    PrintOptionsForUser(sucsessfullDiceNotation);
                    usersDiceNotation = Console.ReadLine();
                }
                else
                {
                    usersDiceNotation = diceNotationGoingInToTheMethod;
                }
                if (IsStandardDiceNotation(usersDiceNotation))
                {
                    Console.WriteLine("Simulating …");
                    List<int> dataDiceRoll = DiceRoll(usersDiceNotation);

                    List<int> resultsOfDiceRoll = ExecutingDiceRoll(dataDiceRoll[0], dataDiceRoll[1], dataDiceRoll[2]);

                    if (dataDiceRoll[1] == 4) PrintTheResultsForD4(resultsOfDiceRoll);
                    else if (dataDiceRoll[1] == 6) PrintTheResultsForD6(resultsOfDiceRoll);
                    else PrintTheResults(resultsOfDiceRoll);

                    sucsessfullDiceNotation = true;
                    string whatToDo = QuitRepeatContinue();
                    if (whatToDo == "n") RunTheProgramLoop("");
                    else if (whatToDo == "q") break;
                    else if (whatToDo == "r") RunTheProgramLoop(usersDiceNotation);
                }
                else
                {
                    sucsessfullDiceNotation = false;
                }
            }
        }

        public static string QuitRepeatContinue()
        {
            Console.WriteLine("Do you want to(r)epeat, enter a(n)ew roll, or (q)uit ?");
            string whatToDo = Console.ReadLine();
            return whatToDo;
        }

        public static void PrintTheResults(List<int> infoOfDiceRoll)
        {
            int numberOfItemsInList = infoOfDiceRoll.Count;
            for (int i = 0; i < infoOfDiceRoll.Count - 1; i++)
            {
                string numberForPrinting = MakePresentableNumberOfInt(i + 1);
                Console.WriteLine(numberForPrinting + " roll is:" + infoOfDiceRoll[i]);
            }
            Console.WriteLine("You rolled " + infoOfDiceRoll[infoOfDiceRoll.Count - 1] + ".");
        }

        public static void PrintTheResultsForD4(List<int> infoOfDiceRoll)
        {
            string[] dices = new string[4];
            string pathD4 = "d4.txt";
            dices = File.ReadAllLines(pathD4);
            int numberOfItemsInList = infoOfDiceRoll.Count;
            for (int i = 0; i < infoOfDiceRoll.Count - 1; i++)
            {
                string numberForPrinting = MakePresentableNumberOfInt(i + 1);
                for (int j = 0; j < dices.Length; j++)
                {
                    string stringWithReplacedNumber = dices[j].Replace("n", infoOfDiceRoll[i].ToString());
                    Console.WriteLine(stringWithReplacedNumber);
                }
              //  Console.WriteLine("You rolled " + infoOfDiceRoll[infoOfDiceRoll.Count - 1] + ".");
                Console.WriteLine(numberForPrinting + " roll is:" + infoOfDiceRoll[i]);
            }
            Console.WriteLine("You rolled " + infoOfDiceRoll[infoOfDiceRoll.Count - 1] + ".");

        }


        public static void PrintTheResultsForD6(List<int> infoOfDiceRoll)
        {
            string[] dices = new string[7];
            string pathD6 = "d6.txt";
            dices = File.ReadAllLines(pathD6);
            int numberOfItemsInList = infoOfDiceRoll.Count;

            for (int i = 0; i < infoOfDiceRoll.Count -1; i++)
            {
                string numberForPrinting = MakePresentableNumberOfInt(i + 1);
                for (int j = 0; j < dices.Length; j++)
                {
                    if (infoOfDiceRoll[i] == 1) 
                    {
                        string stringWithReplacedNumber = dices[j].Replace('1', 'O');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('2', ' ');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('3', ' ');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('4', ' ');
                        Console.WriteLine(stringWithReplacedNumber);

                    }
                    else if (infoOfDiceRoll[i] == 2)
                    {
                        string stringWithReplacedNumber = dices[j].Replace('1', ' ');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('2', 'O');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('3', ' ');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('4', ' ');
                        Console.WriteLine(stringWithReplacedNumber);
                    }
                    else if (infoOfDiceRoll[i] == 3)
                    {
                        string stringWithReplacedNumber = dices[j].Replace('1', 'O');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('2', ' ');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('3', 'O');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('4', ' ');
                        Console.WriteLine(stringWithReplacedNumber);
                    }
                    else if (infoOfDiceRoll[i] == 4)
                    {
                        string stringWithReplacedNumber = dices[j].Replace('1', ' ');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('2', ' ');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('3', 'O');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('4', 'O');
                        Console.WriteLine(stringWithReplacedNumber);
                    }
                    else if (infoOfDiceRoll[i] == 5)
                    {
                        string stringWithReplacedNumber = dices[j].Replace('1', 'O');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('2', ' ');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('3', 'O');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('4', 'O');
                        Console.WriteLine(stringWithReplacedNumber);
                    }
                    else if (infoOfDiceRoll[i] == 6)
                    {
                        string stringWithReplacedNumber = dices[j].Replace('1', ' ');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('2', 'O');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('3', 'O');
                        stringWithReplacedNumber = stringWithReplacedNumber.Replace('4', 'O');
                        Console.WriteLine(stringWithReplacedNumber);
                    }
                }
                Console.WriteLine(numberForPrinting + " roll is:" + infoOfDiceRoll[i]);
            }
            Console.WriteLine("You rolled " + infoOfDiceRoll[infoOfDiceRoll.Count - 1] + ".");
        }
    

        public static string MakePresentableNumberOfInt(int number)
        {
            {
                int lastDigit = number % 10;
                int secondDigit = 0;

                if (number > 10)
                {
                    secondDigit = (number / 10) % 10;
                }

                if (secondDigit == 1)
                {
                    return number + "th";
                }
                else if (lastDigit == 1)
                {
                    return number + "st";
                }
                else if (lastDigit == 2)
                {
                    return number + "nd";
                }
                else if (lastDigit == 3)
                {
                    return number + "rd";
                }
                else
                {
                    return number + "th";
                }
            }
        }

        public static void Pressentation()
        {
            Console.WriteLine("DICE SIMULATOR\n");
        }

        public static void PrintOptionsForUser(bool isItFirstTry)
        {
            if (isItFirstTry) Console.WriteLine("Enter desired dice roll in standard dice notation:");
            else Console.WriteLine("You did not use standard dice notation. Try again:");
        }

        public static void PrintNotStandardDiceNotation()
        {
            Console.WriteLine("You did not use standard dice notation. Try again:");
        }

        static bool IsStandardDiceNotation(string text)
        {
            string diceNotationPattern = "^\\d*d\\d+[+-]?\\d*$";
            if (Regex.IsMatch(text, diceNotationPattern))
            {
                return true;
            }
            return false;
        }

        static List<int> DiceRoll(string diceNotation)
        {
            string[] values = diceNotation.Split('d', '+', '-');

            List<int> results = new List<int> { };

            string numberOfRollsString = values[0];
            string diceSidesString = values[1];

            results.Add(Int32.Parse(numberOfRollsString));
            results.Add(Int32.Parse(diceSidesString));

            string fixedBonusString;
            int fixedBonus = 0;
            if (values.Length > 2)
            {
                fixedBonusString = values[2];
                fixedBonus = Int32.Parse(fixedBonusString);
                if (diceNotation.Contains('-'))
                {
                    fixedBonus = 0 - fixedBonus;
                }
            }
            results.Add(fixedBonus);
            return results;
        }

        public static List<int> ExecutingDiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            List<int> rollsAndSum = new List<int> { };
            var random = new Random();
            int diceSide;
            int sum = 0;


            for (var i = 0; i < numberOfRolls; i++)
            {
                int dice = random.Next(1, diceSides + 1);
                rollsAndSum.Add(dice);
                sum += dice;
            }
            rollsAndSum.Add(sum + fixedBonus);
            return rollsAndSum;
        }

    }
}
