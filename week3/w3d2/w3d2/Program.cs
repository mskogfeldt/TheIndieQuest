using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace w3d2
{
    class Program
    {
        static void Main(string[] args)
        {

            var symbols = "!@#$%^&*()_+-=[];',.\\/~{}:|<>?";
            var random = new Random();

            int riverLeftedge = 0;

            int withOfMap = 80;
            int heightOfMap = 30;
            var coordinatesForRiver = GenerateCoordinatesForRiver(withOfMap, heightOfMap);
            var shapeOfRiver = GenerateShapeOfRiver(withOfMap, heightOfMap, coordinatesForRiver);
            var roadCordinates = GenerateCoordinatesForRoad(withOfMap, heightOfMap, coordinatesForRiver);
            drawTheSquare(withOfMap, heightOfMap, coordinatesForRiver, shapeOfRiver, roadCordinates);


            var listOfRiversLeftEdge = new List<int> { };
            var listOfRiversForm = new List<string> { };



            List<int> GenerateCoordinatesForRiver(int width, int height)
            {
                int startingModifier = random.Next(1, 5);
                int latestPositionOfRiver = width * 3 / 4 + startingModifier;
                int willRiverTurn = 0;
                var coordinatesForRiver = new List<int> { };
                for (int i = 0; i < height - 1; i++)
                {
                    willRiverTurn = random.Next(1, 4);
                    if (willRiverTurn == 2 && latestPositionOfRiver > width * 2 / 3)
                    {
                        latestPositionOfRiver -= 1;
                        coordinatesForRiver.Add(latestPositionOfRiver);
                    }
                    else if (willRiverTurn == 3 && latestPositionOfRiver < width * 5 / 6)
                    {
                        latestPositionOfRiver += 1;
                        coordinatesForRiver.Add(latestPositionOfRiver);
                    }
                    else
                    {
                        coordinatesForRiver.Add(latestPositionOfRiver);
                    }

                }
                return coordinatesForRiver;
            }

            List<int> GenerateCoordinatesForBridgeX(int width, int height, List<int> coordinatesForRiver, List<int> coordinatesForRoad)
            {
               
                var coordinatesForBridge = new List<int> { };
                for (int i = 0; i < width - 1; i++)
                {
                    {// (i + 5 - coordinatesForRiver[latestPositionOfRoad] < 1 && i + 5 - coordinatesForRiver[latestPositionOfRoad] > -3)
                        if ()
                        coordinatesForRoad.Add(coordinatesForBridge);
                    }

                }
                return coordinatesForBridge;
            }

            List<int> GenerateCoordinatesForRoad(int width, int height, List<int> coordinatesForRiver)
            {
                int startingModifier = random.Next(-2, 2);
                int latestPositionOfRoad = height * 1 / 2 + startingModifier;
                int willRoadTurn = 0;
                bool crossingWater = false;
                int numberToSayHowLongTheRoadWillBeStraitWhenCrossingWater = 10;
                var coordinatesForRoad = new List<int> { };
                for (int i = 0; i < width - 1; i++)
                {
                    willRoadTurn = random.Next(1, 6);
                    if (crossingWater == true)
                    {
                        coordinatesForRoad.Add(latestPositionOfRoad);
                        numberToSayHowLongTheRoadWillBeStraitWhenCrossingWater -= 1;
                        if (numberToSayHowLongTheRoadWillBeStraitWhenCrossingWater < 1)
                        {
                            crossingWater = false;
                        }
                    }
                    else if (i + 5 - coordinatesForRiver[latestPositionOfRoad] < 1 && i + 5 - coordinatesForRiver[latestPositionOfRoad] > -3)
                    {
                        crossingWater = true;
                        coordinatesForRoad.Add(latestPositionOfRoad);
                    }
                    else if (willRoadTurn == 4 && latestPositionOfRoad > height * 1 / 3)
                    {
                        latestPositionOfRoad -= 1;
                        coordinatesForRoad.Add(latestPositionOfRoad);
                    }
                    else if (willRoadTurn == 5 && latestPositionOfRoad < height * 2 / 3)
                    {
                        latestPositionOfRoad += 1;
                        coordinatesForRoad.Add(latestPositionOfRoad);
                    }
                    else
                    {
                        coordinatesForRoad.Add(latestPositionOfRoad);
                    }

                }
                return coordinatesForRoad;
            }
            /*
                        List<int> GenerateCoordinatesForRoadCrossingRiver(int width, int height, List< int> road, List<int> river)
                        {
                            for (int i = 0; i < width - 1; i++)
                            {

                            }
                        }*/

            List<string> GenerateShapeOfRiver(int widt, int height, List<int> coordinatesForRiver)
            {
                string riversStrait = "|";
                string riverTurnsLeft = "/";
                string riverTurnsRight = @"\";
                var listForShapeOfRiver = new List<string> { };

                for (int i = 0; i < coordinatesForRiver.Count - 1; i++)
                {
                    if (coordinatesForRiver[i] < coordinatesForRiver[i + 1])
                    {
                        listForShapeOfRiver.Add(riverTurnsRight);
                    }
                    else if (coordinatesForRiver[i] > coordinatesForRiver[i + 1])
                    {
                        listForShapeOfRiver.Add(riverTurnsLeft);
                    }
                    else
                    {
                        listForShapeOfRiver.Add(riversStrait);
                    }
                }
                listForShapeOfRiver.Add(riversStrait);
                return listForShapeOfRiver;
            }



            //symbols[random.Next(symbols.Length)]
            //drawTheSquare(50, 20);
            string randomiseSymbol()
            {
                int indexOfSymbolToReturn = random.Next(0, symbols.Length);
                return symbols[indexOfSymbolToReturn].ToString();
            }
            // drawHorisontalLine(30);
            // drawVerticalLine(10);
            // String writeLineTopAndBottom = drawTopAndBotom(width);
            //String writeLineMiddle = drawTheHorisontalLinesMiddle(width);
            // Console.WriteLine(drawTopAndBotom);
            void drawTheSquare(int width, int height, List<int> coordinatsForRiver, List<string> shapeOfRiver, List<int> coordinatsForRoad)
            {
                int treeBoundry = 0;
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
                        } //(x == coordinatsForRiver[y]

                        else if (y == coordinatsForRoad[x])
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("#");
                        }
                        else if ((x == 1 || x == 2))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            string toWrite = randomiseSymbol();
                            Console.Write(toWrite);
                        }
                        else if (x == coordinatsForRiver[y] || x - 1 == coordinatsForRiver[y] || x - 2 == coordinatsForRiver[y])
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(shapeOfRiver[y]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ");
                        }


                    }
                    Console.WriteLine();


                }
                Console.ForegroundColor = ConsoleColor.White;

            }

        }

    }
}


