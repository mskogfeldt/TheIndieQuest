using System;

namespace w5d1m1
{
    class Program
    {
        static Random random = new Random();
        static string[] seasons = { "Winter", "Spring", "Summer", "Autumn" };

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                int date = ReturnRandomNumber(90);
                int indexOfSeasons = ReturnRandomNumber(4);
                int year = ReturnRandomNumber(1500);
                DescribeDate(CreateDayDescription(date, indexOfSeasons, year));
            }

        }

        static void DescribeDate(string date) 
        {
            Console.WriteLine(date);
        }

        static int ReturnRandomNumber(int number)
        {
            int returnNumber = random.Next(number);
            return returnNumber;
        }

        static string OrdinalNumber(int number)
        {
            int lastDidgit = number % 10;
            int secondToLastDidgit = 0;
            if (number >= 10)
            {
                secondToLastDidgit = number / 10 % 10;
            }
            if (secondToLastDidgit == 1)
            {
                return number + "th";
            }
            else
            {
                if (lastDidgit == 1)
                {
                    return number + "st";
                }
                else
                {
                    if (lastDidgit == 2)
                    {
                        return number + "nd";
                    }
                    else
                    {
                        if (lastDidgit == 3)
                        {
                            return number + "rd";
                        }
                        else
                        {
                            return number + "th";
                        }
                    }
                }
            }
        }

        static string CreateDayDescription(int day, int season, int year)
        {
            string start = OrdinalNumber(day);
            string returnString = start + " day of " + seasons[season] + " in the year " + year + "!";
            return returnString;
        }
    }
}
