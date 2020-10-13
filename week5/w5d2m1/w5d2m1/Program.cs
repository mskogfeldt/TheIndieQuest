using System;
using System.Collections.Generic;
using System.Collections.Specialized;

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
                if (firstThrow == 10) continue;
                else bowlingResults[1][i] = ThrowSecondBall(firstThrow);
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
            
            List<int> longList = MakeListOfNumberForCalcutalionOfPoints(bowlingResults);
            int[] pointsForEachRound = CalculateTotalPoints(bowlingResults, longList);
           
            printResults(bowlingResults, longList, pointsForEachRound);

       

            List<int> MakeListOfNumberForCalcutalionOfPoints(int[][] arrayOfBowlingScores)
            {
                var oneLongListForCalculations = new List<int> { };
                for (int i = 0; i < 10; i++)
                {
                    oneLongListForCalculations.Add(arrayOfBowlingScores[0][i]);
                    if (arrayOfBowlingScores[0][i] != 10) oneLongListForCalculations.Add(arrayOfBowlingScores[1][i]);
                }
                if (arrayOfBowlingScores[0][9] == 10)
                {
                    oneLongListForCalculations.Add(arrayOfBowlingScores[2][0]);
                    oneLongListForCalculations.Add(arrayOfBowlingScores[2][1]);
                }
                else if (arrayOfBowlingScores[0][9] + arrayOfBowlingScores[1][9] == 10) oneLongListForCalculations.Add(arrayOfBowlingScores[2][0]);
                return oneLongListForCalculations;

            }

            int GetTheNextTwoRollsWhenStriking(List<int> listOfAllThrows, int theThrowInex)
            {
                int theDynamicDuo = 0;
                if (theThrowInex +2 < listOfAllThrows.Count)
                {
                    theDynamicDuo += listOfAllThrows[theThrowInex + 1];
                    theDynamicDuo += listOfAllThrows[theThrowInex + 2];
                }
                else if (theThrowInex + 1 < listOfAllThrows.Count)
                {
                    theDynamicDuo += listOfAllThrows[theThrowInex + 1];
                }
                return theDynamicDuo;
            }

            int GetTheNextRollsWhenSparring(List<int> listOfAllThrows, int theThrowInex)
            {
                int extraPoints = 0;
                if (theThrowInex + 2 < listOfAllThrows.Count)
                {
                    extraPoints += listOfAllThrows[theThrowInex + 2];
                }
                return extraPoints;
            }

            int[] CalculateTotalPoints(int[][] frameByFramePoints, List<int> listOfAllThrows)
            {
                int countedThrows = 0;
                int[] results = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    if (frameByFramePoints[0][i] == 10)
                    {
                        results[i] = 10 + GetTheNextTwoRollsWhenStriking(listOfAllThrows, countedThrows);
                        countedThrows++;
                    }
                    else if (frameByFramePoints[0][i] + frameByFramePoints[1][i] == 10)
                    {
                        results[i] = 10 + GetTheNextRollsWhenSparring(listOfAllThrows, countedThrows);
                        countedThrows += 2;
                    }
                    else
                    {
                        results[i] += frameByFramePoints[0][i] + frameByFramePoints[1][i];
                        countedThrows += 2;
                    }

                }
                return results;
            }

            int ThrowFirstBall()
            {
                return random.Next(0, 11);
            }

            int ThrowSecondBall(int firstBall)
            {
                return random.Next(0, 11 - firstBall);
            }


            void printResults(int[][] frameByFramePoints, List<int> listOfAllThrows, int[] roundPoints)
            {
                int score = 0;
                for (int i = 0; i < 10; i++)
                {
                    int totalPinns = 0;
                    int frame = i + 1;
                    Console.WriteLine("Frame " + frame);
                    if (frameByFramePoints[0][i] == 10)
                    {
                        totalPinns += frameByFramePoints[0][i];
                        Console.WriteLine("Roll 1: x");
                    }
                    else
                    {
                        if (frameByFramePoints[0][i] == 0)
                        {
                            Console.WriteLine("Roll 1: -");
                        }
                        else
                        {
                            totalPinns += frameByFramePoints[0][i];
                            Console.WriteLine("Roll 1: " + frameByFramePoints[0][i]);
                        }
                        if (frameByFramePoints[1][i] == 0)
                        {
                            Console.WriteLine("Roll 2: -");
                        }
                        else if (frameByFramePoints[0][i] + frameByFramePoints[1][i] == 10)
                        {
                            totalPinns += frameByFramePoints[1][i];
                            Console.WriteLine("Roll 2: /");
                        }
                        else
                        {
                            totalPinns += frameByFramePoints[1][i];
                            Console.WriteLine("Roll 2: " + frameByFramePoints[1][i]);
                        }
                    }
                    if (i == 9 && frameByFramePoints[0][i] == 10)
                    {
                        if (frameByFramePoints[2][0] == 10 && frameByFramePoints[2][1] == 10)
                        {
                            totalPinns += frameByFramePoints[2][0];
                            Console.WriteLine("Roll 2: x");
                            totalPinns += frameByFramePoints[2][1];
                            Console.WriteLine("Roll 3: x");
                        }
                        else if (bowlingResults[2][0] == 10)
                        {
                            totalPinns += frameByFramePoints[2][0];
                            Console.WriteLine("Roll 2: x");

                        }
                        else if (frameByFramePoints[2][0] == 0)
                        {
                            Console.WriteLine("Roll 2: x");
                        }
                        else
                        {
                            totalPinns += frameByFramePoints[2][0];
                            Console.WriteLine("Roll 2: " + frameByFramePoints[2][0]);
                        }
                        if (frameByFramePoints[2][1] == 0)
                        {
                            Console.WriteLine("Roll 3: -");
                        }
                        else if (frameByFramePoints[2][0] + frameByFramePoints[2][1] == 10)
                        {
                            totalPinns += frameByFramePoints[2][1];
                            Console.WriteLine("Roll 3: /");
                        }
                        else
                        {
                            totalPinns += frameByFramePoints[2][1];
                            Console.WriteLine("Roll 3: " + frameByFramePoints[2][1]);
                        }
                    }
                    else if (i == 9 && frameByFramePoints[0][i] + frameByFramePoints[1][i] == 10)
                    {
                        if (frameByFramePoints[2][0] == 10)
                        {
                            totalPinns += frameByFramePoints[2][0];
                            Console.WriteLine("Roll 3: x");
                        }
                        else if (frameByFramePoints[2][0] == 0)
                        {
                            Console.WriteLine("Roll 3: -");
                        }
                        else
                        {
                            totalPinns += frameByFramePoints[2][0];
                            Console.WriteLine("Roll 3: " + frameByFramePoints[2][0]);
                        }
                    }
                    Console.WriteLine("Knocked Down Pinns " + totalPinns);
                    Console.WriteLine("Points gained: " + roundPoints[i]);
                    score += roundPoints[i];
                    Console.WriteLine("Score " + score);
                }
            }
        }
    }
}
