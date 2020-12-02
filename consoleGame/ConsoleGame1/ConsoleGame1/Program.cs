using System;

namespace ConsoleGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.Environment.SystemPageSize() =
            //System.Environment.GetEnvironmentVariable = 

            //Console.CursorVisible = false;
            Game newGame = new Game();

            //Console.CursorSize

            //newGame.drawTheSquare3(newGame.width, newGame.height, newGame.leftEdge, newGame.topEdge );
            //newGame.drawTheSquare(newGame.width, newGame.height);
            newGame.drawTheSquare2(newGame.width, newGame.height, newGame.leftEdge, newGame.topEdge);
            Console.CursorVisible = false;
            newGame.RunTheEarlyGame();


        }


    }
}
