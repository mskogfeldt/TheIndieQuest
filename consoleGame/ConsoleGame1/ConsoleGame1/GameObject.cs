using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    public class GameObject
    {
       // public int hitPoints;
        public float locationX;
        public float locationY;
        public float speed;
        public float velocityX;
        public float velocityY;

        public void MoveObject()
        {
            locationX += velocityX;
            locationY += velocityY;
        }
    }
}
