using System;
using System.Collections.Generic;

namespace w3d5m1
{
    class Program
    {
        static void Main(string[] args)
        {
            FrameWork scoreBoard = new FrameWork();
            userIo userIo = new userIo();
            Service service = new Service();


            int[][] bowlingResults = new int[3][];
            bowlingResults[0] = new int[10];
            bowlingResults[1] = new int[10];
            bowlingResults[2] = new int[2];

            List<int> longList = new List<int> { }; //MakeListOfNumberForCalcutalionOfPoints(bowlingResults);
            int[] pointsForEachRound = new int[10]; //CalculateTotalPoints(bowlingResults, longList);



            playFrame(service.score);

            int frame = 1;

            void presentBeforeThrowing(List<int> pins,string stringOne, string stringTwo, int frame)
            {
                //userIo.printTheFrame(stringOne, stringTwo, frame);
                userIo.printTheScoreBoard(scoreBoard.getListOne(), scoreBoard.getListTwo(), scoreBoard.getListThree(), scoreBoard.getListFour(), scoreBoard.getListFive());
                userIo.PrintPinns(pins);
                userIo.printGraphicsForTrowingTheBall();
            }
            /*    for (int i = 0; i < 10; i++)
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
        }*/


            void playFrame(int score)
            {
                var pins = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                string throwOne = " ";
                string throwTwo = " ";
                int frame = 1;

                presentBeforeThrowing(pins, throwOne, throwTwo, frame);
                int laneToThrowTheBall = userIo.letPlayerChoseWhereToTrowTheBall();
                service.knockPins(pins, laneToThrowTheBall, 0);
                int result = service.calculateScoreFirstThrow(pins);
                bowlingResults[0][frame - 1] = result;
                service.addToScore(result); /*OBS!! REMOVE????*/
                string firstResult = service.takeIntMakeString(result);
              
                if (result != 10)
                {
                    presentBeforeThrowing(pins, firstResult, throwTwo, frame);
                    int laneToThrowTheSecondBall = userIo.letPlayerChoseWhereToTrowTheBall();
                    service.knockPins(pins, laneToThrowTheSecondBall, 0);
                    int resultForSecondBall = service.calculateScoreSecondAndThirdThrow(pins, result);
                    service.addToScore(resultForSecondBall);
                    string secondResult = service.makeTheRightSymbolRollTwo(result, resultForSecondBall);
                    presentBeforeThrowing(pins, firstResult, secondResult, frame);

                }
                else
                {
                    Console.WriteLine("Strike!");
                }
                
            }
        }
    }
}
