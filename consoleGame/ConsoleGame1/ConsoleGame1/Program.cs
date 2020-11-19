using System;

namespace ConsoleGame1
{
    class Program
    {
        static void Main(string[] args)
        {
           


            Console.CursorVisible = false;
            Game newGame = new Game();

            //newGame.drawTheSquare3(newGame.width, newGame.height, newGame.leftEdge, newGame.topEdge );
            //newGame.drawTheSquare(newGame.width, newGame.height);
            newGame.drawTheSquare2(newGame.width, newGame.height, newGame.leftEdge, newGame.topEdge);
            Console.CursorVisible = false;
            newGame.RunTheGame();
           

        }


    }
}
