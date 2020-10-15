using System;
using System.Collections.Generic;
using System.Text;

namespace w3d5m1
{
    public class FrameWork
    {
        string f = " ";
        string s = " ";

        string theFrame = "FRAME ";
        string frameOne = "+-----+";
        string frameTwo = "| | | |";
        string frameThree = "| ----|";
        string frameFour = "|     |";

        List<string> listFrame = new List<string> { };
        List<string> listFrameOne = new List<string> { };
        List<string> listFrameTwo = new List<string> { };
        List<string> listFrameThree = new List<string> { };
        List<string> listFrameFour = new List<string> { };
        List<string> listFrameFive = new List<string> { };

        public string changeStringAfterThrow(string throwOne, string throwTwo, int frame)
        {
            string returnString = "";
            returnString += "| |" + throwOne + "|" + throwTwo + "|";
            return returnString;       
        }

        public void changeStringInList(string newScore, int frame)
        {
            listFrameTwo[frame - 1] = newScore; 
        }

        public void addFrameToTheStrings(string newScore, int frame)
        {
            listFrame.Add(theFrame);
            listFrameOne.Add(frameOne);
            listFrameTwo.Add(newScore);
            listFrameThree.Add(frameThree);
            listFrameFour.Add(frameFour);
            listFrameFive.Add(frameOne);
        }

         
/*
        public void addFrame(List<string> frameList, string framePart, string trowOne, string trowTwo, int frame)
        {
            frameList
        }*/

       
    }
}
