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

            // string[] sortedNumbers = levelLines[1].Split('x');
            //   }
            // int width = Int32.Parse(sortedNumbers[0]);
            // int height = Int32.Parse(sortedNumbers[1]);
            int width = levelLines[levelLines.Length - 1].Length;
            int height = levelLines.Length;

            Console.WriteLine("width + height " + width + " " + height);
            Console.WriteLine(levelLines[0]);
            Console.WriteLine(levelLines[1]);
            Console.WriteLine(levelLines[2]);
            Console.WriteLine(levelLines[3]);
            Console.WriteLine(levelLines[4]);
            Console.WriteLine(levelLines[5]);
            Console.WriteLine(levelLines[6]);
            Console.WriteLine(levelLines[7]);
            Console.WriteLine(levelLines[8]);
            Console.WriteLine(levelLines[9]);
            Console.WriteLine(levelLines[10]);
            Console.WriteLine(levelLines[11]);
            Console.WriteLine(levelLines[12]);
            Console.WriteLine(levelLines[13]);
            Console.WriteLine(levelLines[14]);
            Console.WriteLine(levelLines[15]);
            Console.WriteLine(levelLines[16]);
            Console.WriteLine(levelLines[17]);
            Console.WriteLine(levelLines[18]);
            Console.WriteLine(levelLines[19]);
            Console.WriteLine(levelLines[20]);
            Console.WriteLine(levelLines[21]);
            Console.WriteLine(levelLines[22]);

            char[,] mapOfMaze = CreateTheMaze(levelLines);

            DrawMap(mapOfMaze);
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

        // static int width = Int32.Parse(sortedNumbers[0]);
        // static int height = Int32.Parse(sortedNumbers[1]);
        //public static char[,] mapOfMaze = new char[width, height];
        //char[,] mapOfMaze = CreateTheMaze(levelLines);
        static int width = levelLines[levelLines.Length - 1].Length;
        static int height = levelLines.Length;


        public static char[,] CreateTheMaze(string[] arrayOfStrings)
        {
            char[,] mapOfMaze = new char[width, height];
            for (int y = 2; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string temp = arrayOfStrings[y];
                    if (y >= 2 )
                    {
                        mapOfMaze[x, y] = temp[x];
                    }
                    //mapOfMaze[x, y] = temp[x];
                    if (temp[x] == 'S')
                    {
                        mapOfMaze[x, y] = '☺';
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
                    Console.Write(arrayOfStrings[x, y]);
                }
                Console.WriteLine();
            }
        }





    }
}
