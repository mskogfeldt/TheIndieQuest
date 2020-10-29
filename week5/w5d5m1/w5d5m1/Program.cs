using System;

namespace w5d5m1
{
    class Program
    {
        static void Main(string[] args)
        {

            string de6 = "sadfs";
            //readTheText(de6);

            try
            {
                int strength = DiceRoll("3");
                Console.WriteLine("Result is " + strength);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not throw. {e.Message}"); 
            }

        }
        public static Random random = new Random();
        public static char[] splitting = { 'd', '+', '-' };

     /*  public string returnTheDiceNotationUserWrites()
        {
            try
            {
                return Console.ReadLine();
            }
            catch
        }*/

        public static void CollectionOfMethodsToCalculateTextToDiceNotation(string text)
        {
            if (checkSoThereAreNoDoublesOfCertainAscii(text) == true && IsItemsInOrder(text) == true && IsAsciiCorrectForText(text) == true)
            {
                int diceNotationOfText = DiceRoll(text);
                
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
            if (DetectNumberOfMinus(text) + DetectNumberOfPlus(text) < 2 && DetectNumberOfD(text) == 1 && DetectNumberOfNumbers(text) >= 1) return true;
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
            // int countToSeIfDiceIsRolled = 0;

            if (checkSoThereAreNoDoublesOfCertainAscii(diceNotation) == false) throw new ArgumentException("You have either double d or +-");

            if (IsItemsInOrder(diceNotation) == false) throw new ArgumentException("You have either double d or +-");

            if (IsAsciiCorrectForText(diceNotation) == false) throw new ArgumentException("You have either double d or +-");
           
            string[] sortedNumbers = TakeStringMakeArray(diceNotation);
            if (sortedNumbers.Length == 3 && DetectNumberOfMinus(diceNotation) == 1) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[0]), takeStringMakeInt(sortedNumbers[2]) * -1);
            else if (sortedNumbers.Length == 3 && DetectNumberOfPlus(diceNotation) == 1) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[0]), takeStringMakeInt(sortedNumbers[2]));
            else if (sortedNumbers.Length == 2 && DetectNumberOfMinus(diceNotation) == 1) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[2]) * -1);
            else if (sortedNumbers.Length == 2 && DetectNumberOfPlus(diceNotation) == 1) return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[2]));
            else return DiceRoll(takeStringMakeInt(sortedNumbers[1]), takeStringMakeInt(sortedNumbers[0]));
        }
    }
}
/*
 *  public static void readTheText(string text)
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
 * */


