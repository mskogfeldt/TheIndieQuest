using System;
using System.Collections.Generic;

namespace day4master
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var random = new Random();


                bool letsFight = true;
                var listOfCharacters = new List<String> { "Ronaldo", "Messi", "Zlatan", "Chippen" };
                int basiliskHp = 16;
                int indewOfAttackingChar = 0;


                for (int i = 0; i <= 8; i++)
                {
                    basiliskHp += random.Next(1, 9);
                }
                Console.WriteLine($"A party of warriors ({listOfCharacters[0]}, {listOfCharacters[1]}, {listOfCharacters[2]}, {listOfCharacters[3]}) descends into the dungeon.");
                Console.WriteLine($"A basilisk with {basiliskHp} HP appears!");

                while (letsFight)
                //for (int i = 0; i <= basiliskHp; i++)
                {
                    int greatsword = random.Next(1, 5);

                    Console.Write($"{listOfCharacters[0]} hits the basilisk for {greatsword} damage. ");
                    basiliskHp -= greatsword;
                    if (basiliskHp <= 0)
                    {
                        Console.WriteLine("Basilisk has 0 HP left. ");
                        Console.WriteLine("The basilisk collapses and the heroes celebrate their victory!");
                        letsFight = false;
                    }
                    else
                    {
                        Console.WriteLine($"Basilisk has {basiliskHp} HP left. ");
                    }
                    listOfCharacters.Add(listOfCharacters[0]);
                    listOfCharacters.RemoveAt(0);
                    if (indewOfAttackingChar == listOfCharacters.Count -1 && basiliskHp > 0)
                    {
                        indewOfAttackingChar = 0;
                        int gazeRandom = random.Next(0, listOfCharacters.Count);
                        Console.WriteLine($"The basilisk uses petrifying gaze on {listOfCharacters[gazeRandom]}!");
                        int avoidGaze = random.Next(1, 21);

                        if (avoidGaze < 12)
                        {
                            Console.WriteLine($"{listOfCharacters[gazeRandom]} rolls a {avoidGaze} and fails to be saved. {listOfCharacters[gazeRandom]} is turned into stone.");
                            listOfCharacters.RemoveAt(gazeRandom);
                            if (listOfCharacters.Count == 0)
                            {
                                Console.WriteLine("The party has failed and the basilisk continues to turn unsuspecting adventurers to stone.");
                                letsFight = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{listOfCharacters[gazeRandom]} rolls a {avoidGaze} and is saved from the attack.");
                        }
                    }
                    else
                    {
                        indewOfAttackingChar += 1; 
                    }



                }



            }
        }
    }
}
