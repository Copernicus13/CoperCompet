using AdventOfCode.Common;
using System;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/2
    /// </summary>
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
            string line, res = string.Empty;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                foreach (char c in line)
                {
                    if (p == Part.Part1)
                        Calc(Board1, ref posX, ref posY, c);
                    else if (p == Part.Part2)
                        Calc(Board2, ref posX, ref posY, c);
                }
                if (p == Part.Part1)
                    actualNb = Board1[posY, posX];
                else if (p == Part.Part2)
                    actualNb = Board2[posY, posX];
                res += actualNb.ToString("X");
            }
            Console.WriteLine(res);
        }

        private void Calc(int[,] tab, ref int posX, ref int posY, char c)
        {
            switch (c)
            {
                case 'U':
                    if (posY > 0 && tab[posY - 1, posX] != -1)
                        --posY;
                    break;
                case 'D':
                    if (posY < tab.GetLength(0) - 1 && tab[posY + 1, posX] != -1)
                        ++posY;
                    break;
                case 'L':
                    if (posX > 0 && tab[posY, posX - 1] != -1)
                        --posX;
                    break;
                case 'R':
                    if (posX < tab.GetLength(1) - 1 && tab[posY, posX + 1] != -1)
                        ++posX;
                    break;
            }
        }
    }
}
