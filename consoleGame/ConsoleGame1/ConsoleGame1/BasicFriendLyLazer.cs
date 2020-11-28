using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class BasicFriendlyLazer : Weapon
    {
        //public string[] shape = new string[] { "-", "-", "-", "-" };
        public string shape = "-----";

        public BasicFriendlyLazer(int locationXCoordinates, int lokationYCoordinates)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            /*  speed = speedOfSpaceShip;*/
            // shape = shapeForObject;
            velocityX = 10;
            velocityY = 0;
            damage = 1;
        }

     /*   public void Fire(int shipsPossitionX, int shipsPossitionY)
        {
            return new BasicFriendlyLazer(shipsPossitionX, shipsPossitionY);
        }*/

        public void EraseImageOfLazersPreviousPosition2(int width, int height, int leftEdge, int topEdge)
        {
            for (int x = 0; x < shape.Length; x++)
            {
                if (IsWhithinEdges2(width, height, locationX + x, locationY, leftEdge, topEdge) == true)
                {
                    Console.SetCursorPosition((int)locationX + x, (int)locationY);
                    Console.CursorVisible = false;
                    Console.Write(' ');
                }
            }
        }

        /*
         public void EraseImageOfSpaceShipsPreviousPosition(int width, int height, int leftEdge, int topEdge)
        {
            for (int y = 0; y < shape.Length; y++)
            {
                for (int x = 0; x < shape[y].Length; x++)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition((int)locationX + x, (int)locationY + y);
                    Console.CursorVisible = false;
                    if (IsWhithinEdges2(width, height, locationX + x, locationY + y, leftEdge, topEdge) == true) Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
         
         
         
         */

        public void DrawTheLazer(int width, int height, int leftEdge, int topEdge)
        {
            for (int x = 0; x < shape.Length; x++)
            {
                if (IsWhithinEdges2(width, height, locationX + x, locationY, leftEdge, topEdge) == true) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition((int)locationX + x, (int)locationY);
                    Console.CursorVisible = false;
                    Console.Write(shape);
                }
            }
        }
        /*
         public void DrawTheSpaceShipII2(int width, int height, int leftEdge, int topEdge)
        {
            for (int y = 0; y < shape.Length; y++)
            {
                for (int x = 0; x < shape[y].Length; x++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition((int)locationX + x, (int)locationY + y);
                    Console.CursorVisible = false;
                    if (IsWhithinEdges2(width, height, locationX + x, locationY + y, leftEdge, topEdge) == true) Console.Write(shape[0 + y][0 + x]);
                }
                Console.WriteLine();
            }
        }*/

        public bool IsPartOfTheLazerInsideTheEdges(int width, int height, int coordinateX, int coordinateY, int leftEdge, int topEdge)
        {
            for (int x = 0; x < shape.Length; x++)
            {
                if (IsWhithinEdges2(width, height, locationX + x, locationY, leftEdge, topEdge) == true) return true;
            }
            return false;
        }

        public bool IsWhithinEdges2(int width, int height, int coordinateX, int coordinateY, int leftEdge, int topEdge)
        {
            if (coordinateX > leftEdge && coordinateX < leftEdge + width - 1 && coordinateY > topEdge && coordinateY < topEdge + height - 1) return true;
            return false;
        }

    }
}
