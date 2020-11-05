using System;
using System.IO;

namespace w6d5m2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] levelLines = File.ReadAllLines("MazeLevel.txt");

         /*   int playerPossitionY = 0;
            int playerPossitionX = 0;*/

            // foreach (string s in levelLines)
            // {
          /*  Console.WriteLine(levelLines[0]);
            Console.WriteLine(levelLines[1]);
            Console.WriteLine(levelLines[2]);
            Console.WriteLine(levelLines[3]);
            Console.WriteLine(levelLines[4]);
            Console.WriteLine(levelLines[5]);
            Console.WriteLine(levelLines[6]);*/
            string[] sortedNumbers = levelLines[1].Split('x');
            //   }
            int width = Int32.Parse(sortedNumbers[0]);
            int height = Int32.Parse(sortedNumbers[1]);

            char[,] mapOfMaze = CreateTheMaze(levelLines);
            /*    
                for (int y = 2; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        string temp = levelLines[y];
                        mapOfMaze[x, y - 2] = temp[x];
                        if (temp[x] == 'S')
                        {
                            playerPossitionY = y - 2;
                            playerPossitionX = x;
                        }
                    }
                }
                Console.WriteLine("playerPossitionY " + playerPossitionY);
                Console.WriteLine("playerPossitionx " + playerPossitionX);*/
        }
        public static string[] levelLines = File.ReadAllLines("MazeLevel.txt");

        public static int playerPossitionY = 0;
        public static int playerPossitionX = 0;

        public static string[] sortedNumbers = levelLines[1].Split('x');

        static int width = Int32.Parse(sortedNumbers[0]);
        static int height = Int32.Parse(sortedNumbers[1]);
        //public static char[,] mapOfMaze = new char[width, height];
        char[,] mapOfMaze = CreateTheMaze(levelLines);


        public static char[,] CreateTheMaze(string[] arrayOfStrings)
        {
            char[,] mapOfMaze = new char[width, height];
            for (int y = 2; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string temp = arrayOfStrings[y];
                    mapOfMaze[x, y - 2] = temp[x];
                    if (temp[x] == 'S')
                    {
                        playerPossitionY = y - 2;
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
                    Console.Write(arrayOfStrings[x, y]);
                }
                Console.WriteLine();
            }
        }





    }
}
