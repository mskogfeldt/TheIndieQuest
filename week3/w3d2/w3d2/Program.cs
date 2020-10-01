using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace w3d2
{
    class Program
    {
        //Program that randomises a Map.
        static void Main(string[] args)
        {
      
            var symbolsUsedForTheForrest = "Q@C$U0&*()oO86uDGgÖö36";
            var random = new Random();

            int withOfMap = 80;
            int heightOfMap = 30;
            var coordinatesForRiver = GenerateCoordinatsForVerticleLine(withOfMap, heightOfMap, withOfMap * 3 / 4, 3, withOfMap * 2 / 3, withOfMap * 4 / 5); 
            var shapeOfRiver = GenerateShapeOfVerticalLine(coordinatesForRiver);
            var wallCoordinates = GenerateCoordinatsForVerticleLine(withOfMap, heightOfMap, withOfMap / 4, 8, withOfMap / 5, withOfMap / 3);
            var shapeOfWall = GenerateShapeOfVerticalLine(wallCoordinates);
            var roadCoordinates = GenerateCoordinatesForRoad(withOfMap, heightOfMap, coordinatesForRiver, wallCoordinates);
            var bridgeCoordinates = GenerateCoordinatesForBridge(withOfMap, coordinatesForRiver, roadCoordinates);
            int riverCrossig = LoopVerticlyLookForCrossingHorisontalLine(heightOfMap, coordinatesForRiver, roadCoordinates);
            var gateCoordinates = GenerateCoordinatesForGate(withOfMap, wallCoordinates, roadCoordinates);
            drawTheSquare(withOfMap, heightOfMap, coordinatesForRiver, shapeOfRiver, roadCoordinates, bridgeCoordinates, wallCoordinates, gateCoordinates);
            
          
            List<int> GenerateCoordinatesForBridge(int width, List<int> coordinatesForRiver, List<int> coordinatesForRoad)
            {
                var coordinatesForBridge = new List<int> { };
                for (int x = 0; x < width - 1; x++)
                {
                    int theValueOfRoad = coordinatesForRoad[x];

                    if (x == coordinatesForRiver[theValueOfRoad])
                    {
                        coordinatesForBridge.Add(x - 3);
                        coordinatesForBridge.Add(coordinatesForRoad[x] - 1);
                        coordinatesForBridge.Add(coordinatesForRoad[x] + 1);
                    }
                }
                return coordinatesForBridge;
            }

            int WillVerticalLineTurn(int curentValue, int chanseForTurn, int leftMostLimit,  int rightmostLine)
            {
                int willLineTurn = random.Next(1, chanseForTurn);
                if (willLineTurn == chanseForTurn - 1 && curentValue > leftMostLimit)
                {
                    return curentValue - 1;
                }
                else if (willLineTurn == chanseForTurn && curentValue < rightmostLine)
                {
                    return curentValue - 1;
                }
                return curentValue;
            
            }

            List<string> GenerateShapeOfVerticalLine(List<int> coordinatesForVerticleLine)
            {
                string riversStrait = "|";
                string riverTurnsLeft = "/";
                string riverTurnsRight = @"\";
                var listForShapeOfVerticleLine= new List<string> { };

                for (int y = 0; y < coordinatesForVerticleLine.Count - 1; y++)
                {
                    if (coordinatesForVerticleLine[y] < coordinatesForVerticleLine[y + 1])
                    {
                        listForShapeOfVerticleLine.Add(riverTurnsRight);
                    }
                    else if (coordinatesForVerticleLine[y] > coordinatesForVerticleLine[y + 1])
                    {
                        listForShapeOfVerticleLine.Add(riverTurnsLeft);
                    }
                    else
                    {
                        listForShapeOfVerticleLine.Add(riversStrait);
                    }
                }
                listForShapeOfVerticleLine.Add(riversStrait);
                return listForShapeOfVerticleLine;
            }

            List<int> GenerateCoordinatesForRoad(int width, int height, List<int> coordinatesForRiver, List<int> coordinatesForWall)
            {
                int startingModifier = random.Next(-1, 2);
                int latestPositionOfRoad = height * 1 / 2 + startingModifier;
                int willRoadTurn = 0;
                bool crossingWater = false;
                bool crossingWall = false;
                int numberToSayHowLongTheRoadWillBeStraitWhenCrossingWater = 9;
                int numberToSayHowLongTheRoadWillBeStraitWhenCrossingWall = 3;
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
                    else if (i + 5 - coordinatesForRiver[latestPositionOfRoad] < 1 && i + 5 - coordinatesForRiver[latestPositionOfRoad] > -1)
                    {
                        crossingWater = true;
                        coordinatesForRoad.Add(latestPositionOfRoad);
                    }
                    else if (i + 1 - coordinatesForWall[latestPositionOfRoad] <= 0 && i + 1 - coordinatesForWall[latestPositionOfRoad] >= -1)
                    {
                        coordinatesForRoad.Add(latestPositionOfRoad);
                        crossingWall = true;
                    }
                    else if (crossingWall == true)
                    {
                        coordinatesForRoad.Add(latestPositionOfRoad);
                        numberToSayHowLongTheRoadWillBeStraitWhenCrossingWall--;
                        if(numberToSayHowLongTheRoadWillBeStraitWhenCrossingWall < 1)
                        {
                            crossingWall = false;
                        }
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

            List<int> GenerateCoordinatsForVerticleLine(int width, int height, int startingPoint, int oneDividedByThisNumberMinusOneIsChanseForTurn, int leftostPoint, int rightmostPoint)
            {
                int currentPossition = startingPoint;
                var coordinatesForWall = new List<int> { };
                for (int y = 0; y < height - 1; y++) 
                {
                   coordinatesForWall.Add(WillVerticalLineTurn(currentPossition, oneDividedByThisNumberMinusOneIsChanseForTurn, leftostPoint, rightmostPoint));
                }
                return coordinatesForWall;
            }

            List<int> GenerateCoordinatesForGate(int width, List<int> coordinatesForWall, List<int> coordinatesForRoad)
            {
                var coordinatesForGates = new List<int> { };
                for (int x = 0; x < width - 1; x++)
                {
                    int theValueOfRoad = coordinatesForRoad[x];

                    if (x == coordinatesForWall[theValueOfRoad])
                    {
                        coordinatesForGates.Add(x - 1);
                        coordinatesForGates.Add(coordinatesForRoad[x] - 1);
                        coordinatesForGates.Add(coordinatesForRoad[x] + 1);
                    }
                }
                return coordinatesForGates;
            }

           
            int LoopVerticlyLookForCrossingHorisontalLine(int height, List<int> coordinatesForRiver, List<int> coordinatesForRoad)
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

            ConsoleColor RandomiseCollor()
            {
                ConsoleColor theRandomisedCollor = ConsoleColor.White;
                int randomColor = random.Next(1, 8);
                if (randomColor == 7) 
                {
                    theRandomisedCollor = ConsoleColor.Red;
                    return theRandomisedCollor;
                }
                if (randomColor == 5 || randomColor == 6)
                {
                    theRandomisedCollor = ConsoleColor.Yellow;
                    return theRandomisedCollor;
                }
                return theRandomisedCollor = ConsoleColor.Green;

            }

            string RandomiseSymbol()
            {
                int indexOfSymbolToReturn = random.Next(0, symbolsUsedForTheForrest.Length);
                return symbolsUsedForTheForrest[indexOfSymbolToReturn].ToString();
            }
        
            void drawTheSquare(int width, int height, List<int> coordinatsForRiver, List<string> shapeOfRiver, List<int> coordinatsForRoad, 
                List<int> coordinatesForTheBridge, List<int> coordinatesForTheWall, List<int> coordinatesForGate)
            {
                var printText = new List<string> { "A", "D", "V", "E", "N", "T", "U", "R", "E", " ", "M", "A", "P" };
                int centringspaces = (width - printText.Count) / 2;              
                int topBridgeLeft = 7;
                int lowerBridgeLeft = 7;
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
                        else if (y == coordinatesForGate [1] && x == coordinatesForTheWall[y])
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("[]");
                            x++;
                        }
                        else if (y == coordinatesForGate[2] && x == coordinatesForTheWall[y] )
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("[]");
                            x++;
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
                        else if (x == coordinatesForTheWall[y] || x - 1 == coordinatesForTheWall[y] )
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(shapeOfWall[y]);
                        }
                        else if (x == 1 || x == 2)
                        {
                            Console.ForegroundColor = RandomiseCollor();
                            string toWrite = RandomiseSymbol();
                            Console.Write(toWrite);
                        }
                        else if (x == 3 || x == 4)
                        {
                            Console.ForegroundColor = RandomiseCollor();
                            int willThereBeOneTree = random.Next(1, 4);
                            if (willThereBeOneTree == 3)
                            {
                                string toWrite = RandomiseSymbol();
                                Console.Write(toWrite);
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        else if (x == coordinatsForRiver[y] || x + 1 == coordinatsForRiver[y] || x + 2 == coordinatsForRiver[y])
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


