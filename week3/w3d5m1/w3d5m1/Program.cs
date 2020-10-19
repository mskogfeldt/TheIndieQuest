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
            /*int totalThrows = 0;*/

            List<int> longListOfThrows = new List<int> { }; //MakeListOfNumberForCalcutalionOfPoints(bowlingResults);
            int[] pointsForEachRound = new int[10]; //CalculateTotalPoints(bowlingResults, longList);
            int[] totalPoints = new int[10];



            playFrame(service.score, 1/*, totalThrows*/);

            //int frame = 1;

            void presentBeforeThrowing(List<int> pins)
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
            void returnExtraPointsForStrikesAndsparrs(int frame)
            {
                if (frame > 2 && bowlingResults[0][frame - 3] == 10 && bowlingResults[0][frame - 2] == 10)
                {
                    bowlingResults[0][frame - 3] += bowlingResults[0][frame - 1];
                }
                else if (frame > 1 && bowlingResults[0][frame - 2] == 10)
                {
                    bowlingResults[0][frame - 2] += bowlingResults[0][frame - 1] + bowlingResults[1][frame - 1];
                }
                else if (frame > 1 && bowlingResults[0][frame - 2] + bowlingResults[1][frame - 2] == 10)
                {
                    bowlingResults[0][frame - 2] += bowlingResults[0][frame - 1];
                }
            }

            void extraThrowsForStrikeInFrameTen()
            {

            }



            void playFrame(int score, int frame/*, int totalThrows*/)
            {
                var pins = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                var pinsForFirstExtraTry = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                var pinsForSecondExtraTry = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                // string throwOne = " ";
                string throwTwo = " ";
                ///string throwTwo = " ";
                //int frame = 1;

                presentBeforeThrowing(pins);
                int laneToThrowTheBall = userIo.letPlayerChoseWhereToTrowTheBall();
                service.knockPins(pins, laneToThrowTheBall, 0);
                int result = service.calculateScoreFirstThrow(pins);
                bowlingResults[0][frame - 1] = result;
                pointsForEachRound[frame - 1] += result;
              //  returnExtraPointsForStrikesAndsparrs(frame);

               // longListOfThrows.Add(result);
                //totalThrows++;
                //service.addToScore(result); 
                string firstResultSymbol = service.makeTheRightSymbolRollOne(result);
                string firstResultCompleteString = scoreBoard.changeSymbolAfterThrow(firstResultSymbol, throwTwo);

                scoreBoard.changeStymbolInList(firstResultCompleteString, frame);
               // scoreBoard.changeScoreInList(service.takeIntMakeString(result), frame);
              
                if (result != 10)
                {
                    /*string changeScoreForThisFrame = scoreBoard.changeSymbolAfterThrow(firstResultSymbol, throwTwo);
                    scoreBoard.changeScoreInList(changeScoreForThisFrame, frame);*/

                   // presentBeforeThrowing(pins);
                    int laneToThrowTheSecondBall = userIo.letPlayerChoseWhereToTrowTheBall();
                    service.knockPins(pins, laneToThrowTheSecondBall, 0);
                    int resultForSecondBall = service.calculateScoreSecondAndThirdThrow(pins, result);
                    bowlingResults[1][frame - 1] = resultForSecondBall;
                    pointsForEachRound[frame - 1] += resultForSecondBall;
                    longListOfThrows.Add(result);
                   // totalThrows++;
                    // service.addToScore(resultForSecondBall);
                    string secondResultSymbol = service.makeTheRightSymbolRollTwo(result, resultForSecondBall);
                    string secondResultCompleteString = scoreBoard.changeSymbolAfterThrow(firstResultSymbol, secondResultSymbol);
                    scoreBoard.changeStymbolInList(secondResultCompleteString, frame);
                    if (result + resultForSecondBall != 10)
                    {
                        //pointsForEachRound[frame - 1] = result + resultForSecondBall;
                        
                        string pointForScoreboard = service.takeIntMakeString(service.returnTotalScore(pointsForEachRound));
                        string scoreForScoreBoard = scoreBoard.changeScoreAfterTrow(pointForScoreboard);
                        scoreBoard.changeScoreInList(scoreForScoreBoard, frame);
                       
                        //scoreBoard.changeScoreInList(service.takeIntMakeString(service.takeIntMakeString(pointsForEachRound[frame - 1]), frame)); 
                    }
                    returnExtraPointsForStrikesAndsparrs(frame);
                    if (frame == 10 && bowlingResults[0][9] == 10)
                    {
                        int laneToThrowTheFirstExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                        service.knockPins(pinsForSecondExtraTry, laneToThrowTheFirstExtraBall, 0);
                        int resultForFirstExtraBall = service.calculateScoreFirstThrow(pins);
                        bowlingResults[1][9] = resultForFirstExtraBall;
                        pointsForEachRound[frame - 1] += result;
                        string firstExtraResultSymbol = service.makeTheRightSymbolRollOne(resultForFirstExtraBall);
                        string firstExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame("x", firstExtraResultSymbol, throwTwo);
                        if (resultForFirstExtraBall == 10)
                        {
                            int laneToThrowTheSecondExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                            service.knockPins(pinsForSecondExtraTry, laneToThrowTheFirstExtraBall, 0);
                            int resultForSecondExtraBall = service.calculateScoreFirstThrow(pins);
                            bowlingResults[1][9] = resultForSecondExtraBall;
                            pointsForEachRound[frame - 1] += result;
                            string firstExtraResultSymbol = service.makeTheRightSymbolRollOne(resultForFirstExtraBall);
                            string firstExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame("x", firstExtraResultSymbol, throwTwo);
                        }
                    }



                    
                    presentBeforeThrowing(pins);
                   

                }
              /*  else
                {
                    presentBeforeThrowing(pins);
                    pointsForEachRound[frame - 1] += 10;
                    userIo.printStrike();
                }
                if (frame > 2 && bowlingResults[0][frame - 3] == 10 && bowlingResults[0][frame - 2] == 10) 
                    {
                    bowlingResults[0][frame - 3] += bowlingResults[0][frame - 1];
                }
                else if (frame > 1 && bowlingResults[0][frame - 2] == 10)
                {
                    bowlingResults[0][frame - 2] += bowlingResults[0][frame - 1] + bowlingResults[1][frame - 1];
                }
                else if (frame > 1 && bowlingResults[0][frame - 2] + bowlingResults[1][frame - 2] == 10)
                {
                    bowlingResults[0][frame - 2] += bowlingResults[0][frame - 1];
                }*/
            }
        }
    }
}
