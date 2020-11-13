using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    public class GameObject
    {
        // public int hitPoints;
        //public string[] shape = new string[] { } {set;}
        public int locationX { get; set; }
        public int locationY { get; set; }
        public int speed { get; set; }
        public int velocityX { get; set; }
        public int velocityY { get; set; }

        public void MoveObject()
        {
            locationX += velocityX;
            locationY += velocityY;
        }
    }
}
