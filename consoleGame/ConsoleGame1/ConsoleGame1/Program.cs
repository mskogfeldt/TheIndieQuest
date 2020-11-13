using System;

namespace ConsoleGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string[] MeteorShape = new string[] { "     ***     ", "  *********  ", "*************", "*************", "  *********  ", "     ***     " };
            string[] shipShape = new string[] { ">╔═╗- ", ">║+║>>", ">╚═╝- " };*/

            int width = 200;
            int height = 50;
            // ConsoleKeyInfo info = Console.ReadKey();


            Console.CursorVisible = false;
            Game newGame = new Game();

            newGame.drawTheSquare(width, height);
            /*
                        while (true)
                        { */
            Console.CursorVisible = false;
            newGame.RunTheGame();
            // System.Threading.Thread.Sleep(50);
            //}

        }


    }
}
