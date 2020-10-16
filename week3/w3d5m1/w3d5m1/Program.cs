using System;
using System.Collections.Generic;

namespace w3d5m1
{
    class Program
    {
        static void Main(string[] args)
        {

           // var scoreBoard = new List<int> { };
           // var scoreBoardString = new List<string> { };
            FrameWork scoreBoard = new FrameWork();
            userIo userIo = new userIo();
            Service service = new Service();
            //int score = 0;
            playFrame(service.score);

            //var pinns = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int frame = 1;

            void presentBeforeThrowing(List<int> pins,string stringOne, string stringTwo, int frame)
            {
                //var pinns = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                userIo.printTheFrame(stringOne, stringTwo, frame);
                userIo.PrintPinns(pins);
                userIo.printGraphicsForTrowingTheBall();
            }


            void playFrame(int score)
            {
                var pins = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                string throwOne = " ";
                string throwTwo = " ";
                int frame = 1;

                presentBeforeThrowing(pins, throwOne, throwTwo, frame);
                int laneToThrowTheBall = userIo.letPlayerChoseWhereToTrowTheBall();
                service.knockPins(pins, laneToThrowTheBall, 0); ;
                int result = service.calculateScoreFirstThrow(pins);
                service.addToScore(result);
              /*  Console.WriteLine("RESULT! " + result);
                Console.WriteLine("Score! " + service.score);*/
              
                string firstResult = service.takeIntMakeString(result);
              //  Console.WriteLine(firstResult + " " + firstResult + " " + firstResult);
                if (result != 10)
                {
                    presentBeforeThrowing(pins, firstResult, throwTwo, frame);
                    int laneToThrowTheSecondBall = userIo.letPlayerChoseWhereToTrowTheBall();
                    service.knockPins(pins, laneToThrowTheSecondBall, 0);
                    int resultForSecondBall = service.calculateScoreSecondAndThirdThrow(pins, result);
                    service.addToScore(resultForSecondBall);
                    string secondResult = service.takeIntMakeString(resultForSecondBall);
                  /*  Console.WriteLine("RESULT! " + resultForSecondBall);
                    Console.WriteLine("Score! " + service.score);*/
                    presentBeforeThrowing(pins, firstResult, secondResult, frame);

                }
                else
                {
                    Console.WriteLine("Strike!");
                }
                //presentBeforeThrowing(pins, firstResult, secondResult, frame);
            }
        }
    }
}
