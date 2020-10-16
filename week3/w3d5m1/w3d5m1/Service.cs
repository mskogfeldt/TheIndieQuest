using System;
using System.Collections.Generic;
using System.Text;

namespace w3d5m1
{
    class Service
    {
        public int score = 0;
        Random random = new Random();

        public void addToScore(int pointsEarned)
        {
            score += pointsEarned;
        }

/*
        static int KnockPinOnPath(int path, List<int> pinsStanding)
        {
            return 0;
        }*/


        public int calculateScoreFirstThrow(List<int> standingPinns)
        {
            int results = 0;
            for (int i = 0; i < 10; i++)
            {
                if (standingPinns[i] == 0) results++;
            }
            return results;
        }

        public int calculateScoreSecondAndThirdThrow(List<int> standingPinns, int alreadyKnockedDown)
        {
            int results = 0;
            for (int i = 0; i < 10; i++)
            {
                if (standingPinns[i] == 0) results++;
            }

            return results - alreadyKnockedDown;
        }
/*
        public int throwBall(int lane)
        {

        }*/

        public int doesObjectChangeLaneAfterImpact(int lane)
        {
            int procentige = random.Next(1, 101);
            if (procentige < 34) lane --;
            if (procentige < 68) lane += 0;
            if (procentige > 67) lane ++;
            return lane;

        }

        public void knockPins(List<int> pins, int lane, int coordinateY)
        {
            int rangeTravled = coordinateY;
            if (lane == 4 && pins[0] > 0 && rangeTravled == 0)
            {
                pins[0] = 0;
                int newLane1 = doesObjectChangeLaneAfterImpact(lane);
                int newLane2 = doesObjectChangeLaneAfterImpact(lane);
                rangeTravled++;
                knockPins(pins, newLane1, rangeTravled);
                knockPins(pins, newLane2, rangeTravled);
            }
            else if (rangeTravled == 0) rangeTravled++;
            if (lane == 3 && pins[1] > 0 && rangeTravled == 1)
            {
                pins[1] = 0;
                int newLane1 = doesObjectChangeLaneAfterImpact(lane);
                int newLane2 = doesObjectChangeLaneAfterImpact(lane);
                rangeTravled++;
                knockPins(pins, newLane1, rangeTravled);
                knockPins(pins, newLane2, rangeTravled);
            }
            else if (lane == 5 && pins[2] > 0 && rangeTravled == 1)
            {
                pins[2] = 0;
                int newLane1 = doesObjectChangeLaneAfterImpact(lane);
                int newLane2 = doesObjectChangeLaneAfterImpact(lane);
                rangeTravled++;
                knockPins(pins, newLane1, rangeTravled);
                knockPins(pins, newLane2, rangeTravled);
            }
            else if (rangeTravled == 1) rangeTravled++;
            if (lane == 2 && pins[3] > 0 && rangeTravled < 3)
            {
                rangeTravled = 2;
                pins[3] = 0;
                int newLane1 = doesObjectChangeLaneAfterImpact(lane);
                int newLane2 = doesObjectChangeLaneAfterImpact(lane);
                rangeTravled++;
                knockPins(pins, newLane1, rangeTravled);
                knockPins(pins, newLane2, rangeTravled);
            }
            else if (lane == 4 && pins[4] > 0 && rangeTravled == 2)
            {
                pins[4] = 0;
                int newLane1 = doesObjectChangeLaneAfterImpact(lane);
                int newLane2 = doesObjectChangeLaneAfterImpact(lane);
                rangeTravled++;
                knockPins(pins, newLane1, rangeTravled);
                knockPins(pins, newLane2, rangeTravled);
            }
            else if (lane == 6 && pins[5] > 0 && rangeTravled == 2)
            {
                pins[5] = 0;
                int newLane1 = doesObjectChangeLaneAfterImpact(lane);
                int newLane2 = doesObjectChangeLaneAfterImpact(lane);
                rangeTravled++;
                knockPins(pins, newLane1, rangeTravled);
                knockPins(pins, newLane2, rangeTravled);
            }
            else if (rangeTravled == 2) rangeTravled ++;
            if (lane == 1 && pins[6] > 0 && rangeTravled == 3) pins[6] = 0;
            if (lane == 3 && pins[7] > 0 && rangeTravled == 3) pins[7] = 0;
            if (lane == 5 && pins[8] > 0 && rangeTravled == 3) pins[8] = 0;
            if (lane == 7 && pins[9] > 0 && rangeTravled == 3) pins[9] = 0;
        }

        public string takeIntMakeString(int number)
        {
            string word = number.ToString();
            return word;
        }

        public string isPinStanding(List<int> pins, int indexOfPins)
        {
            if (pins[indexOfPins] > 0) return "0";
            else return " ";
        }


        
    }
}
