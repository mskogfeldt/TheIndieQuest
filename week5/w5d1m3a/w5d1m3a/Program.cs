using System;
using System.Collections.Generic;
using System.Data;

namespace w5d1m3a
{
    class Program
    {
        static void Main(string[] args)
        {

            var random = new Random();

            int widthOfMap = 80;
            int heightOfMap = 24;

            var roads = new bool[widthOfMap, heightOfMap];


            int startPossitionX1 = random.Next(0, widthOfMap - 1);
            int startPossitionY1 = random.Next(0, heightOfMap - 1);
            //(0 = right, 1 = down, 2 = left, 3 = up)
            int direktionOfRoad1 = random.Next(0, 3);
            //GenerateRoad()

            //GenerateRoad(roads, startPossitionX1, startPossitionY1, direktionOfRoad1);
            GenerateIntersection(roads, startPossitionX1, startPossitionY1);

            drawTheSquare(widthOfMap, heightOfMap, roads);

            string WriteSymbol(int valueOfSuronding)
            {
                var symbols = new List<string> { " ", "═", "║", "╔", "═", "═", "╗", "╦", "║", "╚", "║", "╠", "╝", "╩", "╣", "╬" };
                return symbols[valueOfSuronding];
            }

            int CheckTheSuroundingReturnNumber(bool[,] roads, int currentX, int currentY)
            {
                int numberOfcrossingRoads = 0;
               /* if (currentX - 1 > 0)
                {*/
                    if (roads[currentX - 1, currentY] == true)
                    {
                        numberOfcrossingRoads += 4;
                    }
                //}
               /* if (currentX + 1 < width)
                {*/
                    if (roads[currentX + 1, currentY] == true)
                    {
                        numberOfcrossingRoads += 1;
                    }
                //}
              /*  if (roads[currentY - 1,] > 0)
                {*/
                    if (roads[currentX, currentY - 1] == true)
                    {
                        numberOfcrossingRoads += 8;
                    }
               // }
               /* if (roads[currentY + 1,] < height)
                {*/
                    if (roads[currentX, currentY + 1] == true)
                    {
                        numberOfcrossingRoads += 2;
                    }
               // }
                return numberOfcrossingRoads;
            }



            void GenerateIntersection(bool[,] roads, int startX, int startY)
            {
                int roadOrIntersextion = random.Next(1, 11);
                if (roadOrIntersextion <= 3)
                {
                    int roadDirection = random.Next(0, 3);
                    GenerateRoad(roads, startX, startY, roadDirection);
                }
                else
                {
                    for (int x = startX; x < widthOfMap; x++)
                    {
                        roads[x, startY] = true;
                    }
                    for (int y = startY; y < heightOfMap; y++)
                    {
                        roads[startX, y] = true;
                    }
                    for (int x = startX; x > 0; x--)
                    {
                        roads[x, startY] = true;
                    }
                    for (int y = startY; y > 0; y--)
                    {
                        roads[startX, y] = true;
                    }
                }
            }

            void GenerateRoad(bool[,] roads, int startX, int startY, int direction)
            {
                if (direction == 0)
                {
                    for (int x = startX; x < widthOfMap; x++)
                    {
                        roads[x, startY] = true;
                    }
                }
                else if (direction == 1)
                {
                    for (int y = startY; y < heightOfMap; y++)
                    {
                        roads[startX, y] = true;
                    }
                }
                else if (direction == 2)
                {
                    for (int x = startX; x > 0; x--)
                    {
                        roads[x, startY] = true;
                    }
                }
                else
                {
                    for (int y = startY; y > 0; y--)
                    {
                        roads[startX, y] = true;
                    }
                }
            }



            void drawTheSquare(int width, int height, bool[,] roadCoordinates)
            {
                var printText = new List<string> { "C", "I", "T", "Y", " ", "M", "A", "P" };
                int centringspaces = (width - printText.Count) / 2;
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
                        else if (roadCoordinates[x, y] == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            int surounding = CheckTheSuroundingReturnNumber(roadCoordinates, x, y);
                            Console.Write(WriteSymbol(surounding));

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
