using AdventOfCode.Common;
using System;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/25
    /// </summary>
    public class Day25
    {
        public Day25(Part _)
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
#pragma warning disable CS0078 // Le suffixe 'l' risque d’être facilement confondu avec le chiffre '1'
                    previous = (int)(previous * 252533l % 33554393);
#pragma warning restore CS0078
                    if (row == param1 && column == param2)
                        Console.WriteLine(previous);
                }
            }
        }
    }
}