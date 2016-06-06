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
                Console.Write(i);
            }
        }

        static int FixOutput(int input)
        {
            if (input >= 10)
                input -= 10;

            return input;
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
