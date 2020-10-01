using System;

namespace tankBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int distanceToArtileryPice = 2;
            int tankDistance = random.Next(40, 71);
            int distanceBehindTank = 80 - tankDistance - distanceToArtileryPice;
            bool battleIsOn = true;

            Console.WriteLine("DANGER! A tank is approaching our position. Your artilery unit is our only hope!");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Here is a map of the battlefield:");
            Console.WriteLine();
            createBattleField();
            createSecondPartOfBattleField();

            void createBattleField()
                {
                Console.Write("_/");
                for (int i = 0; i < tankDistance; i++)
                {
                    Console.Write("_");
                }
                Console.Write("T");
            }

            void createSecondPartOfBattleField()
            {
                for (int i = 0; i < distanceBehindTank; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
            }

            void displayTheShoot(int shootsRange)
            {
                for (int i = 0; i < shootsRange + 2; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("*");
            }
            
            int makeGuessForRange()
            {
                Console.WriteLine("Aim your shot " + name + "!");
                string numberText = Console.ReadLine();
                int number = Int32.Parse(numberText);
                return number;
            }

            void calculateIfYouHit(int guessedNumber)
            {
                if (guessedNumber == tankDistance )
                {
                    Console.WriteLine("Great shot kid, thats one in a million");
                    battleIsOn = false;
                }
                else if(guessedNumber < tankDistance)
                {
                    Console.WriteLine("Oh no, your shot was to short");
                }
                else
                {
                Console.WriteLine("Alas, the shell flies past the tank");
                }
            }

            int tankMoves()
            {
                return random.Next(8, 15);
            }

            while(battleIsOn) 
            {
                int shotrange = makeGuessForRange();
                displayTheShoot(shotrange);
                calculateIfYouHit(shotrange);
                tankDistance -= tankMoves();
                if (tankDistance < 1)
                {
                    
                    Console.WriteLine("The tanks runs you over. You are as clumpsy as you are foolish, game over");
                    Console.WriteLine("You have time to say one last cool thing, what will it be");
                    string famoustLastWords = Console.ReadLine();
                    battleIsOn = false;

                }
                else
                {
                Console.Write($"Snap out of it {name}, press any Key fo show you are ready to do WWWWWWWWWWWWAAAARRRR!");
                string checkIfYouAreReady = Console.ReadLine();
                Console.Clear();
                createBattleField();
                createSecondPartOfBattleField();
                }
            }                     
        }
    }
}
