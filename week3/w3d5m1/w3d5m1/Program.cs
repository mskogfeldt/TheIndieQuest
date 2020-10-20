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
         
            int[][] bowlingResults = new int[2][];
            bowlingResults[0] = new int[12];
            bowlingResults[1] = new int[11];
         
            int[] pointsForEachRound = new int[10]; 
           
            // Temporary TestingMethod
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
           

            void presentBeforeThrowing(List<int> pins)
            {
                userIo.printTheScoreBoard(scoreBoard.getListOne(), scoreBoard.getListTwo(), scoreBoard.getListThree(), scoreBoard.getListFour(), scoreBoard.getListFive());
                userIo.PrintPinns(pins);
                userIo.printGraphicsForTrowingTheBall();
            }

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

                
                // Throw One!
                int laneToThrowTheBall = userIo.letPlayerChoseWhereToTrowTheBall();
                service.knockPins(pins, laneToThrowTheBall, 0);
                //int result = service.calculateScoreFirstThrow(pins);
                int result = 10;
                /**/
                bowlingResults[0][frame - 1] = result;
                pointsForEachRound[frame - 1] += result;
                /**/
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

                // If there is a second Throw it stars here
                if (result != 10)
                {
                    presentBeforeThrowing(pins);
                    int laneToThrowTheSecondBall = userIo.letPlayerChoseWhereToTrowTheBall();
                    service.knockPins(pins, laneToThrowTheSecondBall, 0);
                    int resultForSecondBall = service.calculateScoreSecondAndThirdThrow(pins, result);
                    //int resultForSecondBall = 10-result;
                    /**/
                    bowlingResults[1][frame - 1] = resultForSecondBall;
                    pointsForEachRound[frame - 1] += resultForSecondBall;
                    /**/
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
                }

                // Here starts the extra tolls if 10th frame was  a strike!
                if (frame == 10 && bowlingResults[0][9] == 10)
                {
                    presentBeforeThrowing(pinsForFirstExtraTry);
                    int laneToThrowTheFirstExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                    service.knockPins(pinsForFirstExtraTry, laneToThrowTheFirstExtraBall, 0);
                    int resultForFirstExtraBall = service.calculateScoreFirstThrow(pinsForFirstExtraTry);
                    /**/
                    bowlingResults[0][10] = resultForFirstExtraBall;
                    pointsForEachRound[frame - 1] += resultForFirstExtraBall;
                    /**/
                    string firstExtraResultSymbol = service.makeTheRightSymbolRollOne(resultForFirstExtraBall);
                    string firstExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame("x", firstExtraResultSymbol, throwNotDone);
                    scoreBoard.changeStymbolInList(firstExtraResultCompleteString, frame);
                    //calculateExtraPointsForEarlierStrikesAndSparrs(frame + 1);
                    calculateExtraPointsForEarlierStrikesAndSparrs(frame);
                    checkIfUpdateForScorboardDueToEarlierStriekesAndSparres(frame + 1);

                    // If first extra roll was a strike, here the second extra roll starts
                    if (resultForFirstExtraBall == 10)
                    {
                        presentBeforeThrowing(pinsForSecondExtraTry);
                        int laneToThrowTheSecondExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                        service.knockPins(pinsForSecondExtraTry, laneToThrowTheSecondExtraBall, 0);
                        int resultForSecondExtraBall = service.calculateScoreFirstThrow(pinsForSecondExtraTry);
                        /**/
                        bowlingResults[0][11] = resultForSecondExtraBall;
                        pointsForEachRound[frame - 1] += resultForSecondExtraBall;
                        /**/
                        string secondExtraResultSymbol = service.makeTheRightSymbolRollOne(resultForSecondExtraBall);
                        string secondExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame("x", firstExtraResultSymbol, secondExtraResultSymbol);
                        scoreBoard.changeStymbolInList(secondExtraResultCompleteString, frame - 1);
                        updateScoreBoard(frame);
                    }

                    // If first extra roll was NOT a strike, here the second roll starts
                    else
                    {
                        presentBeforeThrowing(pinsForFirstExtraTry);
                        int laneToThrowTheSecondExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                        service.knockPins(pinsForFirstExtraTry, laneToThrowTheSecondExtraBall, 0);
                        int resultForSecondExtraBall = service.calculateScoreSecondAndThirdThrow(pinsForFirstExtraTry, resultForFirstExtraBall);
                        /**/
                        bowlingResults[1][10] = resultForSecondExtraBall;
                        pointsForEachRound[frame - 1] += resultForSecondExtraBall;
                        /**/
                        string secondExtraResultSymbol = service.makeTheRightSymbolRollTwo(resultForFirstExtraBall, resultForSecondExtraBall);
                        string secondExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame("x", firstExtraResultSymbol, secondExtraResultSymbol);
                        scoreBoard.changeStymbolInList(secondExtraResultCompleteString, frame);
                        updateScoreBoard(frame);
                    }
                }

                // If 10th Frame was a sparr, here starts the extra throw
                else if (frame == 10 && bowlingResults[0][9] + bowlingResults[1][9] == 10 && bowlingResults[0][9] != 10)
                {

                    presentBeforeThrowing(pinsForFirstExtraTry);
                    string firstNumberForDisplay = scoreBoard.getFirstSymbolFrameTen();
                    string secondNumberForDisplay = scoreBoard.getSecondSymbolFrameTen();

                    int laneToThrowTheFirstExtraBall = userIo.letPlayerChoseWhereToTrowTheBall();
                    service.knockPins(pinsForFirstExtraTry, laneToThrowTheFirstExtraBall, 0);
                    int resultForFirstExtraBall = service.calculateScoreFirstThrow(pinsForFirstExtraTry);
                    /**/
                    bowlingResults[0][10] = resultForFirstExtraBall;
                    pointsForEachRound[frame - 1] += resultForFirstExtraBall;
                    /**/
                    string firstExtraResultSymbol = service.makeTheRightSymbolRollOne(resultForFirstExtraBall);
                    string firstExtraResultCompleteString = scoreBoard.changeSymbolAfterThrowEndFrame(firstNumberForDisplay, secondNumberForDisplay, firstExtraResultSymbol);
                    scoreBoard.changeStymbolInList(firstExtraResultCompleteString, frame);
                    updateScoreBoard(frame);
                }
            }

           /*void playBounudRound()*/
        }
    }
}
