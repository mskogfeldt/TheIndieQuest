using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class BasicFriendlyLazer : Weapon
    {
        //public string[] shape = new string[] { "-", "-", "-", "-" };
        public string shape = "------";

        public BasicFriendlyLazer(int locationXCoordinates, int lokationYCoordinates)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            /*  speed = speedOfSpaceShip;*/
            // shape = shapeForObject;
            velocityX = 8;
            velocityY = 0;
            damage = 1;
        }

        public void Fire()
        {
            /* for (int i = 0; i < 5; i++)
             {
                 Console.SetCursorPosition((int)locationX, (int)locationY);
                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.Write(shape);
             }*/
            Console.SetCursorPosition((int)locationX, (int)locationY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(shape);
        }

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

        public void DrawTheLazer(int width, int height, int leftEdge, int topEdge)
        {
            for (int x = 0; x < shape.Length; x++)
            {
                if (IsWhithinEdges2(width, height, locationX + x, locationY, leftEdge, topEdge) == true) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition((int)locationX + x, (int)locationY +0;
                    Console.CursorVisible = false;
                    Console.Write(shape);
                }
            }
        }


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
