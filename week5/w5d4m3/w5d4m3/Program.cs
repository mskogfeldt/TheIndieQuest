using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace w5d4m3
{
    class Program
    {
        static void Main(string[] args)
        {

            string de6 = "To use the magic potion of dragon breath, first roll d8. If you 3d3 4d4 roll 2 or higher, you manage to open the potion. Now roll 5d4+5 to see how many seconds the spell will last. Finally, the damage of the flames will be 2d6 per second.";
            readTheText(de6);
        }

        public static Random random = new Random();
        public static char[] splitting = { 'd', '+', '-' };

        public static void readTheText(string text)
        {
            int numberOfThrows = 0;
            int diceNotationCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'd' || text[i] >= '1' && text[i] <= '9')
                {
                    string stringThatPossiblyIsDiceNotation = CheckIfDiceNotation(text, i);
                    if (CollectionOfMethodsToCalculateTheNumberOfDiceNotations(stringThatPossiblyIsDiceNotation) == true) 
                    {
                        i += stringThatPossiblyIsDiceNotation.Length;
                        diceNotationCount++;
                        numberOfThrows += CalculateTheNumberOfTimesDiceIsThrownInDiceNotation(stringThatPossiblyIsDiceNotation);
                    }
                }
            }
            Console.WriteLine(diceNotationCount + " standard dice notations present.");
            Console.WriteLine("The player will have to perform " + numberOfThrows + " rolls.");
            //The player will have to perform 8 rolls.
        }

        public static string CheckIfDiceNotation(string text, int indexOfStart)
        {
            string stringOfPossibleDiceNotation = "";
            bool makeTheStringWitchMightBeDiceNotation = true;
            while (makeTheStringWitchMightBeDiceNotation == true)
            {
                for (int i = indexOfStart; i < text.Length; i++)
                {
                    if (indexOfStart < text.Length)
                    {
                        if (text[i] == 'd' || text[i] == '-' || text[i] == '+' || text[i] >= '1' && text[i] <= '9') stringOfPossibleDiceNotation += text[i];
                        else
                        {
                            makeTheStringWitchMightBeDiceNotation = false;
                            return stringOfPossibleDiceNotation;
                        }
                    }
                }
            }
            return stringOfPossibleDiceNotation;
        }

        public static int CalculateTheNumberOfTimesDiceIsThrownInDiceNotation(string text)
        {
            string totalNumberStringForm = "";
            //int numberOfThrows = 0;
            if (text[0] == 'd') return 1;
            else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] >= '1' && text[i] <= '9') totalNumberStringForm += text[i];
                    else break;
                }
            }
            return Int32.Parse(totalNumberStringForm);//takeStringMakeInt(totalNumberStringForm);
        }
        

        public static bool CollectionOfMethodsToCalculateTheNumberOfDiceNotations(string text)
        {
            if (checkSoThereAreNoDoublesOfCertainAscii(text) == true && IsItemsInOrder(text) == true)
            {
                Console.WriteLine(text);
                return true;
            }
            return false;
        }

        public static void CollectionOfMethodsToCalculateTextToDiceNotation(string text)
        {
            if (checkSoThereAreNoDoublesOfCertainAscii(text) == true && IsItemsInOrder(text) == true && IsAsciiCorrectForText(text) == true)
            {
                int diceNotationOfText = DiceRoll(text);
                Console.WriteLine("Result is " + diceNotationOfText);
            }
            else Console.WriteLine($"Can't throw {text}, it is not in standard dice notation.");
        }

        public static bool IsAsciiCorrectForText(string text)
        {
            int count = 0;
            foreach (char s in text)
            {
                if (s == 'd' || s == '-' || s == '+' || s >= '1' && s <= '9') count++;
            }
            if (count == text.Length) return true;
            return false;
        }
 
        public static bool checkSoThereAreNoDoublesOfCertainAscii(string text)
        {
            if (DetectNumberOfMinus(text) + DetectNumberOfPlus(text) < 2 && DetectNumberOfD(text) == 1 && DetectNumberOfNumbers(text) >=1) return true;
            return false;
        }

        public static bool IsItemsInOrder(string text)
        {
            if (DetectNumberOfMinus(text) > 0)
            {
                if (FindIndexOfD(text) < FindIndexOfLastNumber(text) && FindIndexOfD(text) < FindIndexOfMinus(text) && FindIndexOfMinus(text) < FindIndexOfLastNumber(text)) return true;
            }
            else if (DetectNumberOfPlus(text) > 0)
            {
                if (FindIndexOfD(text) < FindIndexOfLastNumber(text) && FindIndexOfD(text) < FindIndexOfPlus(text) && FindIndexOfPlus(text) < FindIndexOfLastNumber(text)) return true;
            }
            else if (FindIndexOfD(text) < FindIndexOfLastNumber(text)) return true;
            return false;
        }

        public static int FindIndexOfD(string text)
        {
            int lastD = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'd') lastD = i;
            }
            return lastD;
        }

        public static int FindIndexOfMinus(string text)
        {
            int lastMinus = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '-') lastMinus = i;
            }
            return lastMinus;
        }

        public static int FindIndexOfPlus(string text)
        {
            int lastPlus = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '+') lastPlus = i;
            }

            return lastPlus;
        }

        public static int FindIndexOfLastNumber(string text)
        {
            int lastNumber = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '1' && text[i] <= '9' /*&& text[i] % 2 == 0*/) lastNumber = i;
            }

            return lastNumber + 1;
        }

        public static int DetectNumberOfNumbers(string text)
        {
            int numberOfNumbers = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '1' && text[i] <= '9') numberOfNumbers++;
            }
            return numberOfNumbers;
        }

        public static int DetectNumberOfD(string text)
        {
            int numberOfDs = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'd') numberOfDs++;
            }
            return numberOfDs;
        }

        public static int DetectNumberOfMinus(string text)
        {
            int numberOfMinus = 0;
            foreach (char s in text)
            {
                if (s == '-') numberOfMinus++;
            }
            return numberOfMinus;
        }

        public static int DetectNumberOfPlus(string text)
        {
            int numberOfPlus = 0;
            foreach (char s in text)
            {
                if (s == '+') numberOfPlus++;
            }
            return numberOfPlus;
        }

        public static int takeStringMakeInt(string number)
        {
            return Int32.Parse(number);
        }

        public static string takeIntMakeString(int number)
        {
            return number.ToString();
        }

        public static string[] TakeStringMakeArray(string diceNotation)
        {
            string[] sortedNumbers = diceNotation.Split(splitting);
            if (sortedNumbers[0] == "") sortedNumbers[0] = "1";
            return sortedNumbers;
        }

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
            if (sortedNumbers.Length == 3 && DetectNumberOfMinus(diceNotation) == 1) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[0]), takeStringMakeInt(sortedNumbers[2]) * -1);
            else if (sortedNumbers.Length == 3 && DetectNumberOfPlus(diceNotation) == 1) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[0]), takeStringMakeInt(sortedNumbers[2]));
            else if (sortedNumbers.Length == 2 && DetectNumberOfMinus(diceNotation) == 1) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[2]) * -1);
            else if (sortedNumbers.Length == 2 && DetectNumberOfPlus(diceNotation) == 1) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[2]));
            else return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[0]));
        }
    }
}


