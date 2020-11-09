using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class Cockpit
    {
        public ConsoleKeyInfo info = Console.ReadKey();


        public void StearTheSpaceShip()
        {

        }



    }
    /*
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
     */
    /*
     public class SpaceShip : GameObject 
    {
        public List<string> weapons = new List<string> { };
        
        public SpaceShip(int hitPoints,
    int locationXCoordinates, int lokationYCoordinates, float speedOfSpaceShip)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            speed = speedOfSpaceShip;

        }
//int someInt = (int)someFloat

public void DrawTheSpaceShip()
{
    Console.SetCursorPosition((int)locationX, (int)locationY);
    Console.Write("*");
}

public void MoveShip()
{
    Console.SetCursorPosition((int)locationX, (int)locationY);
    Console.Write(" ");

    locationX++;
}

public void DeleteTheSpaceShip()
{

}

    }
     */
}
