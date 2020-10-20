using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace w3d5m1
{
    class Program
    {
        static void Main(string[] args)
        {
            FrameWork scoreBoard = new FrameWork();
            userIo userIo = new userIo();
            Service service = new Service();
            //Score score = new Score();


            int[][] bowlingResults = new int[2][];
            bowlingResults[0] = new int[12];
            bowlingResults[1] = new int[11];
            //bowlingResults[2] = new int[2];
            
            /*int totalThrows = 0;*/

            
            int[] pointsForEachRound = new int[10]; //CalculateTotalPoints(bowlingResults, longList);
            int[] totalPoints = new int[10];
            

            void printArray()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"arraynumber " + i + " = " + pointsForEachRound[i]);
                }
            }
            


            playGame();

            userIo.printTheScoreBoard(scoreBoard.getListOne(), scoreBoard.getListTwo(), scoreBoard.getListThree(), scoreBoard.getListFour(), scoreBoard.getListFive());
            printArray();
            //int frame = 1;

            void presentBeforeThrowing(List<int> pins)
            {
                //userIo.printTheFrame(stringOne, stringTwo, frame);
                userIo.printTheScoreBoard(scoreBoard.getListOne(), scoreBoard.getListTwo(), scoreBoard.getListThree(), scoreBoard.getListFour(), scoreBoard.getListFive());
                userIo.PrintPinns(pins);
                userIo.printGraphicsForTrowingTheBall();
            }
            /*
                        calculateExtraPointsForEarlierStrikesTwoInARow(int frame)
                            {

                        }*/
            

            void calculateExtraPointsForEarlierStrikesAndSparrs(int frame)
            {
                if (frame > 2 && bowlingResults[0][frame - 3] == 10 && bowlingResults[0][frame - 2] == 10)
                {
                    bowlingResults[0][frame - 3] += bowlingResults[0][frame - 1] + bowlingResults[0][frame - 2];
                    pointsForEachRound[frame - 3] += bowlingResults[0][frame - 1] + bowlingResults[0][frame - 1];
                }
                else if (frame > 1 && bowlingResults[0][frame - 2] == 10 && bowlingResults[0][frame - 1] != 10)
                {
                    bowlingResults[0][frame - 2] += bowlingResults[0][frame - 1] + bowlingResults[1][frame - 1];
                    pointsForEachRound[frame - 2] += bowlingResults[0][frame - 1];
                }
                else if (frame > 1 && bowlingResults[0][frame - 2] + bowlingResults[1][frame - 2] == 10)
                {
                    bowlingResults[0][frame - 2] += bowlingResults[0][frame - 1];
                    pointsForEachRound[frame - 2] += bowlingResults[0][frame - 1];
                }
            }
           

            void checkIfUpdateForScorboardDueToEarlierStriekesAndSparres(int frame)
            {
                if (frame > 2 && bowlingResults[0][frame - 3] == 10 && bowlingResults[0][frame - 2] == 10)
                {
                    updateScoreBoard(frame - 2);
                }
                else if (frame > 1 && bowlingResults[0][frame - 2] == 10 && bowlingResults[0][frame - 1] != 10)
                {
                    updateScoreBoard(frame - 1);
                }
                else if (frame > 1 && bowlingResults[0][frame - 2] + bowlingResults[1][frame - 2] == 10)
                {
                    updateScoreBoard(frame - 1);
                }
            }
            /*string secondResultCompleteString = scoreBoard.changeSymbolAfterThrow(firstResultSymbol, secondResultSymbol);
              scoreBoard.changeStymbolInList(secondResultCompleteString, frame);
              calculateExtraPointsForEarlierStrikesAndSparrs(frame);
              checkIfUpdateForScorboardDueToEarlierStriekesAndSparres(frame);*/

            void updateScoreBoard(int frame)
            {
                if (frame < 10)
                {
                    string pointForScoreboard = service.takeIntMakeString(service.returnTotalScoreUpToPoint(pointsForEachRound, frame));
                    string scoreForScoreBoard = scoreBoard.changeScoreAfterTrow(pointForScoreboard);
                    scoreBoard.changeScoreInList(scoreForScoreBoard, frame);
                }
                else
                {
                    string pointForScoreboard = service.takeIntMakeString(service.returnTotalScoreUpToPoint(pointsForEachRound, frame));
                    string scoreForScoreBoard = scoreBoard.changeScoreAfterTrowEndLane(pointForScoreboard);
                    scoreBoard.changeScoreInList(scoreForScoreBoard, frame);
                }
            }

            void playGame()
            {

                for (int i = 0; i < 10; i++)
                {
                    int frame = i + 1;
                    playFrame(frame);
                }
            }

            void playFrame(int frame)
            {
                var pins = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                var pinsForFirstExtraTry = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                var pinsForSecondExtraTry = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                string throwNotDone = " ";

                presentBeforeThrowing(pins);

                int laneToThrowTheBall = userIo.letPlayerChoseWhereToTrowTheBall();
                service.knockPins(pins, laneToThrowTheBall, 0);
                //int result = service.calculateScoreFirstThrow(pins);
                int result = 10;
                bowlingResults[0][frame - 1] = result;
                pointsForEachRound[frame - 1] += result;
                string firstResultSymbol = service.makeTheRightSymbolRollOne(result);
                calculateExtraPointsForEarlierStrikesAndSparrs(frame);
                checkIfUpdateForScorboardDueToEarlierStriekesAndSparres(frame);
                if (frame < 10)
                {
                    string firstResultCompleteString = scoreBoard.changeSymbolAfterThrow(firstResultSymbol, throwNotDone);
                    scoreBoard.changeStymbolInList(firstResultCompleteString, frame);
                }
                else
                {
                    string firstResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame(firstResultSymbol, throwNotDone, throwNotDone);
                    scoreBoard.changeStymbolInList(firstResultCompleteString, frame);
                }
                if (result != 10)
                {
                    presentBeforeThrowing(pins);
                    int laneToThrowTheSecondBall = userIo.letPlayerChoseWhereToTrowTheBall();
                    service.knockPins(pins, laneToThrowTheSecondBall, 0);
                    int resultForSecondBall = service.calculateScoreSecondAndThirdThrow(pins, result);
                   
                    bowlingResults[1][frame - 1] = resultForSecondBall;
                    pointsForEachRound[frame - 1] += resultForSecondBall;

                    string secondResultSymbol = service.makeTheRightSymbolRollTwo(result, resultForSecondBall);
                    calculateExtraPointsForEarlierStrikesAndSparrs(frame);
                    checkIfUpdateForScorboardDueToEarlierStriekesAndSparres(frame);
                    if (frame < 10)
                    {
                        string secondResultCompleteString = scoreBoard.changeSymbolAfterThrow(firstResultSymbol, secondResultSymbol);
                        scoreBoard.changeStymbolInList(secondResultCompleteString, frame);
                       
                    }
                    else
                    {
                        string secondResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame(firstResultSymbol, secondResultSymbol, throwNotDone);
                        scoreBoard.changeStymbolInList(secondResultCompleteString, frame);
                    }
                    
                    if (result + resultForSecondBall != 10)
                    {
                            updateScoreBoard(frame);
                    }

                    if (frame == 10 && bowlingResults[0][9] == 10)
                    {
                        presentBeforeThrowing(pinsForFirstExtraTry);
                        int laneToThrowTheFirstExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                        service.knockPins(pinsForFirstExtraTry, laneToThrowTheFirstExtraBall, 0);
                        int resultForFirstExtraBall = service.calculateScoreFirstThrow(pinsForFirstExtraTry);
                        bowlingResults[0][10] = resultForFirstExtraBall;
                        pointsForEachRound[frame - 1] += resultForFirstExtraBall;
                        string firstExtraResultSymbol = service.makeTheRightSymbolRollOne(resultForFirstExtraBall);
                        string firstExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame("x", firstExtraResultSymbol, throwNotDone);
                        scoreBoard.changeStymbolInList(firstExtraResultCompleteString, frame);
                        calculateExtraPointsForEarlierStrikesAndSparrs(frame + 1);
                        checkIfUpdateForScorboardDueToEarlierStriekesAndSparres(frame + 1);

                        if (resultForFirstExtraBall == 10)
                        {
                            //frame++;
                            presentBeforeThrowing(pinsForSecondExtraTry);
                            int laneToThrowTheSecondExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                            service.knockPins(pinsForSecondExtraTry, laneToThrowTheSecondExtraBall, 0);
                            int resultForSecondExtraBall = service.calculateScoreFirstThrow(pinsForSecondExtraTry);
                            bowlingResults[0][11] = resultForSecondExtraBall;
                            pointsForEachRound[frame - 1] += result;

                            string secondExtraResultSymbol = service.makeTheRightSymbolRollOne(resultForSecondExtraBall);
                            string secondExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame("x", firstExtraResultSymbol, secondExtraResultSymbol);
                            scoreBoard.changeStymbolInList(secondExtraResultCompleteString, frame - 1);
                            updateScoreBoard(frame);
                        }
                        else
                        {
                            frame++;
                            presentBeforeThrowing(pinsForFirstExtraTry);
                            int laneToThrowTheSecondExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                            service.knockPins(pinsForFirstExtraTry, laneToThrowTheSecondExtraBall, 0);
                            int resultForSecondExtraBall = service.calculateScoreSecondAndThirdThrow(pinsForFirstExtraTry, resultForFirstExtraBall);
                            bowlingResults[1][10] = resultForSecondBall;
                            pointsForEachRound[frame - 1] += resultForSecondExtraBall;

                            string secondExtraResultSymbol = service.makeTheRightSymbolRollTwo(resultForFirstExtraBall, resultForSecondExtraBall);
                            string secondExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame("x", firstExtraResultSymbol, secondExtraResultSymbol);
                            scoreBoard.changeStymbolInList(secondExtraResultCompleteString, frame);
                            updateScoreBoard(frame);
                        }
                    }
                    else if (frame == 10 && bowlingResults[0][9] + bowlingResults[1][9] == 10)
                    {
                       
                        presentBeforeThrowing(pinsForFirstExtraTry);
                        string firstNumberForDisplay = scoreBoard.getFirstSymbolFrameTen();
                        string secondNumberForDisplay = scoreBoard.getSecondSymbolFrameTen();
                       
                        int laneToThrowTheFirstExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                        service.knockPins(pinsForFirstExtraTry, laneToThrowTheFirstExtraBall, 0);
                        int resultForFirstExtraBall = service.calculateScoreFirstThrow(pinsForFirstExtraTry);
                        bowlingResults[0][10] = resultForFirstExtraBall;
                        pointsForEachRound[frame - 1] += resultForFirstExtraBall;
                        string firstExtraResultSymbol = service.makeTheRightSymbolRollOne(resultForFirstExtraBall);
                        string firstExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame(firstNumberForDisplay, secondNumberForDisplay, firstExtraResultSymbol);
                        scoreBoard.changeStymbolInList(firstExtraResultCompleteString, frame);
                        updateScoreBoard(frame);
                    }
                }
            }

           /*void playBounudRound()*/
        }
    }
}
