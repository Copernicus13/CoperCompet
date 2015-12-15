using System;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day01
    {
        public Day01(Part p)
        {
            int cpt = 0, result = 0;
            string line = Console.ReadLine();
            foreach (var c in line)
            {
                ++cpt;
                result += (c == '(' ? 1 : -1);
                if (p == Part.Part2 && result == -1)
                    break;
            }
            Console.WriteLine((p == Part.Part2 ? cpt : result));
        }
    }
}
