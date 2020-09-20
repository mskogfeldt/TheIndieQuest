using System;
using System.Collections.Generic;


namespace day5c
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var listOfCharacters = new List<string> { "Ronaldo", "Messi", "Zlatan", "Chippen" };
            var listOfMonsters = new List<string> { "Orc", "Wizzard", "Troll" };
            var listOfMonsterHp = createMonsterHp();
            var listOfDodgeValuesFromMonsterAttacs = new List<int> {12, 20, 18 };

            List<int> createMonsterHp()
            {
                var simulatedHps = new List<int>{ };
                int simulateHpOrcHp = diceSimulator(2, 8, 6);
                int simulatedWizzardHp = diceSimulator(9, 8, 0);
                int simulatedTrollHp = diceSimulator(8, 10, 20);
                simulatedHps.Add(simulateHpOrcHp);
                simulatedHps.Add(simulatedWizzardHp);
                simulatedHps.Add(simulatedTrollHp);
                return simulatedHps;

            }
        
            textToStartTheGame();
            metodToRunTheGame();

            void metodToRunTheGame()
            {
                pressentEnemys(listOfMonsters[0], listOfMonsterHp[0]);
                battleMonster(listOfCharacters, listOfMonsters[0], listOfMonsterHp[0], listOfDodgeValuesFromMonsterAttacs[0]);
            }

         

            void battleMonster(List<string> heros, string monsterName, int monsterHp, int chanseToDodgeMonster)
            {
                bool letsFight = true;
                int indexOfHeros = 0;

                while(letsFight)
                {
                    int damage = attackEnemys();
                    monsterHp -= damage;
                   
                    if (monsterHp <= 0)
                    {
                        letsFight = false;
                        describeKillOnEnemy(listOfCharacters[0], monsterName, damage);
                        deleteFirstStringInList(listOfMonsters);
                        deleteFirstIntInList(listOfMonsterHp);
                        deleteFirstIntInList(listOfDodgeValuesFromMonsterAttacs);
                        rotateHerosRightAfterFight(heros);
                        if (checkIfThereAreStringsInList(listOfMonsters) == true)
                        {
                            metodToRunTheGame();                        
                        }
                        else
                        {
                            string survivingHeros = returnSurvivingHerosText(listOfCharacters);
                            gameEndsHappily(survivingHeros);
                        }
                    }
                    else
                    {
                        describeAttacksOnEnemy(listOfCharacters[0], monsterName, damage, monsterHp);
                        rotateListToTheLeft(heros);
                        if (indexOfHeros == heros.Count - 1) 
                        {
                            int indexOfAttackedHero = randomStringInListIndex(heros) -1;
                            describeAttemtedAttackFromEnemy(monsterName, heros[indexOfAttackedHero]);
                            int dodgeRoll = diceSimulator(1, 20, 5);
                            if (dodgeEnemyAttack(chanseToDodgeMonster, dodgeRoll) == true)
                            {
                                describeFailedAttackFromEnemy(heros[indexOfAttackedHero], dodgeRoll);
                            }
                            else
                            {
                                describeSucsessfulAttackFromEnemy(heros[indexOfAttackedHero], dodgeRoll);
                                deleteCertanStringInList(heros, indexOfAttackedHero);
                                if(checkIfThereAreStringsInList(heros) == false)
                                {
                                    describeGameOver(monsterName);
                                    letsFight = false;
                                }
                            }
                            indexOfHeros = 0;
                        }
                        else
                        {
                            indexOfHeros += 1;
                        }
                    }
                   
                }

            }

            int diceSimulator(int numberOfDices, int sidesOfDice, int fixedBonus)
            {
                int dicescore = 0;
                for (int i = 0; i < numberOfDices; i++)
                {
                    dicescore += random.Next(1, sidesOfDice + 1);
                }
                dicescore += fixedBonus;
                return dicescore;
            }

            int simulateDice(int sizeOfDice)
            {
                int dicetrow = random.Next(1, sizeOfDice);
                return dicetrow;
            }


            int attackEnemys()
            {
                int damage = diceSimulator(2, 6, 0);
                return damage;
            }

            int randomStringInListIndex(List<string> listOfHeros)
            {
                int index = random.Next(1, listOfHeros.Count);
                return index;
            }


            void textToStartTheGame()
            {
                Console.WriteLine($"A party of warriors ({listOfCharacters[0]}, {listOfCharacters[1]}, {listOfCharacters[2]}, {listOfCharacters[3]}) descends into the dungeon.");
            }
            
            List<string> rotateListToTheLeft(List<string> items)
            {    
                items.Add(items[0]);
                items.RemoveAt(0);
                return items;
            }

            List<string> deleteCertanStringInList(List<string> items, int index)
            {
                items.RemoveAt(index);
                return items;
            }

            List<string> deleteFirstStringInList(List<string> items)
            {
                items.RemoveAt(0);
                return items;
            }

            List<int> deleteFirstIntInList(List<int> items)
            {
                items.RemoveAt(0);
                return items;
            }


            void describeAttacksOnEnemy(string hero, string monster, int damage, int hp)
            {
                Console.WriteLine($"{hero} hits the {monster} for {damage} damage. The {monster} has {hp} HP left.");
            }

            void describeKillOnEnemy(string hero, string monster, int damage)
            {
                Console.WriteLine($"{hero} hits the {monster} for {damage} damage. The {monster} has 0 HP left.");
                Console.WriteLine($"The {monster} collapses and the heroes celebrate their victory!");
            }

            void describeAttemtedAttackFromEnemy(string monster, string hero)
            {
                Console.WriteLine($"The {monster} attacks {hero}!");
            }

            void describeFailedAttackFromEnemy(string hero, int diceroll)
            {
                Console.WriteLine($"{hero} rolls a {diceroll} and is saved from the attack.");
            }

            void describeSucsessfulAttackFromEnemy(string hero, int dodgeRoll)
            {
                Console.WriteLine($"{hero} rolls a {dodgeRoll} and fails to be saved. {hero} is killed.");
            }

            void describeGameOver(string monster)
            {
                Console.WriteLine($"The party has failed and the {monster} continues to attack unsuspecting adventurers.");
            }

            Boolean dodgeEnemyAttack(int monsterDr, int dodgeRoll)
            {
                if (dodgeRoll >= monsterDr)
                    {
                    return true;
                }
                return false;
            }

            string returnSurvivingHerosText(List<string> listOfCharacters)
            {
                string heros = "";
                string and = " and ";
                string comma = ", ";
                int checkForCommaAndAnd = listOfCharacters.Count -1;
                for (int i = 0; i < listOfCharacters.Count; i++)
                {
                    heros += listOfCharacters[i];
                    if (checkForCommaAndAnd == 1)
                    {
                        heros += and;
                    }
                    else
                    {
                    if (checkForCommaAndAnd >= 2)
                        {
                            heros += comma;
                        }
                    }
                    checkForCommaAndAnd -= 1;
                }
                return heros;
            }
            
            void gameEndsHappily(string survivingHeros)
            {
                Console.Write($"After three grueling battles, {survivingHeros} returns from the dungeons. ");
                
                if (listOfCharacters.Count < 4)
                {
                    Console.WriteLine("Unfortunately, none of the other party members survived.");
                }
                else
                {
                    Console.WriteLine("");
                }
            }

            void writeCredits()
            {
                Console.WriteLine("Script: Matej Jan");
                Console.WriteLine("Programing: Mats Skogfeldt");
            }

            void pressentEnemys(string enemy, int hp)
            {
                Console.WriteLine($"Watch out, {enemy} with {hp} HP appears!");
            }

            bool checkIfThereAreStringsInList(List<string> items)
            {
                if (items.Count > 0)
                {
                    return true;
                }
                return false;
            }
            
            void rotateHerosRightAfterFight(List<string> heros)
            {
                if (heros.Contains("Ronaldo"))
                {
                    while (heros[0] != "Ronaldo")
                    {
                        rotateListToTheLeft(heros);
                    }
                }
                else
                {
                    if (heros.Contains("Messi"))
                    {
                        while (heros[0] != "Messi")
                        {
                            rotateListToTheLeft(heros);
                        }
                    }
                    else
                    {
                        if (heros.Contains("Zlatan"))
                        {
                            while (heros[0] != "Zlatan")
                            {
                                rotateListToTheLeft(heros);
                            }
                        }
                    }

                }

            }
           
        }
        }
}


