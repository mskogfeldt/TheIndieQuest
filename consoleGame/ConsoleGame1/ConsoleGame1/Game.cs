using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class Game
    {
        public Random random = new Random();
        public ConsoleKeyInfo info;
        public SpaceShip playersShip = new SpaceShip(5, 25/*, 1*/);
        public Meteor meteor = new Meteor(80, 25, -1, 0);
        public int[,] whereItemsAreOnScreen = new int[,] { };
        public List<GameObject> itemsInPlay = new List<GameObject> { };
        public List<SpaceShip> spaceShipsInPlay = new List<SpaceShip> { };
        public List<Meteor> meteorsInPlay = new List<Meteor> { };


        public void drawTheSquare(int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y == 0 || y == height - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (x == 0 || x == width - 1)
                        {
                            Console.Write("+");
                        }
                        else
                        {
                            Console.Write("-");
                        }
                    }
                    else if (x == 0 || x == width - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
/*
        public Meteor spawnMeteor()
        {
            int atleastTravelingOneDirection = random.Next(1, 10);
            if()
            int velocityX = random.Next(0,1)
            Meteor meteor = new Meteor()

        }*/

        public void RunTheGame()
        {
            itemsInPlay.Add(meteor);
            spaceShipsInPlay.Add(playersShip);
            meteorsInPlay.Add(meteor);
            //System.Threading.Thread.Sleep(1000 / sv_settings.fps);
            /*while (System.Console.KeyAvailable)
				{
					var _key = System.Console.ReadKey(true);*/
            bool gameOver = false;

            while (gameOver == false)
            {
                //playersShip.EraseImageOfShipsPreviousPosition();
                System.Threading.Thread.Sleep(1000 / 10);

                while (System.Console.KeyAvailable)
                {
                    var key = System.Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case System.ConsoleKey.LeftArrow:
                            {
                                playersShip.velocityX--;
                            }
                            break;
                        case System.ConsoleKey.RightArrow:
                            {
                                playersShip.velocityX++;
                            }
                            break;
                        case System.ConsoleKey.UpArrow:
                            {
                                playersShip.velocityY--;
                            }
                            break;
                        case System.ConsoleKey.DownArrow:
                            {
                                playersShip.velocityY++;
                            }
                            break;

                    }
                }
                playersShip.EraseImageOfShipsPreviousPosition();
                playersShip.MoveObject(); 
                playersShip.DrawTheSpaceShip();
                meteor.EraseImageOfMeteorsPreviousPosition();
                meteor.MoveObject();
                meteor.DrawTheMeteor();
                if (isColliton(playersShip, itemsInPlay) == true) gameOver = true;
                if (gameOver == true) GameOver();

            }
        }

        public List<GameObject> createListOfObjectsColidingWithSertainObject()
        {
            List<GameObject> sdfsdf = new List<GameObject> { };
            return sdfsdf;
        }

        public bool isColliton(SpaceShip playrShip, List<GameObject> gameObject)
        {
            foreach (GameObject objectInQuestion in gameObject)
                {
                if (objectInQuestion.locationX == playersShip.locationX && objectInQuestion.locationY == playersShip.locationY) return true;
                }
            return false;
        }

        public bool isEdge(List<GameObject> gameObject) 
        {
            foreach (GameObject objectInQuestion in gameObject)
            {
                if (objectInQuestion.locationX == playersShip.locationX && objectInQuestion.locationY == playersShip.locationY) return true;
            }
            return false;
        }


        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER!");
        }
       
    }
}

