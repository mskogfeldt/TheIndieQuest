using System;
using System.Data;
using System.IO;

namespace w6d5m2
{
    class Program
    {
        static void Main(string[] args)
        {
            // string[] levelLines = File.ReadAllLines("MazeLevel.txt");
            //  int width = levelLines[levelLines.Length - 1].Length;
            //   int height = levelLines.Length;

            Console.WriteLine("Get ready for: Minotaurs lair");
            Console.WriteLine();
            Console.WriteLine("Press any key to start ...");
            Console.ReadKey();
            Console.SetCursorPosition(0, 0);
            //DrawMap(mapOfMaze);

            RunTheGame();
        }
        public static int playerPossitionY = 0;
        public static int playerPossitionX = 0;

        public static string[] levelLines = File.ReadAllLines("MazeLevel.txt");
        public static string[] sortedNumbers = levelLines[1].Split('x');

        public static int width = Int32.Parse(sortedNumbers[0]);
        public static int height = Int32.Parse(sortedNumbers[1]);
        public static char[,] mapOfMaze = CreateTheMaze(levelLines);

        public static void RunTheGame()
        {
            bool keepOnTruckin = true;
            while (keepOnTruckin)
            {
                Console.Clear();
                DrawMap(mapOfMaze);
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.LeftArrow)
                {
                    if (mapOfMaze[playerPossitionX - 1, playerPossitionY] == ' ') playerPossitionX--;
                    else if (mapOfMaze[playerPossitionX - 1, playerPossitionY] == 'M') 
                    {
                        playerPossitionX--;
                        DrawMap(mapOfMaze);
                        keepOnTruckin = false;
                        EndTheGame();
                    } 
                }
                else if (info.Key == ConsoleKey.RightArrow)
                {
                    if (mapOfMaze[playerPossitionX + 1, playerPossitionY] == ' ') playerPossitionX++;
                    else if (mapOfMaze[playerPossitionX + 1, playerPossitionY] == 'M') 
                    {
                        playerPossitionX++;
                        DrawMap(mapOfMaze);
                        keepOnTruckin = false;
                        EndTheGame();
                    }
                }
                else if (info.Key == ConsoleKey.UpArrow)
                {
                    if (mapOfMaze[playerPossitionX, playerPossitionY - 1] == ' ') playerPossitionY--;
                    else if (mapOfMaze[playerPossitionX, playerPossitionY - 1] == 'M') 
                    {
                        playerPossitionY--;
                        DrawMap(mapOfMaze);
                        keepOnTruckin = false;
                        EndTheGame();
                    } 
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    if (mapOfMaze[playerPossitionX, playerPossitionY + 1] == ' ') playerPossitionY++;
                    else if (mapOfMaze[playerPossitionX, playerPossitionY - 1] == 'M') 
                    {
                        playerPossitionY++;
                        DrawMap(mapOfMaze);
                        keepOnTruckin = false;
                        EndTheGame();
                    } 
                }
                else if (info.Key == ConsoleKey.Escape) keepOnTruckin = false;
                else continue;
            }
        }

        public static void EndTheGame()
        {
            Console.WriteLine("The Minotaur shits his pants, you have won!");
        }

        public static char[,] CreateTheMaze(string[] arrayOfStrings)
        {
            char[,] mapOfMaze = new char[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string temp = arrayOfStrings[y + 2];
                    mapOfMaze[x, y] = temp[x];
                    if (temp[x] == 'S')
                    {
                        mapOfMaze[x, y] = ' ';
                        playerPossitionY = y;
                        playerPossitionX = x;
                    }
                }

            }
            return mapOfMaze;
        }

        public static void DrawMap(char[,] arrayOfStrings)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == playerPossitionX && y == playerPossitionY) Console.Write('☺');
                    else Console.Write(arrayOfStrings[x, y]);
                }
                Console.WriteLine();
            }
        }
    }

}
