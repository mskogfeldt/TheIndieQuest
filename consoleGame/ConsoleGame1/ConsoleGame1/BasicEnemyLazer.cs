
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class BasicEnemyLazer : GameObject
    {
        //public string[] shape = new string[] { "-", "-", "-", "-" };
        public string shape = "-----";

        public BasicEnemyLazer(int locationXCoordinates, int lokationYCoordinates)
        {
            velocityX = -10;
            velocityY = 0;
            locationX = locationXCoordinates - velocityX;
            locationY = lokationYCoordinates - velocityY;

            // shape = shapeForObject;

            damage = 1;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition((int)locationX + x, (int)locationY);
                    Console.CursorVisible = false;
                    Console.Write(shape[x]);
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

        public void StopTheLazer()
        {
            velocityX = 0;
            velocityY = 0;
        }

        public List<int> CalculateFireCoordinates()
        {
            List<int> firecoordinates = new List<int> { };
            firecoordinates.Add(locationX + velocityX);
            firecoordinates.Add(locationY + 2 + velocityY);
            return firecoordinates;
        }

    }
}
