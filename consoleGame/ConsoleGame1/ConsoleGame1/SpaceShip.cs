using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    public class SpaceShip : GameObject
    {
        // public string[] shape = new string[] { "  \\[]\\   ", ">[][][][]>", "/[]/" };

        
        public string[] shape = new string[] { ">╔═╗- ", ">║+║>>", ">╚═╝- " };
        public List<string> weapons = new List<string> { };
        public List<int> xnumbers;
        public List<int> ynumbers;

        public SpaceShip(/*int hitPoints,*/ int locationXCoordinates, int lokationYCoordinates/*, string[] shapeForObject, float speedOfSpaceShip*/)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            /*  speed = speedOfSpaceShip;*/
            // shape = shapeForObject;
            velocityX = 0;
            velocityY = 0;

        }
        //int someInt = (int)someFloat
        public void DrawTheSpaceShipIII()
        {

        }

        public void DrawTheSpaceShipII(int width, int height)
        {
            for (int y = 0; y < shape.Length; y++)
            {
                for (int x = 0; x < shape[y].Length; x++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition((int)locationX + x, (int)locationY + y);
                    Console.CursorVisible = false;
                    if (IsWhithinEdges(width, height, locationX + x, locationY + y) == true) Console.Write(shape[0 + y][0 + x]);
                }
                Console.WriteLine();
            }
        }

        public void DrawTheSpaceShip()
        {
            for (int y = 0; y < shape.Length; y++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition((int)locationX, (int)locationY + y);
                Console.CursorVisible = false;
                Console.WriteLine(shape[0 + y]);
            }
        }

        public bool IsWhithinEdges(int width, int height, int coordinateX, int coordinateY)
        {
            if (coordinateX > 1 && coordinateX < width && coordinateY > 1 && coordinateY < height) return true;
            return false;
        }
        /*   Console.ForegroundColor = ConsoleColor.White;
           Console.SetCursorPosition((int)locationX,(int)locationY);
           Console.CursorVisible = false;
           Console.WriteLine(shape[0]);
           Console.SetCursorPosition((int)locationX, (int)locationY + 1);
           Console.WriteLine(shape[1]);
           Console.SetCursorPosition((int)locationX, (int)locationY + 2);
           Console.WriteLine(shape[2]);
        }*/

        public void EraseImageOfShipsPreviousPosition()
        {
            for (int i = 0; i < shape.Length; i++)
            {
                Console.SetCursorPosition((int)locationX, (int)locationY + i);
                Console.CursorVisible = false;
                Console.Write("      ");
            }
        }

        public void DeleteTheSpaceShip()
        {

        }

    }
}

