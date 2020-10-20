using System;
using System.Collections.Generic;
using System.Text;

namespace w3d5m1
{
    public class FrameWork
    {
        List<string> listFrameOne = new List<string> { "┌", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬─┐" };
        List<string> listFrameTwo = new List<string> { "│", " | | |", " | | |", " | | |", " | | |", " | | |", " | | |", " | | |", " | | |", " | | |", " │ │ │ │" };
        List<string> listFrameThree = new List<string> { "│", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┴─│" };
        List<string> listFrameFour = new List<string> { "│", "     |", "     |", "     |", "     |", "     |", "     |", "     |", "     |", "     |", "       │" };
        List<string> listFrameFive = new List<string> { "└", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "───────┘" };

        List<bool> printPointsForFrame = new List<bool> { false, false, false, false, false, false, false, false, false, false };




        public List<string> getListOne()
        {
            return listFrameOne;
        }

        public List<string> getListTwo()
        {
            return listFrameTwo;
        }

        public List<string> getListThree()
        {
            return listFrameThree;
        }

        public List<string> getListFour()
        {
            return listFrameFour;
        }

        public List<string> getListFive()
        {
            return listFrameFive;
        }

       /* public string takeIntMakeString(int number)
        {
            string word = number.ToString();
            return word;
        }

        public string makeTheRightSymbolRollOne(int firstRoll)
        {
            if (firstRoll == 10) return "x";
            if (firstRoll == 0) return "-";
            return takeIntMakeString(firstRoll);
        }*/

        public string getFirstSymbolFrameTen()
        {
            string frameTwo = listFrameTwo[9];
            return frameTwo.Substring(2,1);
        }

        public string getSecondSymbolFrameTen()
        {
            string frameTwo = listFrameTwo[9];
            return frameTwo.Substring(4, 1);
        }

        public string changeSymbolAfterThrow(string throwOne, string throwTwo)
        {
            string returnString = "";
            returnString += " |" + throwOne + "|" + throwTwo + "|";
            return returnString;       
        }

        public string changeSymbolAfterThrowEndFrame(string throwOne, string throwTwo, string ThrowThree)
        {
            string returnString = "";
            returnString += " |" + throwOne + "|" + throwTwo + "|" + ThrowThree + "|";
            return returnString;
        }

        public string changeScoreAfterTrow(string newScore)
        {
            return newScore.PadLeft(4) + " │";
        }

        public string changeScoreAfterTrowEndLane(string newScore)
        {
            
            return newScore.PadLeft(6) + " │";
        
        }

        public void changeStymbolInList(string newScore, int frame)
        {
            listFrameTwo[frame] = newScore;
        }

        public void changeScoreInList(string newScore, int frame)
        {
            listFrameFour[frame] = newScore; 
        }
    }
}
