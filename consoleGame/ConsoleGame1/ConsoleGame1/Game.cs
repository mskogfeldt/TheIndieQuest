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
        public SpaceShip playersShip = new SpaceShip(30, 25/*,  1*/);
        public Meteor meteor = new Meteor(205, 25, -4, 0);
        //public int[,] whereItemsAreOnScreen = new int[,] { };
       // public List<GameObject> itemsInPlay = new List<GameObject> { };
        public List<SpaceShip> spaceShipsInPlay = new List<SpaceShip> { };
        public List<Meteor> meteorsInPlay = new List<Meteor> { };

        public void DrawTheSquare(int width, int height/* int leftEdge, int topEdge*/)
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
            //itemsInPlay.Add(meteor);
            int timeWhenNextMeteorWillSpawn = 0;
            int timePassed = 0;
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
                foreach(Meteor meteor in meteorsInPlay) 
                {
                    meteor.EraseImageOfMeteorsPreviousPosition2(width, height, leftEdge, topEdge);
                    meteor.MoveObject();
                    //meteor.DrawTheMeteor(width, height);
                    meteor.DrawTheMeteor2(width, height, leftEdge, topEdge);
                    if (meteor.IsPartOfTheMeteorInsideTheEdges(width, height, meteor.locationX, meteor.locationY, leftEdge, topEdge) == false) meteor.StopTheMeteor();
                    if (IsCollision(playersShip, meteor) == true) gameOver = true;
                }
                /*  
                  meteor.EraseImageOfMeteorsPreviousPosition2(width, height, leftEdge, topEdge);
                  meteor.MoveObject();
                  //meteor.DrawTheMeteor(width, height);
                  meteor.DrawTheMeteor2(width, height, leftEdge, topEdge);
                  if (meteor.IsPartOfTheMeteorInsideTheEdges(width, height, meteor.locationX, meteor.locationY, leftEdge, topEdge) == false) meteor.StopTheMeteor();
                  if (IsCollision(playersShip, meteor) == true) gameOver = true;*/
                if (IsPlayerAtEdge(playersShip) == true) gameOver = true;
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

        public bool IsPlayerAtEdge(SpaceShip playerShip)
        {
            if (playerShip.locationY == topEdge || playerShip.locationX == leftEdge ||  playerShip.locationY + playerShip.shape.Length == topEdge + height || playerShip.locationX + playerShip.shape[0].Length == leftEdge + width) return true;
            return false;
        }

        public void GameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");
        }

        public void SpawnMeteor() 
        {
            List<int> xCoordinateYCoordinate = RandomizeWhereMeteorSpawns();
            List<int> xVelocityYVelocity = new List<int> { };
            if (xCoordinateYCoordinate[0] == leftEdge + width - 1) xVelocityYVelocity = DetermineVelocityOfMeteorFromWest(xCoordinateYCoordinate[1]);
            else if (xCoordinateYCoordinate[1] == topEdge + 1) xVelocityYVelocity = DetermineVelocityOfMeteorFromNorthOrSouth(xCoordinateYCoordinate[0], "north");
            else xVelocityYVelocity = DetermineVelocityOfMeteorFromNorthOrSouth(xCoordinateYCoordinate[0], "south");
            meteorsInPlay.Add(new Meteor(xCoordinateYCoordinate[0], xCoordinateYCoordinate[1], xVelocityYVelocity[0], xVelocityYVelocity[1]));
        }

        public List<int> RandomizeWhereMeteorSpawns() 
        {
            List<int> startingCoordinatesForMeteorXY = new List<int> { };
            int direction = random.Next(1, 9);
            if (direction >= 1 && direction <= 4)
            {
                startingCoordinatesForMeteorXY.Add(leftEdge + width - 1);
                startingCoordinatesForMeteorXY.Add(DetermineYCoordinateForMeteorComingFromWest());
            }
            else if (direction >= 5 && direction <= 6)
            {
                startingCoordinatesForMeteorXY.Add(DetermineStartingXCoordinateForMeteorComingFromNorthOrSouth());
                startingCoordinatesForMeteorXY.Add(topEdge + height - 1);
            }
            else 
            {
                startingCoordinatesForMeteorXY.Add(DetermineStartingXCoordinateForMeteorComingFromNorthOrSouth());
                startingCoordinatesForMeteorXY.Add(topEdge + 1);
            } 
            return startingCoordinatesForMeteorXY;
        }

        public List<int> DetermineVelocityOfMeteorFromWest(int startingCoordinateY) 
        {
            int vevelosotyX = 0;
            int vevelosotyY = 0;
            List<int> vevelosotyXY = new List<int> { };
            if (startingCoordinateY <= (topEdge + height) / 4)
            {
                vevelosotyY = random.Next(0, 4);
                vevelosotyX = random.Next(-6, -4);
                vevelosotyXY.Add(vevelosotyX);
                vevelosotyXY.Add(vevelosotyY);
            }
            else if (startingCoordinateY > (topEdge + height) / 4 && startingCoordinateY <= (topEdge + height) / 2)
            {
                vevelosotyY = random.Next(-1, 3);
                vevelosotyX = random.Next(-6, -4);
                vevelosotyXY.Add(vevelosotyX);
                vevelosotyXY.Add(vevelosotyY);
            }
            else if (startingCoordinateY > (topEdge + height) / 2 && startingCoordinateY <= (topEdge + height) * 3 / 4) 
            {
                vevelosotyY = random.Next(-2, 2);
                vevelosotyX = random.Next(-6, -4);
                vevelosotyXY.Add(vevelosotyX);
                vevelosotyXY.Add(vevelosotyY);
            }
            else 
            {
                vevelosotyY = random.Next(-3, 1);
                vevelosotyX = random.Next(-6, -4);
                vevelosotyXY.Add(vevelosotyX);
                vevelosotyXY.Add(vevelosotyY);
            }
            return vevelosotyXY;
        }

        public List<int> DetermineVelocityOfMeteorFromNorthOrSouth(int startingCoordinateX, string northOrSouth)
        {
            int northOrSouthModifier = 0;
            if (northOrSouth == "north") northOrSouthModifier = 1;
            if (northOrSouth == "south") northOrSouthModifier = - 1;
            int vevelosotyX = 0;
            int vevelosotyY = 0;
            List<int> vevelosotyXY = new List<int> { };
            if (startingCoordinateX <= (leftEdge + width) / 4)
            {
                vevelosotyY = random.Next(2, 4) * northOrSouthModifier;
                vevelosotyX = random.Next(-4, -2);
                vevelosotyXY.Add(vevelosotyX);
                vevelosotyXY.Add(vevelosotyY);
            }
            else if (startingCoordinateX > (leftEdge + width) / 4 && startingCoordinateX <= (leftEdge + width) / 2)
            {
                vevelosotyY = random.Next(1, 3) * northOrSouthModifier;
                vevelosotyX = random.Next(-4, -2);
                vevelosotyXY.Add(vevelosotyX);
                vevelosotyXY.Add(vevelosotyY);
            }
            else if (startingCoordinateX > (leftEdge + width) / 2 && startingCoordinateX <= (leftEdge + width) * 3 / 4)
            {
                vevelosotyY = random.Next(-2, 0) * northOrSouthModifier;
                vevelosotyX = random.Next(-4, -2);
                vevelosotyXY.Add(vevelosotyX);
                vevelosotyXY.Add(vevelosotyY);
            }
            else
            {
                vevelosotyY = random.Next(-4, -1) * northOrSouthModifier;
                vevelosotyX = random.Next(-3, -1);
                vevelosotyXY.Add(vevelosotyX);
                vevelosotyXY.Add(vevelosotyY);
            }
            return vevelosotyXY;
        }


        // public int MaximumVelocity

        public int DetermineStartingXCoordinateForMeteorComingFromNorthOrSouth()
        {
            int minumumDistanceToSpawn = 10;
            return random.Next(leftEdge + minumumDistanceToSpawn, leftEdge + width);
        }

        public int DetermineYCoordinateForMeteorComingFromWest() 
        {
            return random.Next(topEdge + meteor.shape.Length, topEdge + height);
        }



     /*   public Meteor SpawnMeteor() 
        {
                    int temp = 0;
        }
        */
    }
}

