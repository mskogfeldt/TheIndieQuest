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
        public List<int> xnumbers;
        public List<int> ynumbers;
        int indexOfTravel;
        int indexOfWhereLoopStarts;

        //public List<>
        public int[] velocityXWhenLooping2;
        public int[] velocityYWhenLooping2;
        public List<int> velocityXWhenLooping; // = new List<int> { 2, 2,/*loopStarts*/ -2, -2, 2, 2, 0, 0, 0, 0 };
        public List<int> velocityYWhenLooping; // = new List<int> { 0, 0,/*loopStarts*/ -2, -2, -2, -2, 2, 2, 2, 2 };

        public EnemySpaceShip(int locationXCoordinates, int lokationYCoordinates, List<int> valuesForVelosityX, List<int> valuesForVelosityY, int numberBeforeLooping, int indexOfLoopStart)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            

            velocityX = valuesForVelosityX[0];
            velocityY = valuesForVelosityY[0];

        }
    }
}
/*
 using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    public class SpaceShip : GameObject
    {
        // public string[] shape = new string[] { "  \\[]\\   ", ">[][][][]>", "/[]/" };

        
        public string[] shape = new string[] { ">╔═╗- ", " ║=║>>", ">╚═╝- " };
        public List<string> weapons = new List<string> { };
        public List<int> xnumbers;
        public List<int> ynumbers;

        public SpaceShip( int locationXCoordinates, int lokationYCoordinates)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            
            // shape = shapeForObject;
            velocityX = 0;
            velocityY = 0;

        }
        //int someInt = (int)someFloat

        public void DrawTheSpaceShipII(int width, int height)
        {
            for (int y = 0; y < shape.Length; y++)
            {
                for (int x = 0; x < shape[y].Length; x++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition((int)locationX + x, (int)locationY + y);
                    Console.CursorVisible = false;
                    if (IsWhithinEdges(width, height, locationX + x, locationY + y) == true) Console.Write(shape[0 + y][0 + x]);
                }
                Console.WriteLine();
            }
        }

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
        }


        public bool IsWhithinEdges(int width, int height, int coordinateX, int coordinateY)
        {
            if (coordinateX > 1 && coordinateX < width && coordinateY > 1 && coordinateY < height) return true;
            return false;
        }

        public bool IsWhithinEdges2(int width, int height, int coordinateX, int coordinateY, int leftEdge, int topEdge)
        {
            if (coordinateX > leftEdge && coordinateX < leftEdge + width - 1 && coordinateY > topEdge && coordinateY < topEdge + height - 1) return true;
            return false;
        }

        public void EraseImageOfShipsPreviousPosition(int width, int height)
        {
            for (int y = 0; y < shape.Length; y++)
            {
                for (int x = 0; x < shape[y].Length; x++)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition((int)locationX + x, (int)locationY + y);
                    Console.CursorVisible = false;
                    if (IsWhithinEdges(width, height, locationX + x, locationY + y) == true) Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

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

    }
}


 
 */