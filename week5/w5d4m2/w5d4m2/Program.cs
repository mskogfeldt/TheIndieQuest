using System;

namespace w5d4m2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string de6 = "d6";
            string twoD6 = "2d6";
            string d6Plus4 = "d6+4";
            string twoD6plus4 = "2d6+4";
            string thirtyFour = "34";
            string ad6 = "ad6";
            string bunch = "33d4*2";

            Console.WriteLine(de6);
            CollectionOfMethodsToCalculateTextToDiceNotation(de6);
            Console.WriteLine(twoD6);
            CollectionOfMethodsToCalculateTextToDiceNotation(twoD6);
            Console.WriteLine(d6Plus4);
            CollectionOfMethodsToCalculateTextToDiceNotation(d6Plus4);
            Console.WriteLine(twoD6plus4);
            CollectionOfMethodsToCalculateTextToDiceNotation(twoD6plus4);
            Console.WriteLine(thirtyFour);
            CollectionOfMethodsToCalculateTextToDiceNotation(thirtyFour);
            Console.WriteLine(ad6);
            CollectionOfMethodsToCalculateTextToDiceNotation(ad6);
            Console.WriteLine("33d4*2");
            CollectionOfMethodsToCalculateTextToDiceNotation(bunch);
        }

        public static Random random = new Random();
        public static char[] splitting = { 'd', '+', '-' };

        public static void CollectionOfMethodsToCalculateTextToDiceNotation(string text)
        {
            if (checkSoThereAreNoDoublesOfSertainAscii(text) == true && IsItemsInOrder(text) == true && IsAsciiCorrectForText(text) == true)
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
                if (s == 'd' || s == '-' || s == '+' || s >= '1' && s <= '9') count ++;
            }
            if (count == text.Length) return true;
            return false;
        }

        public static bool checkSoThereAreNoDoublesOfSertainAscii(string text)
        {
            if (DetectNumberOfMinus(text) + DetectNumberOfPlus(text) < 2 && DetectNumberOfD(text) == 1) return true;
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
                if (text[i] >= '1' && text[i] <= '9' && text[i] % 2 == 0) lastNumber = i;
            }
 
            return lastNumber + 1;
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
