using System;
using AdventOfCode.Common;

namespace AdventOfCode._2016
{
    public class Day02
    {
        private readonly int[,] Board1 =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

        private readonly int[,] Board2 =
            {
                { -1, -1,  1, -1, -1 },
                { -1,  2,  3,  4, -1 },
                {  5,  6,  7,  8,  9 },
                { -1, 10, 11, 12, -1 },
                { -1, -1, 13, -1, -1 }
            };

        public Day02(Part p)
        {
            int actualNb = 5;
            int posX = 0, posY = 0;
            if (p == Part.Part1)
                posX = posY = 1;
            else if (p == Part.Part2)
                posY = 2;
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                foreach (char c in line)
                {
                    if (p == Part.Part1)
                        Calc1(ref posX, ref posY, c);
                    else if (p == Part.Part2)
                        Calc2(ref posX, ref posY, c);
                }
                if (p == Part.Part1)
                    actualNb = Board1[posY, posX];
                else if (p == Part.Part2)
                    actualNb = Board2[posY, posX];
                Console.WriteLine(actualNb);
            }
        }

        private static void Calc1(ref int posX, ref int posY, char c)
        {
            switch (c)
            {
                case 'U':
                    if (posY > 0)
                        --posY;
                    break;
                case 'D':
                    if (posY < 2)
                        ++posY;
                    break;
                case 'L':
                    if (posX > 0)
                        --posX;
                    break;
                case 'R':
                    if (posX < 2)
                        ++posX;
                    break;
            }
        }

        private void Calc2(ref int posX, ref int posY, char c)
        {
            switch (c)
            {
                case 'U':
                    if (posY > 0 && Board2[posX, posY - 1] != -1)
                        --posY;
                    break;
                case 'D':
                    if (posY < 4 && Board2[posX, posY + 1] != -1)
                        ++posY;
                    break;
                case 'L':
                    if (posX > 0 && Board2[posX - 1, posY] != -1)
                        --posX;
                    break;
                case 'R':
                    if (posX < 4 && Board2[posX + 1, posY] != -1)
                        ++posX;
                    break;
            }
        }
    }
}
