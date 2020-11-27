using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class Weapon
    {
        public int damage { get; set; }
        public int locationX { get; set; }
        public int locationY { get; set; }
        //public int speed { get; set; }
        public int velocityX { get; set; }
        public int velocityY { get; set; }


        public void MoveObject()
        {
            locationX += velocityX;
            locationY += velocityY;
        }

        /* public Weapon(int damageForThisWeapon, string shapeForThisWeapon)
         {
             damage = damageForThisWeapon;
             shapeForThisWeapon = shapeForThisWeapon;

         }*/
    }
}
