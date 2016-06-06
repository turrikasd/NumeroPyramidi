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
        }

        static void PrintPyramidSingleThread()
        {
            for (int i = 1; i < 10; i++) // i on ensimmäinen numero rivillä
            {
                
            }
        }

        static int FixOutput(int input)
        {
            if (input >= 10)
                input -= 10;

            return input;
        }
    }
}
