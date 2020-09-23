using System;
using System.Collections.Generic;
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
            /*  string riversStrait = "|";
              string riverTurnsLeft = "/";
              string riverTurnsRight = @"\";*/
            var coordinatesForRiver = GenerateCoordinatesForRiver(50, 20);
            var shapeOfRiver = GenerateShapeOfRiver(50, 20, coordinatesForRiver);
            var roadCordinates = GenerateCoordinatesForRoad(50, 20);
            drawTheSquare(50, 20, coordinatesForRiver, shapeOfRiver, roadCordinates);


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
                    willRiverTurn = random.Next(1, 6);
                    if (willRiverTurn == 4 && i > width * 2 / 3)
                    {
                        latestPositionOfRiver -= 1;
                        coordinatesForRiver.Add(latestPositionOfRiver);
                    }
                    else if (willRiverTurn == 5 && i < width * 5 / 6 )
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

            List<int> GenerateCoordinatesForRoad(int width, int height)
            {
                int startingModifier = random.Next(1, 5);
                int latestPositionOfRoad = height * 1 / 2 + startingModifier;
                int willRoadTurn = 0;
                var coordinatesForRoad = new List<int> { };
                for (int i = 0; i < width - 1; i++)
                {
                    willRoadTurn = random.Next(1, 6);
                    if (willRoadTurn == 4 && i > width * 2 / 3)
                    {
                        latestPositionOfRoad -= 1;
                        coordinatesForRoad.Add(latestPositionOfRoad);
                    }
                    else if (willRoadTurn == 5 && i < width * 1 / 3)
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
                        }
                        else if (x == )
                            {

                        }
                        else if ((x == 1 || x == 2))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            string toWrite = randomiseSymbol();
                            Console.Write(toWrite);
                        }
                        else if (x == coordinatsForRiver[y] || x -1 == coordinatsForRiver[y] || x - 2 == coordinatsForRiver[y])
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


