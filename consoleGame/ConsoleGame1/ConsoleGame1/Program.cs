using System;

namespace ConsoleGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string[] MeteorShape = new string[] { "     ***     ", "  *********  ", "*************", "*************", "  *********  ", "     ***     " };
            string[] shipShape = new string[] { ">╔═╗- ", ">║+║>>", ">╚═╝- " };*/

           
            // ConsoleKeyInfo info = Console.ReadKey();


            Console.CursorVisible = false;
            Game newGame = new Game();

            newGame.drawTheSquare(newGame.width, newGame.height);
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
