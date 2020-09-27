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

            int withOfMap = 80;
            int heightOfMap = 30;
            var coordinatesForRiver = GenerateCoordinatesForRiver(withOfMap, heightOfMap);
            var shapeOfRiver = GenerateShapeOfRiver(withOfMap, heightOfMap, coordinatesForRiver);
            var roadCoordinates = GenerateCoordinatesForRoad(withOfMap, heightOfMap, coordinatesForRiver);
            var bridgeCoordinates = GenerateCoordinatesForBridge(withOfMap, coordinatesForRiver, roadCoordinates);
           //var secondRoad = GenerateCoordinatesForSecondRoad(heightOfMap, coordinatesForRiver, roadCoordinates);
            drawTheSquare(withOfMap, heightOfMap, coordinatesForRiver, shapeOfRiver, roadCoordinates, bridgeCoordinates);
            


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

            List<int> GenerateCoordinatesForBridge(int width, List<int> coordinatesForRiver, List<int> coordinatesForRoad)
            {
                var coordinatesForBridge = new List<int> { };
                for (int x = 0; x < width - 1; x++)
                {
                    int theValueOfRoad = coordinatesForRoad[x];

                    if (x == coordinatesForRiver[theValueOfRoad])
                    {
                        coordinatesForBridge.Add(x - 2);
                        coordinatesForBridge.Add(coordinatesForRoad[x] - 1);
                        coordinatesForBridge.Add(coordinatesForRoad[x] + 1);
                    }
                }
                return coordinatesForBridge;
            }

            int findCoordinateWheraRiverMeetsRoad(int height, List<int> coordinatesForRiver, List<int> coordinatesForRoad)
            {
                for (int y = 0; y < height; y++)
                {
                    int theValueOfRiver = coordinatesForRiver[y];
                    if (y == coordinatesForRoad[theValueOfRiver])
                    {
                        return y;
                    }
                }
                return height + 1; 
            }
            
   /*         
            List<int> GenerateCoordinatesForSecondRoad(int height, List<int> coordinatesForRiver, List<int> coordinatesForRoad)
            {
                var coordinatesForSecondRoad = new List<int> { };
                bool secondRoadStarts = false;
                int hoolabaloo = 0;
                for (int y = 0; y < height; y++)
                {
                    int theValueOfRiver = coordinatesForRiver[y];
                    if (y == coordinatesForRoad[theValueOfRiver])
                    {
                        secondRoadStarts = true;
                        coordinatesForSecondRoad.Add(theValueOfRiver - 5);
                    }
                    else if (secondRoadStarts == true)
                    {
                        coordinatesForSecondRoad.Add(theValueOfRiver - 5);
                    }
                    else
                    {
                        hoolabaloo++;
                    }
                    
                }
                return coordinatesForSecondRoad;
            }*/


            string randomiseSymbol()
            {
                int indexOfSymbolToReturn = random.Next(0, symbols.Length);
                return symbols[indexOfSymbolToReturn].ToString();
            }
        
            void drawTheSquare(int width, int height, List<int> coordinatsForRiver, List<string> shapeOfRiver, List<int> coordinatsForRoad, List<int> coordinatesForTheBridge)
            {
                var printText = new List<string> { "A", "D", "V", "E", "N", "T", "U", "R", "E", " ", "M", "A", "P" };
                int centringspaces = (width - printText.Count) / 2;              
                int topBridgeLeft = 5;
                int lowerBridgeLeft = 5;
                int riverCrossig = findCoordinateWheraRiverMeetsRoad(height, coordinatesForRiver, coordinatsForRoad);
                bool keepOnBuildingTopBridge = false;
                bool keepOnBuildingLowerBridge = false;
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
                        else if (y == 2 && x >= centringspaces && printText.Count > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(printText[0]);
                            printText.RemoveAt(0);
                        }
                        else if (y == coordinatesForTheBridge[1] && x == coordinatesForTheBridge[0] )
                        {
                            keepOnBuildingTopBridge = true;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("=");
                        }
                        else if (y == coordinatesForTheBridge[2] && x == coordinatesForTheBridge[0])
                        {
                            keepOnBuildingLowerBridge = true;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("=");
                        }
                        else if (keepOnBuildingTopBridge == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("=");
                            topBridgeLeft --;
                            if (topBridgeLeft < 1)
                            {
                                keepOnBuildingTopBridge = false;
                            }
                        }
                        else if (keepOnBuildingLowerBridge == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("=");
                            lowerBridgeLeft --;
                            if (lowerBridgeLeft < 1)
                            {
                                keepOnBuildingLowerBridge = false;
                            }
                        }
                        else if (y == coordinatsForRoad[x])
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("#");
                        }
                        else if (y >= riverCrossig && x + 5 == coordinatesForRiver[y]) 
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


