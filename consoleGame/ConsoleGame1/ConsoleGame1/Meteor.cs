using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class Meteor : GameObject
    {
        public char[,] shape = new char[,] { };
        
        
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
            Console.SetCursorPosition((int)locationX, (int)locationY);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
        }

        public void EraseImageOfMeteorsPreviousPosition()
        {
            Console.SetCursorPosition((int)locationX, (int)locationY);
            Console.CursorVisible = false;
            Console.Write(" ");
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