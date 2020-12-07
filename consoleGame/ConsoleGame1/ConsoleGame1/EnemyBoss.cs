using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame1
{
    class EnemyBoss : GameObject
    {
        public int hp = 5;
        public string[] shape = new string[] { "      AA      ", "     AAAA     ", "    AAAAAA    ", "   AAAAAAAA   ", "  AAAAAAAAAA  ", "<╔══════════╗>",  "<║[][][][][]║>", " <╚══════════╝>", "  VVVVVVVVVV  ", "   VVVVVVVV   ", "    VVVVVV    ", "      VVVV      " , "      VV      "};
        public string[] ShapeWhenFireSpecialAttack = new string[] { "      AA      ", "     AAAA     ", "    AAAAAA    ", "   AAAAAAAA   ", "  AAAAAAAAAA  ", "<╔══════════╗>", "<║[µ][~§][Ç]║>", " <╚══════════╝>", "  VVVVVVVVVV  ", "   VVVVVVVV   ", "    VVVVVV    ", "      VVVV      ", "      VV      " };
        public string[] shapeWithForceField = new string[] { "╔══════════════╗", "║      AA      ║", "║     AAAA     ║", "║    AAAAAA    ║", "║   AAAAAAAA   ║", "║  AAAAAAAAAA  ║", "║<╔══════════╗>║", "║<║[][][][][]║>║", "║<╚══════════╝>║", "║  VVVVVVVVVV  ║", "║   VVVVVVVV   ║", "║    VVVVVV    ║", "║     VVVV     ║", "║      VV      ║", "╚══════════════╝" };
        public string[] shapeWithForceFieldAndSpecialAttack = new string[] { "╔══════════════╗", "║      AA      ║", "║     AAAA     ║", "║    AAAAAA    ║", "║   AAAAAAAA   ║", "║  AAAAAAAAAA  ║", "║<╔══════════╗>║", "<║[µ][~§][Ç]║>", "║<╚══════════╝>║", "║  VVVVVVVVVV  ║", "║   VVVVVVVV   ║", "║    VVVVVV    ║", "║     VVVV     ║", "║      VV      ║", "╚══════════════╝" };
        public Random random = new Random();
        bool specialAttack = false;
        bool forceField = true;

        public EnemyBoss(int locationXCoordinates, int lokationYCoordinates) 
        { 
        
        
        
        }

        /*public EnemySpaceShip(int locationXCoordinates, int lokationYCoordinates, List<int> valuesForVelosityX, List<int> valuesForVelosityY, int indexOfLoopStart, bool shootsOnX, bool shootsOnPossitiveInt)
        {
            locationX = locationXCoordinates;
            locationY = lokationYCoordinates;
            xNumbers = valuesForVelosityX;
            yNumbers = valuesForVelosityY;
            xShooter = shootsOnX;
            positiveShooter = shootsOnPossitiveInt;
            //velocityX = valuesForVelosityX[0];
            //velocityY = valuesForVelosityY[0];
            velocityX = 0;
            velocityY = 0;
            indexOfTravel = 0;
            indexOfWhereLoopStarts = indexOfLoopStart;
        }*/


    }
}

/*

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

╔══════════════╗
║      AA      ║
║     AAAA     ║
║    AAAAAA    ║
║   AAAAAAAA   ║
║  AAAAAAAAAA  ║
║<╔══════════╗>║
║<║[][][][][]║>║
║<╚══════════╝>║
║  VVVVVVVVVV  ║
║   VVVVVVVV   ║
║    VVVVVV    ║ 
║     VVVV     ║
║      VV      ║   
╚══════════════╝


╔══════════════╗
║      AA      ║
║     AAAA     ║
║    AAAAAA    ║
║   AAAAAAAA   ║
║  AAAAAAAAAA  ║
║<╔══════════╗>║
║<║[µ][~§][Ç]║>║
║<╚══════════╝>║
║  VVVVVVVVVV  ║
║   VVVVVVVV   ║
║    VVVVVV    ║ 
║     VVVV     ║
║      VV      ║   
╚══════════════╝

      AA
     AAAA
    AAAAAA
   AAAAAAAA
  AAAAAAAAAA
<╔══════════╗>
<║[µ][~§][Ç]║>
<╚══════════╝>
  VVVVVVVVVV
   VVVVVVVV
    VVVVVV
     VVVV
      VV

§ ~~ µ Ç

128 228 230 232 234
 */