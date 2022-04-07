using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/4
    /// </summary>
    public class Day04
    {
        public Day04(Part p)
        {
            string line;
            int cpt = 0;
            var decyphered = new List<Tuple<int, string>>();
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var a = line.Split('-');
                var b = new List<string>();
                var c = int.Parse(a.Last().Split('[')[0]);
                var d = a.Last().Split('[')[1].TrimEnd(']');
                for (int i = 0; i < a.Length - 1; ++i)
                    b.Add(a[i]);

                string calcCheckSum = new string(b
                    .SelectMany(s => s)
                    .GroupBy(i => i)
                    .OrderByDescending(g => g.Count())
                    .ThenBy(x => x.Key)
                    .Take(5)
                    .Select(x => x.Key)
                    .ToArray());

                if (calcCheckSum == d)
                {
                    cpt += c;
                    if (p == Part.Part2)
                    {
                        char[] res = line.ToArray();
                        for (var i = 0; i < res.Length; ++i)
                            res[i] = (char)((res[i] - 'a' + c % 26) % 26 + 'a');
                        decyphered.Add(new Tuple<int, string>(c, new string(res)));
                    }
                }
            }
            if (p == Part.Part1)
                Console.WriteLine(cpt);
            else
                Console.WriteLine(decyphered.First(w => w.Item2.Contains("northpole")).Item1);
        }
    }
}
