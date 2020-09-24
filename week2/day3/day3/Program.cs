using System;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {

            var random = new Random();
            int totalFrames = random.Next(1, 11);



            for (int i = 0; i < totalFrames; i++)
            {
                Console.Write("+-----");
            }
            Console.WriteLine("+");


            for (int i = 0; i < totalFrames; i++)
            {
                int firstRoll = random.Next(0, 11);
                string firsRollString = "";
                if (firstRoll == 10)
                {
                    Console.Write($"| |x| ");
                }
                else
                {
                    if (firstRoll == 0)
                    {
                        Console.Write($"| |-|");
                    }
                    else
                    {
                        Console.Write($"| |{firstRoll}|");
                    }
                    int secondRoll = random.Next(0, 11 - firstRoll);
                    if (secondRoll == 0)
                    {
                        Console.Write($"-");
                    }
                    else if (firstRoll + secondRoll == 10)
                    {
                        Console.Write($"/");
                    }
                    else
                    {
                        Console.Write($"{secondRoll}");
                    }
                }
            }
            Console.WriteLine("|");

            for (int i = 0; i < totalFrames; i++)
            {
                Console.Write("| ----");
            }

            Console.WriteLine("|");

            for (int i = 0; i < totalFrames; i++)
            {
                Console.Write("|     ");
            }

            Console.WriteLine("|");

            for (int i = 0; i < totalFrames; i++)
            {
                Console.Write("+-----");
               
            }
            Console.WriteLine("+");



            /*
                        for (int i = 0; i <= 3; i++)
                        {
                            int firstRoll = random.Next(0, 11);
                            if (firstRoll == 10)
                            {
                                Console.WriteLine("First roll: X");
                                Console.WriteLine("Knocked down pinns: " + firstRoll);
                            }
                            else
                            {
                                int secondRoll = random.Next(0, 11 - firstRoll);
                                if (firstRoll + secondRoll == 10)
                                {
                                    Console.WriteLine("First roll: " + firstRoll);
                                    Console.WriteLine("Knocked down pinns " + firstRoll);
                                    Console.WriteLine("Second roll: /");
                                    Console.WriteLine("Knocked down pinns " + secondRoll);
                                }
                                else
                                {
                                    Console.WriteLine("First roll: " + firstRoll);
                                    Console.WriteLine("Knocked down pinns " + firstRoll);
                                    Console.WriteLine("Second roll: " + secondRoll);
                                    Console.WriteLine("Knocked down pinns " + firstRoll);
                                }
                            }
                      }  */
        }
    }
}

