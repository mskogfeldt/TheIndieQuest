using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace w5d5m2
{
    class Program
    {
        public static void Main()
        {
            string path = @"message.txt";
            List<string> phonenumbers = new List<string> { };

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "For a fun time with Edna, call 510-555-3444. If you'd rather talk to Fred, you can reach him at 415-555-1337." + Environment.NewLine;
                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string appendText = "This is extra text" + Environment.NewLine;
            File.AppendAllText(path, appendText, Encoding.UTF8);

            // Open the file to read from.
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);

            string[] arrayOfWordsFromReadTextFile = TakeStringMakeArray(readText);
            List<string> phonnNumbers = TakeArrayMakeList(arrayOfWordsFromReadTextFile);

            Console.WriteLine("The phone numbers present in the file are:");

            foreach(string phoneNumber in phonnNumbers)
            {
                Console.WriteLine(phoneNumber);
            }
    }
        public static char[] splitting = { ' ', '.', ';',/*'!', '?'*/ };

        public static List<string> phonenumbers = new List<string> { };

        //public static []string theWordsFromTheFile = readText

        public static string[] TakeStringMakeArray(string theReadFile)
        {
            string[] sortedNumbers = theReadFile.Split(splitting);
            return sortedNumbers;
        }

        public static List<string> TakeArrayMakeList(string[] arrayOfTextfileWords)
        {
            List<string> listOfPhoneNumbers = new List<string> { };
            foreach (string s in arrayOfTextfileWords)
            {
                if (isTextPhoneNumber(s) == true) listOfPhoneNumbers.Add(s);
            }
            return listOfPhoneNumbers;
        }

        public static bool isTextPhoneNumber(string textitext)
        {
            int count = 0;
            foreach (char s in textitext)
            {
                if (s == '-' || s >= '0' && s <= '9') count++;
            }
            if (count == textitext.Length) return true;
            return false;
        } 
    }
}
