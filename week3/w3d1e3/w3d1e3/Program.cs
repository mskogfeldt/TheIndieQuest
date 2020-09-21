using System;

namespace w3d1e3
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 300; i++)
            {
                //string display = OrdinalNumber(i);
                //Console.WriteLine(OrdinalNumber(i);
                Console.WriteLine(OrdinalNumber(i));
            }
            

           // int lastDidgit = 0;
           //  int secondToLastDidgit = 0;

            static string OrdinalNumber(int number)
            {
                string returnString = "";
                int lastDidgit = number % 10;
                int secondToLastDidgit = 0;
                if (number >= 10)
                {
                    secondToLastDidgit = number / 10 % 10;
                }
                if (secondToLastDidgit == 1)
                {
                    returnString += number + "th";
                }
                else
                {
                    if (lastDidgit == 1)
                    {
                        returnString += number + "st";
                    }
                    else
                    {
                        if (lastDidgit == 2)
                        {
                            returnString += number + "nd";
                        }
                        else
                        {
                            if (lastDidgit == 3)
                            {
                                returnString += number + "rd";
                            }
                            else
                            {
                                returnString += number + "th";
                            }
                        }
                    }
                }

                return returnString;
            }
            /*
             * Get the last digit of an integer by modding it with 10.
If the number is bigger than 10, also get the second to last digit by dividing the integer by 10 and then modding the result with 10.
If the second to last digit is 1, return the integer plus "th"
If the last digit is 1, return the integer plus "st".
If the last digit is 2, return the integer plus "nd".
If the last digit is 3, return the integer plus "rd".
Otherwise return integer plus "th".


1st
2nd
3rd
4th
10th
11th
12th
13th
21st
101st
111th
121st

             */
        }
    }
}
