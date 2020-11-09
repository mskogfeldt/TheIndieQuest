using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class Game
    {
        public ConsoleKeyInfo info;
        public SpaceShip ship = new SpaceShip(10, 25, 1);

        public void drawTheSquare(int width, int height)
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

        public void RunTheGame()
        {
            bool keepOnTruckin = true;
            info = Console.ReadKey(true);
            ship.MoveShip();
            
                if (info.Key == ConsoleKey.LeftArrow)
                {
                    ship.velocityX--;
                }
                else if (info.Key == ConsoleKey.RightArrow)
                {
                    ship.velocityX++;
                }
                else if (info.Key == ConsoleKey.UpArrow)
                {
                    ship.velocityY--;
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    ship.velocityY++;
                }
                else if (info.Key == ConsoleKey.Escape) keepOnTruckin = false;
            ship.MoveObject();
            ship.DrawTheSpaceShip();
                
        }
    }
}

