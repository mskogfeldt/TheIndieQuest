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

            //default setting for variable used when pressenting options to know what to write to the use
            bool sucsessfullDiceNotation = true;
         
            // default setting in form a variable, to make sure you can either repeat with same dicenotation or do a new one
            string usersDiceNotation = "";
           
            while ( true)
            {
                // Checking if there is no dicenotaion going in to the method, ie it is not repeated
                if (diceNotationGoingInToTheMethod == "")
                {
                    PrintOptionsForUser(sucsessfullDiceNotation);
                    usersDiceNotation = Console.ReadLine();
                }
                // then there is a repetion of earlier input, dont ask for new input from the user
                else
                {
                    usersDiceNotation = diceNotationGoingInToTheMethod;
                }
                //checking so that the user input is IsStandardDiceNotation dice notation.
                if (IsStandardDiceNotation(usersDiceNotation))
                {
                    Console.WriteLine("Simulating …");
                    
                    //reciving the sting dicenotation from user input in a list of two or three ints
                    List<int> dataDiceRoll = DiceRoll(usersDiceNotation);

                    // taking the list of two or three ints and turning them in to a list of dicerolls with the sum at the last spot in the list
                    List<int> resultsOfDiceRoll = ExecutingDiceRoll(dataDiceRoll[0], dataDiceRoll[1], dataDiceRoll[2]);

                    // printning results starts here, specoial graphics for d4(one row below), d6(two rows below) or any other results(three rows below)
                    if (dataDiceRoll[1] == 4) PrintTheResultsForD4(resultsOfDiceRoll);
                    else if (dataDiceRoll[1] == 6) PrintTheResultsForD6(resultsOfDiceRoll);
                    else PrintTheResults(resultsOfDiceRoll);

                   //no change from default setting
                    sucsessfullDiceNotation = true;

                    //checking what the user whants to do after writing results from diceroll
                    string whatToDo = QuitRepeatContinue();
                    if (whatToDo == "n") RunTheProgramLoop("");
                    else if (whatToDo == "q") break;
                    else if (whatToDo == "r") RunTheProgramLoop(usersDiceNotation);
                }
                else
                {
                    //unsucessfull try, change bool to effect option for user 
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

        // for all results exept d4 and d6
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

        //results for d4
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

        //results for d4
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
    
        //Used to turn int to string and ad letter depending on number, then used in printing the results, like 1st, 2nd...
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

        //preseenting 2 options depending on a bool
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

        //turning string(of user input) into 2 or 3 length list
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

        //turning list of tho or three ints into list with reults of dicerolls, sum at the last place in list 
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
