using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2017
{
    /// <summary>
    /// http://adventofcode.com/2017/day/2
    /// </summary>
    public class Day02
    {
        private Func<string, IList<int>> StrToIntList =
            a => a.Split(' ', '\t')
                  .Select(s => int.Parse(s))
                  .ToList();

        public Day02(Part p)
        {
            int result = 0;
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var list = StrToIntList(line).ToList();
                if (p == Part.Part1)
                    result += list.Max() - list.Min();
                else if (p == Part.Part2)
                    result += FindAndComputeEvenlyDivisibleValues(list);
            }
            Console.WriteLine(result);
        }

        private int FindAndComputeEvenlyDivisibleValues(List<int> list)
        {
            for (int i = 0; i < list.Count; ++i)
                for (int j = 0; j < list.Count; ++j)
                    if (i != j && list[i] % list[j] == 0)
                        return list[i] / list[j];
            return -1;
        }
    }
}
