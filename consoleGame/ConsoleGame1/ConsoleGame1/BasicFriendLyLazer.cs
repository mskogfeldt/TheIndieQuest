using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class BasicFriendlyLazer : Weapon
    {
        //public string[] shape = new string[] { "-", "-", "-", "-" };
        public string shape = "-" ;

        public BasicFriendlyLazer(int locationXCoordinates, int lokationYCoordinates) 
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            /*  speed = speedOfSpaceShip;*/
            // shape = shapeForObject;
            velocityX = 8;
            velocityY = 0;
        }

        public void
    }
}
