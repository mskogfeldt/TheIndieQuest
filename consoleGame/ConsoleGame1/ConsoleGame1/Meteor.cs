using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ConsoleGame1
{
    class Meteor : GameObject
    {
        //public char[,] shape = new char[,] { };
        public string[] shape = new string[] { "     ***     ", "  *********  ", "*************", "*************", "  *********  ", "     ***     " };
        
        public Meteor(int locationXCoordinates, int lokationYCoordinates, /*float speedOfSpaceShip, string[] shapeForObject,*/ int velocityDirectionX, int velocityDirectionY)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            /* speed = speedOfSpaceShip;*/
           // shape = shapeForObject;
            velocityX = velocityDirectionX;
            velocityY = velocityDirectionY;
        }

        public void DrawTheMeteor()
        {
            for (int i = 0; i < shape.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition((int)locationX, (int)locationY + i);
                Console.CursorVisible = false;
                Console.WriteLine(shape[0 + i]);
            }
        }

        public void EraseImageOfMeteorsPreviousPosition()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition((int)locationX, (int)locationY + i);
                Console.CursorVisible = false;
                Console.WriteLine("             ");
            }
        }
    }
}