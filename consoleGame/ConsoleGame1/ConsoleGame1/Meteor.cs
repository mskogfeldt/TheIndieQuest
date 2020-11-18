﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ConsoleGame1
{
    class Meteor : GameObject
    {
        //public char[,] shape = new char[,] { };
        public string[] shape = new string[] { "     ***     ", "  *********  ", "*************", "*************", "  *********  ", "     ***     " };
        // int enteringBoardEdge;


        public Meteor(int locationXCoordinates, int lokationYCoordinates, /*float speedOfSpaceShip, string[] shapeForObject,*/ int velocityDirectionX, int velocityDirectionY)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            /* speed = speedOfSpaceShip;*/
            // shape = shapeForObject;
            velocityX = velocityDirectionX;
            velocityY = velocityDirectionY;
        }


        public void DrawTheMeteor(int width, int height)
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
/*
        public bool IsWEdges(int width, int height, int coordinateX, int coordinateY)
        {
            if (coordinateX == 1 || coordinateX == width  || coordinateY == 1 || coordinateY < height - 1) return true;
            return false;
        }*/

        public bool IsWhithinEdges(int width, int height, int coordinateX, int coordinateY)
        {
            if (coordinateX > 1 && coordinateX < width - 1 && coordinateY > 1 && coordinateY < height - 1) return true;
            return false;
        }
        /*
         for (int y = 0; y < shape.Length; y++)
        {
            for (int x = 0; x < shape[y].Length; x++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition((int)locationX + x, (int)locationY + y);
                Console.CursorVisible = false;       
              if (IsWhithinEdges(width, height, loc##          ationX + x, locationY + y) == true) Console.Write(shape[0 + y][0 + x]);
            }                                     #    # #
            Console.WriteLine();                 #   #     #
                                                #   #   #   #
                                               #   #  #  #   # 
                                                #   #    #   # 
                                                 #   ###    #
                                                  #       #
                                                     ####

          * 
     *   ***  *
       *******
     ***********
   ***************
     ***********
      ********* 
    *    ***   * 
          *

        }
         */
        public void EraseImageOfMeteorsPreviousPosition(int width, int height)
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
    }
}