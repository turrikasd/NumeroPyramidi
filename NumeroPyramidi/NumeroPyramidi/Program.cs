﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeroPyramidi
{
    class Program
    {
        const int numRows = 10;

        static void Main(string[] args)
        {
            //PrintPyramidMultiThread();
            PrintPyramidSingleThread();
            Console.ReadKey();
        }

        static void PrintPyramidMultiThread()
        {
            List<List<int>> output = new List<List<int>>();
            for (int i = 0; i <= numRows; i++) // add elements to the collection
            {
                output.Add(new List<int>());
            }

            Parallel.For(1, numRows + 1, i =>
            {
                List<int> row = new List<int>();

                int rowLength = i * 2 - 1;
                for (int x = 0; x < rowLength; x++)
                {
                    if (x <= rowLength / 2)
                        row.Add(FixOutput(i + x));
                    else
                        row.Add(FixOutput(rowLength - (x - rowLength / 2)));
                }

                output[i - 1] = row;
            });

            for (int i = 1; i <= numRows; i++) // i on ensimmäinen numero rivillä
            {
                try
                {
                    Console.SetCursorPosition(GetConsolePosition(i), i);
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    break; // Break if console out of bounds exception
                }

                int[] arrayOfRow = output[i - 1].ToArray();
                Console.Write(string.Join("", arrayOfRow));
            }
        }

        static void PrintPyramidSingleThread()
        {
            for (int i = 1; i <= numRows; i++) // i on ensimmäinen numero rivillä
            {
                try
                {
                    Console.SetCursorPosition(GetConsolePosition(i), i);
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    break; // Break if console out of bounds exception
                }

                int rowLength = i * 2 - 1;
                for (int x = 0; x < rowLength; x++)
                {
                    if (x <= rowLength / 2)
                        WriteCorrectedInt(i + x);
                    else
                        WriteCorrectedInt(rowLength - (x - rowLength / 2));
                }
            }
        }

        static int FixOutput(int input)
        {
            int output = input % 10;
            return output;
        }

        static void WriteCorrectedInt(int input)
        {
            Console.Write(FixOutput(input));
        }

        static int GetConsoleWidth()
        {
            return Console.WindowWidth;
        }

        static int GetConsolePosition(int row)
        {
            return GetConsoleWidth() / 2 - row;
        }
    }
}
