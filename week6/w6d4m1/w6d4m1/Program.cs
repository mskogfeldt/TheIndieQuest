using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace w6d4m1
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();

            string[] urls = new string[] { httpClient.GetStringAsync(@"https://store.steampowered.com/app/364360/Total_War_WARHAMMER/").Result,
                                               httpClient.GetStringAsync(@"https://store.steampowered.com/app/594570/Total_War_WARHAMMER_II/").Result};

            string regexForNames = @"<b>Title:</b> (.*)<br>";
            string regexForRating = @"<.*game_review_summary.*data.*>([\D].*)<\/span>";

            string[][] namesAndRatings = new string[urls.Length][];
            CreateTheArray();
            AddDataToArray();
            PrintResults();


            void CreateTheArray()
            {
                for (int i = 0; i < namesAndRatings.Length; i++)
                {
                    namesAndRatings[i] = new string[3];
                }
            }

            void AddDataToArray()
            {

                for (int i = 0; i < urls.Length; i++)
                {
                    Match name = Regex.Match(urls[i], regexForNames);
                    MatchCollection ratings = Regex.Matches(urls[i], regexForRating);

                    //name.Groups[1].Value
                    GroupCollection groups;

                    groups = name.Groups;
                    namesAndRatings[i][0] = groups[1].Value;

                    for (int j = 0; j < ratings.Count; j++)
                    {
                        groups = ratings[j].Groups;
                        namesAndRatings[j][j + 1] = groups[1].Value;
                    }
                }

            }

            void PrintResults()
            {
                for (int i = 0; i < namesAndRatings.Length; i++)
                {
                    Console.WriteLine(namesAndRatings[i][0].ToUpper());
                    if (namesAndRatings[i][2] != null)
                    {
                        Console.WriteLine($"Recent reviews: {namesAndRatings[i][2]}");
                        Console.WriteLine($"All reviews: {namesAndRatings[i][1]}");
                    }
                    else if (namesAndRatings[i][1] != null)
                    {
                        Console.WriteLine($"All reviews: {namesAndRatings[i][1]}");
                    }
                    else
                    {
                        Console.WriteLine("This game has no rating.");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
