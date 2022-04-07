using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/6
    /// </summary>
    public class Day06
    {
        public Day06(Part p)
        {
            string line;
            IList<string> tab = new List<string>();
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                tab.Add(line);

            for (int i = 0; i < 8; ++i)
            {
                var query = tab.Select(s => s[i]).GroupBy(g => g);
                if (p == Part.Part1)
                    query = query.OrderByDescending(g => g.Count());
                if (p == Part.Part2)
                    query = query.OrderBy(g => g.Count());
                Console.Write(query.Select(s => s.Key).First());
            }
            Console.WriteLine();
        }
    }
}
