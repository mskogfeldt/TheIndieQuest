using System;
using System.Collections.Generic;
using System.Text;

namespace w3d5m1
{
    public class FrameWork
    {/*
        string f = " ";
        string s = " ";

        //string theFrame = "FRAME ";
        string frameOne   = "─┬─┬─┬";
        string frameTwo   = " | | |";
        string frameThree = " └─┴─┤";
        string frameFour  = "     |";
        string frameFive  = "─────┴";

        string frontOne   = "┌";
        string frontTwo   = "│";
        string frontThree = "│";
        string frontFour  = "│";
        string frontFive  = "└";


        string endOne   = "─┬─┬─┬─┐";
        string endTwo   = " │ │ │ │";
        string endThree = " └─┴─┴─│";
        string endFour  = "       │";
        string endFive  = "───────┘";
        */


        List<string> listFrameOne = new List<string>   { "┌", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬", "─┬─┬─┬─┐" };
        List<string> listFrameTwo = new List<string>   { "│", " | | |", " | | |", " | | |", " | | |", " | | |", " | | |", " | | |", " | | |", " | | |", " │ │ │ │" };
        List<string> listFrameThree = new List<string> { "│", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┤", " └─┴─┴─│" };
        List<string> listFrameFour = new List<string>  { "│", "     |", "     |", "     |", "     |", "     |", "     |", "     |", "     |", "     |", "       │" };
        List<string> listFrameFive = new List<string>  { "└", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "─────┴", "───────┘" };

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

        public string changeStringAfterThrow(string throwOne, string throwTwo)
        {
            string returnString = "";
            returnString += " |" + throwOne + "|" + throwTwo + "|";
            return returnString;       
        }

        public string changeStringAfterThrowEndFrame(string throwOne, string throwTwo, string ThrowThree)
        {
            string returnString = "";
            returnString += " |" + throwOne + "|" + throwTwo + "|" + ThrowThree + "|";
            return returnString;
        }

        public string changeScoreAfterTrow(string newScore)
        {
            string returnString = "";
            if (newScore.Length == 3) returnString += " " + newScore + " │";
            else if (newScore.Length == 2) returnString += "  " + newScore + " │";
            else if (newScore.Length == 1) returnString += "   " + newScore + " │";
            return returnString;
        }

        public string changeScoreAfterTrowEndLane(string newScore)
        {
            string returnString = "";
            if (newScore.Length == 3) returnString += " " + newScore + " │";
            else if (newScore.Length == 2) returnString += "  " + newScore + "  │";
            else if (newScore.Length == 1) returnString += "   " + newScore + "  │";
            return returnString;
        }

        public void changeStringInList(string newScore, int frame)
        {
            listFrameTwo[frame - 1] = newScore;
        }

        public void changeScoreInList(string newScore, int frame)
        {
            listFrameFour[frame - 1] = newScore; 
        }

        /*
        public void addFrameToTheStrings(string newScore, int frame)
        {
            //listFrame.Add(theFrame);
            listFrameOne[frame] = newScore;
            listFrameTwo.Add(newScore);
            listFrameThree.Add(frameThree);
            listFrameFour.Add(frameFour);
            listFrameFive.Add(frameOne);
        }*/

        //public void buildTheFrame()

         
/*
        public void addFrame(List<string> frameList, string framePart, string trowOne, string trowTwo, int frame)
        {
            frameList
        }*/

       
    }
}
