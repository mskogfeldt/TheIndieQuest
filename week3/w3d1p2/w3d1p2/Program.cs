using System;
using System.Collections.Generic;

namespace w3d1p2
{
    class Program
    {
        static void Main(string[] args)
        {
            var party1 = new List<string> { "messi" };
            var party2 = new List<string> { "messi" , "ronaldo" };
            var party3 = new List<string> { "messi", "ronaldo", "zlatan" };
            var party4 = new List<string> { "messi", "ronaldo", "zlatan", "brolin" };
            var party5 = new List<string> { "messi", "ronaldo", "zlatan", "brolin", "mbape", "aslani"};
            //var listOfCharacters = new List<string> { "Ronaldo", "Messi", "Zlatan", "Chippen" };

            string survivingHeros1 = returnSurvivingHerosText(party1);
            gameEndsHappily(survivingHeros1);

            string survivingHeros2 = returnSurvivingHerosText(party2);
            gameEndsHappily(survivingHeros2);

            string survivingHeros3 = returnSurvivingHerosText(party3);
            gameEndsHappily(survivingHeros3);

            string survivingHeros4 = returnSurvivingHerosText(party4);
            gameEndsHappily(survivingHeros4);

            string survivingHeros5 = returnSurvivingHerosText(party5);
            gameEndsHappily(survivingHeros5);

            string survivingHeros1c = returnSurvivingHerosText(party1, false);
            gameEndsHappily(survivingHeros1);

            string survivingHeros2c = returnSurvivingHerosText(party2, false);
            gameEndsHappily(survivingHeros2);

            string survivingHeros3c = returnSurvivingHerosText(party3, false);
            gameEndsHappily(survivingHeros3);

            string survivingHeros4c = returnSurvivingHerosText(party4, false);
            gameEndsHappily(survivingHeros4);

            string survivingHeros5c = returnSurvivingHerosText(party5, false);
            gameEndsHappily(survivingHeros5);


            bool serialComma = false;

            string returnSurvivingHerosText(List<string> listOfCharacters, bool serialComma = true)
            {
                string heros = "";
                string and = " and ";
                string comma = ", ";
                int checkForCommaAndAnd = listOfCharacters.Count - 1;
                for (int i = 0; i < listOfCharacters.Count; i++)
                {
                    heros += listOfCharacters[i];
                    if (checkForCommaAndAnd == 1)
                    {
                        if (serialComma == false && i >= 1)
                        {
                            heros += and;
                        }
                        else
                        {
                            heros += comma;
                        }
                        
                    }
                    else
                    {
                        if (checkForCommaAndAnd >= 2)
                        {
                            heros += comma;
                        }
                    }
                    checkForCommaAndAnd -= 1;
                }
                return heros;
            }

            void gameEndsHappily(string herosInParty)
            {
                Console.WriteLine($"The heroes in the party are: {herosInParty} ");
            }
        }
    }
}
