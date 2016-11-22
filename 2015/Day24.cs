using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day24
    {
        public Day24(Part p)
        {
            IList<int> list = new List<int>();
            IList<IList<int>> candidates = new List<IList<int>>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                list.Add(int.Parse(line));

            int divisor = p == Part.Part1 ? 3 : 4;

            var aim = list.Sum() / divisor;

            var f = list.ToArray();
            Array.Reverse(f);

            for (int i = 2; i < f.Length / divisor; ++i)
            {
                Thread.Sleep(5000);
                GC.Collect(int.MaxValue, GCCollectionMode.Forced, true, true);
                var powerSet = Combinations.FastGetAll(f, i);
                for (int k = 0; k < powerSet.Length; ++k)
                    if (powerSet[k] != null &&
                        powerSet[k].ToList().Aggregate(0, (a, b) => a + b, c => c == aim))
                        candidates.Add(powerSet[k].ToList());
                powerSet = null;
            }

            var r = candidates.GroupBy(g => g.Count).Min(m => m.Key);

            var result = long.MaxValue;
            foreach (var c in candidates.Where(w => w.Count == r))
                result = Math.Min(result, c.Aggregate<int, long>(1, (a, b) => a * b));

            Console.WriteLine(result);
        }
    }
}