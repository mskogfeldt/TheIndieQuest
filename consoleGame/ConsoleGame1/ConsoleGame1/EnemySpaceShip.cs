using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    public class EnemySpaceShip : GameObject
    {
        /*public string[] shape2 = new string[] { ">╔═╗- ", " ║=║>>", ">╚═╝- " };
        public string[] shape = new string[] { " -╔═╗", "<<║=║", " -╚═╝<" };*/
        public string[] shape = new string[] { "   AA   ", "  AAAA  ", "<[][][]>", "  VVVV  ", "   VV   " };
        /*
         

         AA
        AAAA
      <[][][]>
        VVVV        
         VV

        

        >╔═╗-   
         ║=║>> 
        >╚═╝- 

         AA
        AAAA
      ╔══════╗
      <[][][]>
      ╚══════╝
        VVVV
         VV

         AA
        AAAA
      ╔══════╗
     <║[][][]║>
      ╚══════╝
        VVVV
         VV
        

           A
          AAA
         AAAAA
        AAAAAAA
     ╔══════════╗
    <║[][][][][]║>
     ╚══════════╝
        VVVVVVV
         VVVVV
          VVV
           V

         
          AA
         AAAA
        AAAAAA
       AAAAAAAA
      AAAAAAAAAA
    <╔══════════╗>
    <║[][][][][]║>
    <╚══════════╝>
      VVVVVVVVVV
       VVVVVVVV
        VVVVVV
         VVVV
          VV

         
         */
        //public 
        public List<string> weapons = new List<string> { };
        public List<int> xNumbers;
        public List<int> yNumbers;
        int indexOfTravel;
        int indexOfWhereLoopStarts;

        //public List<>
        public int[] velocityXWhenLooping2;
        public int[] velocityYWhenLooping2;
        public List<int> velocityXWhenLooping; // = new List<int> { 2, 2,/*loopStarts*/ -2, -2, 2, 2, 0, 0, 0, 0 };
        public List<int> velocityYWhenLooping; // = new List<int> { 0, 0,/*loopStarts*/ -2, -2, -2, -2, 2, 2, 2, 2 };

        public EnemySpaceShip(int locationXCoordinates, int lokationYCoordinates, List<int> valuesForVelosityX, List<int> valuesForVelosityY, int indexOfLoopStart)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            xNumbers = valuesForVelosityX;
            yNumbers = valuesForVelosityY;
            //velocityX = valuesForVelosityX[0];
            //velocityY = valuesForVelosityY[0];
            velocityX = 0;
            velocityY = 0;
            indexOfTravel = 0;
            indexOfWhereLoopStarts = indexOfLoopStart;
        }

        public void StearEnemyShip() 
        {
            velocityX = xNumbers[indexOfTravel];
            velocityY = yNumbers[indexOfTravel];
            indexOfTravel++;
            if (indexOfTravel == xNumbers.Count) indexOfTravel = indexOfWhereLoopStarts;
        }

        public void EraseImageOfEnemysPreviousPosition(int width, int height, int leftEdge, int topEdge)
        {
            for (int y = 0; y < shape.Length; y++)
            {
                for (int x = 0; x < shape[y].Length; x++)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition((int)locationX + x, (int)locationY + y);
                    Console.CursorVisible = false;
                    if (IsWhithinEdges2(width, height, locationX + x, locationY + y, leftEdge, topEdge) == true) Console.Write(' ');
                    //if (IsWhithinEdges2(width, height, locationX + x, locationY + y, leftEdge, topEdge) == true) Console.Write(shape[0 + y][0 + x]);
                }
                Console.WriteLine();
            }
        }

            public void DrawTheEnemy(int width, int height, int leftEdge, int topEdge)
            {
                for (int y = 0; y < shape.Length; y++)
                {
                    for (int x = 0; x < shape[y].Length; x++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.SetCursorPosition((int)locationX + x, (int)locationY + y);
                        Console.CursorVisible = false;
                        if (IsWhithinEdges2(width, height, locationX + x, locationY + y, leftEdge, topEdge) == true) Console.Write(shape[0 + y][0 + x]);
                    }
                    Console.WriteLine();
                }
            }


            public bool IsPartOfTheEnemyInsideTheEdges(int width, int height, int coordinateX, int coordinateY, int leftEdge, int topEdge)
            {
                for (int y = 0; y < shape.Length; y++)
                {
                    for (int x = 0; x < shape[y].Length; x++)
                    {
                        if (IsWhithinEdges2(width, height, locationX + x, locationY + y, leftEdge, topEdge) == true) return true;
                    }
                }
                return false;
            }

            public bool IsWhithinEdges2(int width, int height, int coordinateX, int coordinateY, int leftEdge, int topEdge)
            {
                if (coordinateX > leftEdge && coordinateX < leftEdge + width - 1 && coordinateY > topEdge && coordinateY < topEdge + height - 1) return true;
                return false;
            }

            public void StopTheEnemy()
            {
                velocityX = 0;
                velocityY = 0;
            }

        }
}
