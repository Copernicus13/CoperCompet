using System;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day2
    {
        public Day2(Part p)
        {
            long result = 0;
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var splitted = line.Split('x');
                int l = int.Parse(splitted[0]);
                int w = int.Parse(splitted[1]);
                int h = int.Parse(splitted[2]);
                int slack = 0;
                if (p == Part.Part1)
                {
                    slack = Math.Min(l * w, l * h);
                    slack = Math.Min(slack, w * h);
                    result += 2 * l * w + 2 * l * h + 2 * w * h + slack;
                }
                else if (p == Part.Part2)
                {
                    int max = Math.Max(l, w);
                    max = Math.Max(max, h);
                    if (max == l)
                        slack = 2 * w + 2 * h;
                    else if (max == w)
                        slack = 2 * l + 2 * h;
                    else if (max == h)
                        slack = 2 * l + 2 * w;
                    result += l * w * h + slack;
                }
            }
            Console.WriteLine(result);
        }
    }
}
