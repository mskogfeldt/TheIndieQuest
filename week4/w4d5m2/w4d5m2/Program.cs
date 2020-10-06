using System;
using System.Collections.Generic;
using System.Threading;

namespace w4d5m2
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<int>() { 2, 1, 14, 7, 3, 12, 10, 15, 4, 2, 9, 11, 5, 8, 6, 13 };
            var data2 = new List<int>() { 1, 14, 7, 3, 12, 10, 15, 4, 2, 9, 11, 5, 8, 6, 13 };
            var data3 = new List<int>() { 1, 14, 7, 3, 12, 10, 15, 4, 2, 9, 11, 5, 8, 6, 13 };




            sortList(data);

            void sortList(List<int> someUnsortedList)
            {
                if (someUnsortedList.Count == 0) return;

                // Insertion sort

                // Split the list between sorted numbers on the left and unsorted on the right.
                // At the start, only the first number is sorted, the rest are unsorted.
                // Then take the first unsorted number and move it to the left until it is in the correct place in the sorted list.
                // Repeat this with all unsorted numbers until all the numbers are in the sorted list.
                int sortedCount = 1;

                do
                {
                    // Find the first unsorted number.
                    int indexOfFirstUnsortedNumber = sortedCount;
                    int firstUnsortedNumber = someUnsortedList[indexOfFirstUnsortedNumber];

                    // Test the sorted number to the left of it and see if it is bigger.
                    int testIndex = indexOfFirstUnsortedNumber - 1;

                    while (testIndex >= 0 && someUnsortedList[testIndex] > firstUnsortedNumber)
                    {
                        // The sorted number is bigger!
                        // Move the sorted number to the right since it is bigger than the unsorted number.
                        // (Bigger numbers must be on the right of the smaller ones.)
                        someUnsortedList[testIndex + 1] = someUnsortedList[testIndex];

                        // Continue testing the next number on the left.
                        testIndex--;

                        // Display data for diagnostic purposes.
                        DisplayData(someUnsortedList);
                    }

                    // The unsorted number should now be placed into the spot where the last tested number was shifted away from.
                    int insertionIndex = testIndex + 1;
                    someUnsortedList[insertionIndex] = firstUnsortedNumber;
                    //someUnsortedList[testIndex + 1] = firstUnsortedNumber;
                    // We've successfully sorted a new number.
                    sortedCount++;

                    // Display data for diagnostic purposes.
                    DisplayData(someUnsortedList);

                } while (sortedCount < someUnsortedList.Count);

                Console.WriteLine($"The sorted numbers are: {string.Join(", ", someUnsortedList)}");

            }

        }

        static void DisplayData(List<int> data)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            //public static void SetCursorPosition (int left, int top);

            for (int y = 20; y >= 0; y--)
            {
                if (y % 5 == 0)
                {
                    Console.Write($"{y,3} |");
                }
                else
                {
                    Console.Write("    |");
                }

                for (int x = 0; x < data.Count; x++)
                {
                    if (y == 0)
                    {
                        Console.Write("-");
                        continue;
                    }

                    Console.Write(y <= data[x] ? "\u2592" : " ");
                }

                Console.WriteLine();
            }

            Thread.Sleep(10);

        }

    }
}
