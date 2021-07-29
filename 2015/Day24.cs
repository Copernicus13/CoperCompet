using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Combinatorics;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/24
    /// </summary>
    public class Day24
    {
        public Day24(Part p)
        {
            IList<int> list = new List<int>();
            List<IList<int>> candidates = new List<IList<int>>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                list.Add(int.Parse(line));

            int divisor = p == Part.Part1 ? 3 : 4;

            var aim = list.Sum() / divisor;

            for (int i = 2; i < list.Count; ++i)
            {
                var combinations = new Combinations<int>(list, i);
                if (combinations.Any(s => s.Aggregate(0, (a, b) => a + b, c => c == aim)))
                {
                    Console.WriteLine(
                        combinations
                            .Where(s => s.Aggregate(0, (a, b) => a + b, c => c == aim))
                            .Min(z => z.Aggregate<int, long>(1, (a, b) => a * b)));
                    break;
                }
            }
        }
    }
}