using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace w6d2m3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"MonsterManual.txt";
            string[] monsterData = File.ReadAllLines(path);
            var listOfMonsters = new List<string> { };
            string alignmentAndGoodness = "(lawful|neutral|chaotic) (good|neutral|evil)";

            List<string> monstersWithStatedAlignments = new List<string> { };

            monstersWithStatedAlignments = CreateListWithMonstersWithMentionedAllignment(monsterData, monstersWithStatedAlignments, alignmentAndGoodness);
            PrintTheResults(monstersWithStatedAlignments);
        }


        public static List<string> CreateListWithMonstersWithMentionedAllignment(string[] monsterData, List<string> monsterWithCertainAllignments, string alignmentAndGoodness)
        {
            int indexOfCertainMonstersData = 0;

            for (int i = 0; i < monsterData.Length; i++)
            {
                if (indexOfCertainMonstersData == 1 && Regex.IsMatch(monsterData[i], alignmentAndGoodness))
                {
                    monsterWithCertainAllignments.Add(monsterData[i - 1]);

                    string[] takeTheTwoLastWords = Regex.Split(monsterData[i], " ");
                    string twoLastWords = $"({takeTheTwoLastWords[takeTheTwoLastWords.Length - 2]} {takeTheTwoLastWords[takeTheTwoLastWords.Length - 1]})";
                    monsterWithCertainAllignments.Add(twoLastWords);
                }
                if (monsterData[i] == "")
                {
                    indexOfCertainMonstersData = 0;
                }
                else
                {
                    indexOfCertainMonstersData++;
                }
            }
            return monsterWithCertainAllignments;
        }

        public static void PrintTheResults(List<string> monsterWithCertainAllignments)
        {
            Console.WriteLine("Monsters with a specific alignment:");

            for (int i = 0; i < monsterWithCertainAllignments.Count; i++)
            {
                Console.WriteLine($"{monsterWithCertainAllignments[i]} {monsterWithCertainAllignments[i + 1]}");
                i++;
            }
        }
    }
}
