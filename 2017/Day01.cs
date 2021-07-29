using System;
using AdventOfCode.Common;

namespace AdventOfCode._2017
{
    /// <summary>
    /// http://adventofcode.com/2017/day/1
    /// </summary>
    public class Day01
    {
        public Day01(Part p)
        {
            int result = 0;
            string line = Console.ReadLine();
            int jmp = p == Part.Part1 ? 1 : line.Length / 2;
            for (int i = 0; i < line.Length; ++i)
            {
                char c = line[i];
                if (c == line[(i + jmp) % line.Length])
                    result += c - '0';
            }
            Console.WriteLine(result);
        }
    }
}
