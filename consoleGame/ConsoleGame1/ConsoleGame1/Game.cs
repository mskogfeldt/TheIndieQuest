using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class Game
    {
        public Random random = new Random();
        public ConsoleKeyInfo info;
        public string[] meteorShape = new string[] { };
        public string[] shipShape = new string[] { };
        public SpaceShip playersShip = new SpaceShip(5, 25/*,  1*/);
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
                        Console.ForegroundColor = ConsoleColor.Blue;
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
                        Console.ForegroundColor = ConsoleColor.Blue;
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
                if (IsCollision(playersShip, meteor) == true) gameOver = true;
                if (IsEdgePlayer(playersShip) == true) gameOver = true;
                if (gameOver == true) GameOver();
            }
        }

        public List<GameObject> createListOfObjectsColidingWithSertainObject()
        {
            List<GameObject> sdfsdf = new List<GameObject> { };
            return sdfsdf;
        }

        public bool IsCollision(SpaceShip gameObjectOne, Meteor gameObjectTwo)
        {
            for (int y = 0; y < gameObjectOne.shape.Length; y++)
            {
                for (int x = 0; x < gameObjectOne.shape[0].Length; x++)
                {
                    if (CheckCoordinatesAndCompareToOtherObjectsCoordinatesAndSeeThatTheyAreNotSpace(gameObjectOne.locationX + x, gameObjectOne.locationY + y, gameObjectOne, gameObjectTwo) == true) return true;
                }
            }
            return false;
        }

        public bool CheckCoordinatesAndCompareToOtherObjectsCoordinatesAndSeeThatTheyAreNotSpace(int xCoordinate, int yCoordinate, SpaceShip spaceShip, Meteor meteor)
        {
            for (int y = 0; y < meteor.shape.Length; y++)
            {
                for (int x = 0; x < meteor.shape[0].Length; x++)
                {
                    if (meteor.locationX + x == xCoordinate && meteor.locationY + y == yCoordinate && spaceShip.shape[yCoordinate][xCoordinate] != ' ' && meteor.shape[y][x] != ' ') return true;
                }
            }
            return false;
        }

    /*    public bool CheckIfEitherCharIsEmpty(int xCoordinate, int yCoordinate, SpaceShip spaceShip ,Meteor meteor)
        {
            if (meteor.shape[] + x == xCoordinate && meteor.locationY + y == yCoordinate) return true;)
        }*/

        public bool IsEdge(List<GameObject> gameObject)
        {
            foreach (GameObject objectInQuestion in gameObject)
            {
                if (objectInQuestion.locationX == 1 || objectInQuestion.locationX == 200 || objectInQuestion.locationY == 1 || objectInQuestion.locationY == 50) return true;
            }
            return false;
        }

        public bool IsEdgePlayer(SpaceShip spaceShip)
        {
            if (spaceShip.locationX == 1 || spaceShip.locationX == 200 || spaceShip.locationY == 1 || spaceShip.locationY == 50) return true;
            return false;
        }

        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER!");
        }

    }
}

