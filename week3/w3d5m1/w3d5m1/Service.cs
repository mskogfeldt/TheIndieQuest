using System;
using System.Collections.Generic;
using System.Text;

namespace w3d5m1
{
    class Service
    {
        public int score = 0;

        public void addToScore(int pointsEarned)
        {
            score += pointsEarned;
        }


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

        public void knockPins(List<int> pins, int lane)
        {
            if (lane < 1 || lane > 7) Console.WriteLine("Ha MISS!");
            if (lane == 1) pins[6] = 0;
            if (lane == 2) pins[3] = 0;
            if (lane == 3 && pins[1] == 0) pins[7] = 0;
            if (lane == 3 && pins[1] > 0) pins[1] = 0;
            if (lane == 4 && pins[0] == 0) pins[4] = 0;
            if (lane == 4 && pins[0] > 0) pins[0] = 0;
            if (lane == 5 && pins[2] == 0) pins[8] = 0;
            if (lane == 5 && pins[2] > 0) pins[2] = 0;
            if (lane == 6) pins[5] = 0;
            if (lane == 7) pins[9] = 0;

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
