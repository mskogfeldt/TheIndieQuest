using System;
using System.Collections.Generic;
using System.IO;

namespace w6d1m1
{
    class Program
    {
        static void Main(string[] args)
        {
            string link = @"MonsterManual.txt";

            string[] monsterData = File.ReadAllLines(link);

            List<string> listOfMonsterNames = new List<string> { };

            List<bool> listOfMonsterFlyingAbilety = new List<bool> { };

            CreateListOfMonsterNames(listOfMonsterNames, monsterData);

            CreateListOfMonsterFlyingAbilety(listOfMonsterFlyingAbilety, monsterData);

            PringMonsterNamesAndFlytingAbilety(listOfMonsterNames, listOfMonsterFlyingAbilety);

            void PringMonsterNamesAndFlytingAbilety(List<string> monsterNames, List<bool> monsterFlyingAbilety)
            {
                Console.WriteLine("Monsters in the manual are");
                for (int i = 0; i < monsterNames.Count; i++)
                {
                    Console.WriteLine($"{listOfMonsterNames[i]} - Can fly: {monsterFlyingAbilety[i]}");
                }

            }

            /* List<string> CreateListOfMonsterNames(string[] listOfMonsterData)
             {
                 List<string> monsterNames = new List<string> { listOfMonsterData[0] };
                 for (int i = 1; i < listOfMonsterData.Length; i++)
                 {
                     if (listOfMonsterData[i - 1] == "")
                     {
                         listOfMonsterNames.Add(listOfMonsterData[i]);
                     }
                 }
                 return monsterNames;
             }
            
                List<bool> CreateListOfMonsterFlyingAbilety(string[] listOfMonsterData)
            {
                List<bool> monsterFlyingAbilety = new List<bool> { };
                {
                    for (int i = 1; i < listOfMonsterData.Length; i++)
                    {
                        if (listOfMonsterData[i - 1].Contains("Speed"))
                        {
                            if (listOfMonsterData[i - 1].Contains("fly"))
                            {
                                monsterFlyingAbilety.Add(true);
                            }
                            else
                            {
                                monsterFlyingAbilety.Add(false);
                            }
                        }
                    }
                }
                return monsterFlyingAbilety;
            }
             
             */
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

            void CreateListOfMonsterFlyingAbilety(List<bool> monsterFlyingAbilety, string[] listOfMonsterData)
            {
                for (int i = 1; i < listOfMonsterData.Length; i++)
                {
                    if (listOfMonsterData[i - 1].Contains("Speed"))
                    {
                        if (listOfMonsterData[i - 1].Contains("fly"))
                        {
                            monsterFlyingAbilety.Add(true);
                        }
                        else
                        {
                            monsterFlyingAbilety.Add(false);
                        }
                    }
                }
            }

        }
    }
}
