using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Combinatorics;

namespace AdventOfCode._2015
{
    public class Day17
    {
        public Day17(Part p)
        {
            IList<int> list = new List<int>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                list.Add(int.Parse(line));

            var powerSet = Combinations<int>.FastPowerSet(list.ToArray());

            int result = 0;
            if (p == Part.Part1)
                powerSet.ToList()
                    .ForEach(f => { if (f.Aggregate(0, (a, b) => a + b, c => c == 150)) ++result; });
            else if (p == Part.Part2)
            {
                int minCont = int.MaxValue;
                powerSet.ToList()
                    .OrderBy(o => o.Length)
                    .ToList()
                    .ForEach(f =>
                        {
                            if (f.Aggregate(0, (a, b) => a + b, c => c == 150) && f.Length <= minCont)
                            {
                                minCont = f.Length;
                                ++result;
                            }
                        });
            }
            Console.WriteLine(result);
        }
    }
}