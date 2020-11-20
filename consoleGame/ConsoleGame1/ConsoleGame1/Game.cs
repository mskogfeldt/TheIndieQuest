using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class Game
    {
        public int width = 200;
        public int height = 49;
        public int leftEdge = 16;
        public int topEdge = 8;
        public Random random = new Random();
        /*public ConsoleKeyInfo info;
        public string[] meteorShape = new string[] { };
        public string[] shipShape = new string[] { };*/
        public SpaceShip playersShip = new SpaceShip(5, 25/*,  1*/);
        public Meteor meteor = new Meteor(205, 25, -1, 0);
        public int[,] whereItemsAreOnScreen = new int[,] { };
        public List<GameObject> itemsInPlay = new List<GameObject> { };
        public List<SpaceShip> spaceShipsInPlay = new List<SpaceShip> { };
        public List<Meteor> meteorsInPlay = new List<Meteor> { };

        public void drawTheSquare(int width, int height/* int leftEdge, int topEdge*/)
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
                           // Console.BackgroundColor = ConsoleColor.DarkBlue;
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

        public void drawTheSquare2(int width, int height, int leftEdge, int topEdge)
        {
            for (int y = 0; y < topEdge + height; y++)
            {
                for (int x = 0; x < leftEdge + width; x++)
                {
                    if ( /*y > topEdge && x > leftEdge &&*/ y == topEdge || y == topEdge + height - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        if (x == leftEdge || x == leftEdge + width - 1)
                        {
                            // Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("+");
                        }
                        else if (x < leftEdge)
                        {
                            Console.Write(" ");
                        }
                        else if(x > leftEdge + width)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("-");
                        }
                    }
                    else if (y > topEdge && x == leftEdge || y > topEdge && x == leftEdge + width - 1)
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

        public void drawTheSquare3(int width, int height, int leftEdge, int topEdge)
        {
            for (int y = 0; y < topEdge + height; y++)
            {
                for (int x = 0; x < leftEdge + width; x++)
                {
                    if ( /*y > topEdge && x > leftEdge &&*/ y == topEdge || y == topEdge + height - 1 || x == leftEdge || x == leftEdge + width - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" ");
                    }
                    else 
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
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
                //playersShip.EraseImageOfShipsPreviousPosition(width, height);
                playersShip.EraseImageOfSpaceShipsPreviousPosition(width, height, leftEdge, topEdge);
                playersShip.MoveObject();
                //playersShip.DrawTheSpaceShipII(width, height);
                playersShip.DrawTheSpaceShipII2(width, height, leftEdge, topEdge);
                //meteor.EraseImageOfMeteorsPreviousPosition(width, height);
                meteor.EraseImageOfMeteorsPreviousPosition2(width, height, leftEdge, topEdge);
                meteor.MoveObject();
                //meteor.DrawTheMeteor(width, height);
                meteor.DrawTheMeteor2(width, height, leftEdge, topEdge);
                if (meteor.IsPartOfTheMeteorInsideTheEdges(width, height, meteor.locationX, meteor.locationY, leftEdge, topEdge) == false) meteor.StopTheMeteor();
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
                    if (gameObjectOne.shape[y][x] != ' ' &&  CheckCoordinatesAndCompareToOtherObjectsCoordinatesAndSeeThatTheyAreNotSpace(gameObjectOne.locationX + x, gameObjectOne.locationY + y, gameObjectTwo) == true) return true;
                }
            }
            return false;
        }

        public bool CheckCoordinatesAndCompareToOtherObjectsCoordinatesAndSeeThatTheyAreNotSpace(int xCoordinate, int yCoordinate, Meteor meteor)
        {
            for (int y = 0; y < meteor.shape.Length; y++)
            {
                for (int x = 0; x < meteor.shape[0].Length; x++)
                {
                    if (meteor.shape[y][x] != ' ' && meteor.locationX + x == xCoordinate && meteor.locationY + y == yCoordinate ) return true;
                }
            }
            return false;
        }

        public bool IsEdge(List<GameObject> gameObject)
        {
            foreach (GameObject objectInQuestion in gameObject)
            {
                if (objectInQuestion.locationX == 1 || objectInQuestion.locationX == 200 || objectInQuestion.locationY == 1 || objectInQuestion.locationY == 50) return true;
            }
            return false;
        }

        public bool IsEdgePlayer(SpaceShip playerShip)
        {
            if (playerShip.locationY == 1 || playerShip.locationX == 1 || playerShip.locationY + playerShip.shape.Length == 50 || playerShip.locationX + playerShip.shape[0].Length == 200) return true;
            
            /*for (int y = 0; y < gameObjectOne.shape.Length; y++)
            {
                for (int x = 0; x < gameObjectOne.shape[0].Length; x++)
                {
                    if (gameObjectOne.shape[y][x] != ' ' && gameObjectOne.locationX <= 1 || gameObjectOne.shape[y][x] != ' ' && gameObjectOne.locationX >= 100 ||) return true;

                }
            }*/
            return false;
            /* if (spaceShip.locationX == 1 || spaceShip.locationX == 200 || spaceShip.locationY == 1 || spaceShip.locationY == 50) return true;
            return false;*/
        }

        public bool IsEdgePlayer2(SpaceShip playerShip)
        {
            if (playerShip.locationY == topEdge || playerShip.locationX == leftEdge || topEdge + playerShip.locationY + playerShip.shape.Length == height || leftEdge + playerShip.locationX + playerShip.shape[0].Length == width) return true;
            return false;
        }

        public void GameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");
        }

    }
}

