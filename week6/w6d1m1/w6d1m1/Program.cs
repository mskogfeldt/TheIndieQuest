using System;
using System.Collections.Generic;
using System.IO;

namespace w6d1m1
{
    class Program
    {
        static void Main(string[] args)
        {
            string link = @"MonsterManual.txt";

            string[] monsterNames = File.ReadAllLines(link);
            
            List<string> listOfMonsterNames = new List<string> { monsterNames[0] };

            for (int i = 1; i < monsterNames.Length; i++)
            {
                if (monsterNames[i - 1] == "")
                {
                    listOfMonsterNames.Add(monsterNames[i]);
                }
            }

            Console.WriteLine("Monsters in the manual are");
            foreach (string name in listOfMonsterNames) Console.WriteLine(name);
        }
    }
}
