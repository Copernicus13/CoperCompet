using System;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day25
    {
        public Day25(Part p)
        {
            string line = Console.ReadLine();

            int param1 = int.Parse(line.Split(' ')[16].Trim(',')) - 1;
            int param2 = int.Parse(line.Split(' ')[18].Trim('.')) - 1;

            int previous = 20151125;

            for (int i = 1; i < int.MaxValue; ++i)
            {
                int row = i;
                for (int column = 0; column <= i; ++column, --row)
                {
                    previous = (int)(previous * 252533l % 33554393);
                    if (row == param1 && column == param2)
                        Console.WriteLine(previous);
                }
            }
        }
    }
}