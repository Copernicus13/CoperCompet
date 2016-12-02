using System;
using AdventOfCode.Common;

namespace AdventOfCode._2016
{
    public class Day01
    {
        private const int MAX_TAB_SIZE = 1000;
        // North, West, South, East
        private readonly int[] DirX = { 0, -1, 0, 1 };
        private readonly int[] DirY = { 1, 0, -1, 0 };

        public Day01(Part p)
        {
            char[,] tab = new char[MAX_TAB_SIZE, MAX_TAB_SIZE];
            string line = Console.ReadLine();
            int posX = MAX_TAB_SIZE / 2, posY = MAX_TAB_SIZE / 2;
            tab[posX, posY] = '¤';
            int actualDir = 0;
            foreach (var seq in line.Split(','))
            {
                var instr = seq.Trim();
                var lg = int.Parse(instr.Substring(1));
                actualDir = (instr[0] == 'L' ? ++actualDir % 4 : --actualDir & 3);
                if (p == Part.Part2)
                {
                    for (int i = 1; i <= lg; ++i)
                    {
                        if (tab[posX + i * DirX[actualDir],
                                posY + i * DirY[actualDir]] == '¤')
                        {
                            Console.WriteLine(
                                Math.Abs(MAX_TAB_SIZE / 2 - (posX + i * DirX[actualDir])) +
                                Math.Abs(MAX_TAB_SIZE / 2 - (posY + i * DirY[actualDir])));
                            return;
                        }
                        tab[posX + i * DirX[actualDir], posY + i * DirY[actualDir]] = '¤';
                    }
                }
                posX += DirX[actualDir] * lg;
                posY += DirY[actualDir] * lg;
            }
            Console.WriteLine(
                Math.Abs(MAX_TAB_SIZE / 2 - posX) + Math.Abs(MAX_TAB_SIZE / 2 - posY));
        }
    }
}
