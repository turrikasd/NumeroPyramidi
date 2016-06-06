using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeroPyramidi
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintPyramidMultiThread();
            //PrintPyramidSingleThread();
            Console.ReadKey();
        }

        static void PrintPyramidMultiThread()
        {
            List<List<int>> output = new List<List<int>>();
            Parallel.For(1, 10, i =>
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

                output.Add(row);
            });

            for (int i = 1; i < 10; i++) // i on ensimmäinen numero rivillä
            {
                Console.SetCursorPosition(GetConsolePosition(i), i);
                int[] arrayOfRow = output[i - 1].ToArray();
                Console.Write(string.Join("", arrayOfRow));
            }
        }

        static void PrintPyramidSingleThread()
        {
            for (int i = 1; i < 10; i++) // i on ensimmäinen numero rivillä
            {
                Console.SetCursorPosition(GetConsolePosition(i), i);

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
            int inputOver = input / 10;

            if (input >= 10)
                input -= inputOver * 10;

            return input;
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
