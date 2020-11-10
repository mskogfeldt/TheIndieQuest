using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class Game
    {
        public ConsoleKeyInfo info;
        public SpaceShip playersShip = new SpaceShip(10, 25, 1);

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
            //System.Threading.Thread.Sleep(1000 / sv_settings.fps);
            /*while (System.Console.KeyAvailable)
				{
					var _key = System.Console.ReadKey(true);*/
            bool keepOnTruckin = true;

            while (keepOnTruckin == true)
            {
                //playersShip.EraseImageOfShipsPreviousPosition();
                System.Threading.Thread.Sleep(1000 / 10);

                while (System.Console.KeyAvailable)
                {
                    var key = System.Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case System.ConsoleKey.LeftArrow:
                            {
                                playersShip.velocityX--;
                            }
                            break;
                        case System.ConsoleKey.RightArrow:
                            {
                                playersShip.velocityX++;
                            }
                            break;
                        case System.ConsoleKey.UpArrow:
                            {
                                playersShip.velocityY--;
                            }
                            break;
                        case System.ConsoleKey.DownArrow:
                            {
                                playersShip.velocityY++;
                            }
                            break;

                    }

                    /*info = Console.ReadKey(true);
                    if (info.Key == ConsoleKey.LeftArrow)
                    {
                        playersShip.velocityX--;
                    }
                    else if (info.Key == ConsoleKey.RightArrow)
                    {
                        playersShip.velocityX++;
                    }
                    else if (info.Key == ConsoleKey.UpArrow)
                    {
                        playersShip.velocityY--;
                    }
                    else if (info.Key == ConsoleKey.DownArrow)
                    {
                        playersShip.velocityY++;
                    }
                    else if (info.Key == ConsoleKey.Escape) keepOnTruckin = false;
                    playersShip.MoveObject();
                    playersShip.DrawTheSpaceShip();*/

                }
                playersShip.EraseImageOfShipsPreviousPosition();
                playersShip.MoveObject();
                playersShip.DrawTheSpaceShip();
            }
        }
        /*
         while (!sv_game_over)
			{
				MoveSnake();

				System.Threading.Thread.Sleep(1000 / sv_settings.fps);

				var _snake_direction_x = sv_snake_direction_x;

				var _snake_direction_y = sv_snake_direction_y;

				while (System.Console.KeyAvailable)
				{
					var _key = System.Console.ReadKey(true);

					switch (_key.Key)
					{
						case System.ConsoleKey.LeftArrow:
							{
								if (sv_snake_direction_x != 1)
								{
									_snake_direction_x = -1;

									_snake_direction_y = 0;
								}
							}
							break;
						case System.ConsoleKey.RightArrow:
							{
								if (sv_snake_direction_x != -1)
								{
									_snake_direction_x = 1;

									_snake_direction_y = 0;
								}
							}
							break;
						case System.ConsoleKey.UpArrow:
							{
								if (sv_snake_direction_y != 1)
								{
									_snake_direction_x = 0;

									_snake_direction_y = -1;
								}
							}
							break;
						case System.ConsoleKey.DownArrow:
							{
								if (sv_snake_direction_y != -1)
								{
									_snake_direction_x = 0;

									_snake_direction_y = 1;
								}
							}
							break;
					}
				}
         */
    }
}

