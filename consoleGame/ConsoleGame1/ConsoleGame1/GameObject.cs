using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    public class GameObject
    {
       // public int hitPoints;
        public float locationX { get; set; }
        public float locationY { get; set; }
        public float speed { get; set; }
        public float velocityX { get; set; }
        public float velocityY { get; set; }

        public void MoveObject()
        {
            locationX += velocityX;
            locationY += velocityY;
        }
    }
}
