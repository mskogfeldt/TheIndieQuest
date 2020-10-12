using System;

namespace w5d2m1
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

                int[][] bowlingResults = new int[3][];
                bowlingResults[0] = new int[10];
                bowlingResults[1] = new int[10];
                bowlingResults[2] = new int[2];
                for (int i = 0; i < 10; i++)
            {
                int firstThrow = ThrowFirstBall();
                bowlingResults[0][i] = firstThrow;
                bowlingResults[1][i] = ThrowSecondBall(firstThrow);
            }
            if (bowlingResults[0][9] == 10)
            {
                int newThrow = ThrowFirstBall();
                bowlingResults[2][0] = newThrow;
                bowlingResults[2][1] = ThrowSecondBall(newThrow);
            }
            else if (bowlingResults[0][9] + bowlingResults[1][9] == 10)
            {
                int newThrow = ThrowFirstBall();
                bowlingResults[2][0] = newThrow;
            }

            printResults();

            int ThrowFirstBall()
            {
                return random.Next(0, 11);
            }

            int ThrowSecondBall(int firstBall)
            {
                return random.Next(0, 11 - firstBall);
            }

            void printResults()
            {
                for (int i = 0; i < 10; i++)
                {
                    int totalPinns = 0;
                    int frame = i + 1;
                    Console.WriteLine("Frame " + frame);
                    if (bowlingResults[0][i] == 10)
                    {
                        totalPinns += bowlingResults[0][i];
                        Console.WriteLine("Roll 1: x");
                    }
                    else
                    {
                        if (bowlingResults[0][i] == 0)
                        {
                            Console.WriteLine("Roll 1: -");
                        }
                        else 
                        {
                            totalPinns += bowlingResults[0][i];
                            Console.WriteLine("Roll 1: " + bowlingResults[0][i]);
                        }
                        if (bowlingResults[1][i] == 0)
                        {
                            Console.WriteLine("Roll 2: -");
                        }
                        else if (bowlingResults[0][i] + bowlingResults[1][i] == 10)
                        {
                            totalPinns += bowlingResults[1][i];
                            Console.WriteLine("Roll 2: /");
                        }
                        else
                        {
                            totalPinns += bowlingResults[1][i];
                            Console.WriteLine("Roll 2: " + bowlingResults[1][i]);
                        }
                    }
                    if (i == 9 && bowlingResults[0][i] == 10)
                    {
                        if(bowlingResults[2][0] == 10 && bowlingResults[2][1] == 10)
                        {
                            totalPinns += bowlingResults[2][0];
                            Console.WriteLine("Roll 2: x");
                            totalPinns += bowlingResults[2][1];
                            Console.WriteLine("Roll 3: x");
                        }
                        else if(bowlingResults[2][0] == 10)
                        {
                            totalPinns += bowlingResults[2][0];
                            Console.WriteLine("Roll 2: x");
                           /* totalPinns += bowlingResults[2][1];
                            Console.WriteLine("Roll 3: " + bowlingResults[2][1]);*/
                        }
                        else if(bowlingResults[2][0] == 0)
                        {
                            Console.WriteLine("Roll 2: x");
                        }
                        else 
                        {
                            totalPinns += bowlingResults[2][0];
                            Console.WriteLine("Roll 2: " + bowlingResults[2][0]);
                        }
                        if (bowlingResults[2][1] == 0)
                        {
                            Console.WriteLine("Roll 3: -");
                        }
                        else if (bowlingResults[2][0] + bowlingResults[2][1] == 10)
                        {
                            totalPinns += bowlingResults[2][1];
                            Console.WriteLine("Roll 3: /"); 
                        }
                        else
                        {
                            totalPinns += bowlingResults[2][1];
                            Console.WriteLine("Roll 3: " + bowlingResults[2][1]);
                        }
                    }
                    else if (i == 9 && bowlingResults[0][i] + bowlingResults[1][i] == 10)
                    {
                        if (bowlingResults[2][0] == 10)
                        {
                            totalPinns += bowlingResults[2][0];
                            Console.WriteLine("Roll 3: x");
                        }
                        else if(bowlingResults[2][0] == 0)
                        {
                            Console.WriteLine("Roll 3: -");
                        }
                        else
                        {
                            totalPinns += bowlingResults[2][0];
                            Console.WriteLine("Roll 3: " + bowlingResults[2][0]);
                        }
                    }
                    Console.WriteLine("Knocked Down Pinns " + totalPinns);
                }
            }
        }
    }
}
