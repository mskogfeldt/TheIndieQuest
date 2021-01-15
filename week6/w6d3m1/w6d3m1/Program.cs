using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace w6d3m1
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"MonsterManual.txt";
            string[] monsterData = File.ReadAllLines(path);

            var alignment = new List<string> { "lawful", "chaotic", "neutral" };
            var goodness = new List<string> { "good", "neutral", "evil" };


            var namesByAlignment = new List<string>[3, 3];
            var namesOfUnaligned = new List<string>();
            var namesOfAnyAlignment = new List<string>();
            var namesOfSpecialCases = new List<string>();

            for (int axis1 = 0; axis1 < 3; axis1++)
                for (int axis2 = 0; axis2 < 3; axis2++)
                    namesByAlignment[axis1, axis2] = new List<string>();

            string alignmentPattern = "(lawful|neutral|chaotic) (good|neutral|evil)$";

            CreateTheDifferantLists(monsterData, namesByAlignment, namesOfUnaligned, namesOfAnyAlignment, namesOfSpecialCases, alignment, goodness, alignmentPattern);
            PrintAllMonsters(monsterData, namesByAlignment, namesOfUnaligned, namesOfAnyAlignment, namesOfSpecialCases, alignment, goodness);

        }

        public static void PrintAllMonsters(string[] monsterData, List<string>[,] namesByAlignment, List<string> namesOfUnaligned, List<string> namesOfAnyAlignment, List<string> namesOfSpecialCases, List<string> alignment, List<string> goodness)
        {
            for (int axis1 = 0; axis1 < 3; axis1++)
            {
                for (int axis2 = 0; axis2 < 3; axis2++)
                {
                    if (alignment[axis1] == "neutral" && goodness[axis2] == "neutral")
                    {
                        Console.WriteLine($"Monsters with alignment true {goodness[axis2]} are:\n{string.Join("\n", namesByAlignment[axis1, axis2])}");
                    }
                    else
                    {
                        Console.WriteLine($"Monsters with alignment {alignment[axis1]} {goodness[axis2]} are:\n{string.Join("\n", namesByAlignment[axis1, axis2])}");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"Unaligned monsters are:\n{string.Join("\n", namesOfUnaligned)}");
            Console.WriteLine();
            Console.WriteLine($"Monsters which can be of any alignment are:\n{string.Join("\n", namesOfAnyAlignment)}");
            Console.WriteLine();
            Console.WriteLine($"Monsters with special cases are:\n{string.Join("\n", namesOfSpecialCases)}");
        }

        public static void CreateTheDifferantLists(string[] monsterData, List<string>[,] namesByAlignment, List<string> namesOfUnaligned, List<string> namesOfAnyAlignment, List<string> namesOfSpecialCases, List<string> alignment, List<string> goodness, string alignmentPattern)
        {
            int indexOfCertainMonstersData = 0;
            for (int i = 0; i < monsterData.Length; i++)
            {
                if (indexOfCertainMonstersData == 1)
                {
                    if (monsterData[i].Contains("unaligned"))
                    {
                        namesOfUnaligned.Add(monsterData[i - 1]);
                    }
                    else if (monsterData[i].Contains("any alignment"))
                    {
                        namesOfAnyAlignment.Add(monsterData[i - 1]);
                    }
                    else if (Regex.IsMatch(monsterData[i], alignmentPattern))
                    {
                        for (int axis1 = 0; axis1 < 3; axis1++)
                        {
                            if (monsterData[i].Contains(alignment[axis1]))
                            {
                                for (int axis2 = 0; axis2 < 3; axis2++)
                                {
                                    if (monsterData[i].Contains($"{alignment[axis1]} {goodness[axis2]}"))
                                    {
                                        namesByAlignment[axis1, axis2].Add(monsterData[i - 1]);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else if (!Regex.IsMatch(monsterData[i], alignmentPattern) && Regex.IsMatch(monsterData[i], @"neutral$"))
                    {
                        namesByAlignment[2, 1].Add(monsterData[i - 1]);
                    }
                    else
                    {
                        string[] specialCase = monsterData[i].Split(", ");
                        namesOfSpecialCases.Add($"{monsterData[i - 1]} ({specialCase[1]})");
                    }
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
        }
    }
}

