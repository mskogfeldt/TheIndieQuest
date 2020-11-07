using System;

namespace ConsoleGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 200;
            int height = 50;

            drawTheSquare(width, height);

            Console.CursorVisible = false;

            SpaceShip ship = new SpaceShip(10, 25, 1);
            while (true)
            {
                ship.MoveShip();
                ship.DrawTheSpaceShip();

                System.Threading.Thread.Sleep(50);
            }
        }

        public static void drawTheSquare(int width, int height)
        {
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
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
