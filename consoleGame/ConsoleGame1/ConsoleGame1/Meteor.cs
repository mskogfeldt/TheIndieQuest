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


        public Meteor(int locationXCoordinates, int lokationYCoordinates/*, float speedOfSpaceShip*/, int velocityDirectionX, int velocityDirectionY)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            /* speed = speedOfSpaceShip;*/
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
            /*  Console.SetCursorPosition((int)locationX, (int)locationY);
              Console.CursorVisible = false;
              Console.ForegroundColor = ConsoleColor.Red;
              Console.SetCursorPosition((int)locationX, (int)locationY);
              Console.CursorVisible = false;
              Console.WriteLine(shape[0]);
              Console.SetCursorPosition((int)locationX, (int)locationY + 1);
              Console.WriteLine(shape[1]);
              Console.SetCursorPosition((int)locationX, (int)locationY + 2);
              Console.WriteLine(shape[2]);
              Console.SetCursorPosition((int)locationX, (int)locationY + 3);
              Console.WriteLine(shape[3]);
              Console.SetCursorPosition((int)locationX, (int)locationY + 4);
              Console.WriteLine(shape[4]);
              Console.SetCursorPosition((int)locationX, (int)locationY + 5);
              Console.WriteLine(shape[5]);*/
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
/*
 public class SpaceShip : GameObject 
    {
        public List<string> weapons = new List<string> { };
        
       // public SpaceShip(/*int hitPoints,
int locationXCoordinates, int lokationYCoordinates, float speedOfSpaceShip)
        {
    locationX = locationXCoordinates;
    locationY = lokationYCoordinates;
    speed = speedOfSpaceShip;
    velocityX = 0;
    velocityY = 0;

}
//int someInt = (int)someFloat

public void DrawTheSpaceShip()
{
    Console.SetCursorPosition((int)locationX, (int)locationY);
    Console.CursorVisible = false;
    Console.Write("*");
}

public void EraseImageOfShipsPreviousPosition()
{
    Console.SetCursorPosition((int)locationX, (int)locationY);
    Console.CursorVisible = false;
    Console.Write(" ");
}

public void DeleteTheSpaceShip()
{

}

    }
 */