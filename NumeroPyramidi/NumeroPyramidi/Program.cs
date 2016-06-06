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
            PrintPyramidSingleThread();
            Console.ReadKey();
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
