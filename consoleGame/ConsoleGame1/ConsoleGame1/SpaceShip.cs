using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    public class SpaceShip : GameObject 
    {
        // public string[] shapeII = new string[] { "  \[]\   ", ">[][][][]>", "/[]/" };

        public string[] shape = new string[] { ">╔═╗- ", ">║+║>>", ">╚═╝- " };
        public List<string> weapons = new List<string> { };
        
        public SpaceShip(/*int hitPoints,*/ int locationXCoordinates, int lokationYCoordinates/*, float speedOfSpaceShip*/)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
          /*  speed = speedOfSpaceShip;*/
            velocityX = 0;
            velocityY = 0;

        }
        //int someInt = (int)someFloat

        public void DrawTheSpaceShip()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((int)locationX,(int)locationY);
            Console.CursorVisible = false;
            Console.WriteLine(shape[0]);
            Console.SetCursorPosition((int)locationX, (int)locationY + 1);
            Console.WriteLine(shape[1]);
            Console.SetCursorPosition((int)locationX, (int)locationY + 2);
            Console.WriteLine(shape[2]);
        }

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

