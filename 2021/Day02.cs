using System;
using AdventOfCode.Common;

namespace AdventOfCode._2021
{
    /// <summary>
    /// http://adventofcode.com/2021/day/2
    /// </summary>
    public class Day02
    {
        public Day02(Part p)
        {
            int horizPos = 0, depth = 0, aim = 0;
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var data = line.Split();
                var value = int.Parse(data[1]);
                if (p == Part.Part1)
                {
                    switch (data[0])
                    {
                        case "forward": horizPos += value; break;
                        case "down": depth += value; break;
                        case "up": depth -= value; break;
                    }
                }
                else if (p == Part.Part2)
                {
                    switch (data[0])
                    {
                        case "forward":
                            horizPos += value;
                            depth += aim * value;
                            break;
                        case "down": aim += value; break;
                        case "up": aim -= value; break;
                    }
                }
            }
            Console.WriteLine(horizPos * depth);
        }
    }
}
