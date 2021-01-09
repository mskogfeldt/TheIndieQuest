using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace w6d1m3
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

            CreateListOfMonsterWhoRollsTenOrMoreDiceForHp(listOfMonsterWhoRollsTenOrMoreDiceForHp, monsterData);

            PringMonsterNamesAndHpRolls(listOfMonsterNames, listOfMonsterWhoRollsTenOrMoreDiceForHp);

            void PringMonsterNamesAndHpRolls(List<string> monsterNames, List<bool> monsterHpRolls)
            {
                Console.WriteLine("Monsters in the manual are");
                for (int i = 0; i < monsterNames.Count; i++)
                {
                    Console.WriteLine($"{monsterNames[i]} - 10+ dice rolls: {monsterHpRolls[i]}");
                }

            }


            void CreateListOfMonsterNames(List<string> monsterNames, string[] listOfMonsterData)
            {
                for (int i = 1; i < listOfMonsterData.Length; i++)
                {
                    if (listOfMonsterData[i - 1] == "")
                    {
                        listOfMonsterNames.Add(listOfMonsterData[i]);
                    }
                }
            }

            void CreateListOfMonsterWhoRollsTenOrMoreDiceForHp(List<bool> monsterHp, string[] listOfMonsterData)
            {
                string tenOrMoreRolls = "\\d\\dd";

                for (int i = 1; i < listOfMonsterData.Length; i++)
                {
                    if (monsterData[i - 1].Contains("Hit Points"))
                    {
                        if (Regex.IsMatch(monsterData[i - 1], tenOrMoreRolls))
                        {
                            monsterHp.Add(true);
                        }
                        else
                        {
                            monsterHp.Add(false);
                        }
                    }
                }

            }
        }
    }
}
