using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace w6d1m4
{
    class Program
    {
        static void Main(string[] args)
        {
            string link = @"MonsterManual.txt";

            string[] monsterData = File.ReadAllLines(link);

            List<string> listOfMonsterNames = new List<string> { monsterData[0] };

            List<bool> listOfMonsterWhoRollsTenOrMoreDiceForHp = new List<bool> { };

            CreateListOfMonsterNames(listOfMonsterNames, monsterData);

            

            PringMonsterNames(listOfMonsterNames);

            void PringMonsterNames(List<string> monsterNames)
            {
                Console.WriteLine("Monsters that can fly 10-40 feet per turn:");
                for (int i = 0; i < monsterNames.Count; i++)
                {
                    Console.WriteLine($"{monsterNames[i]}");
                }


            }

            void CreateListOfMonsterNames(List<string> monsterNames, string[] listOfMonsterData)
            {
                string flySpeedFom10To39 = "fly [1-3][0-9][^\\d]";
                string flySpeed40 = "fly 40[^\\d]";

                for (int i = 1; i < listOfMonsterData.Length; i++)
                {
                    if (listOfMonsterData[i].Contains("Speed"))
                    {
                        if (Regex.IsMatch(listOfMonsterData[i], flySpeedFom10To39) || Regex.IsMatch(listOfMonsterData[i], flySpeed40))
                        {
                            listOfMonsterNames.Add(listOfMonsterData[i - 4]);
                        }
                    }
                }
            }

            
        }
    }
}
