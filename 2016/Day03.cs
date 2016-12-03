using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2016
{
    public class Day03
    {
        private Func<string, IList<int>> StrToIntList =
            a => a.Split(' ')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(s => int.Parse(s))
                .ToList();

        public Day03(Part p)
        {
            if (p == Part.Part1)
                Console.WriteLine(Part1());
            else if (p == Part.Part2)
                Console.WriteLine(Part2());
        }

        private int Part1()
        {
            int cpt = 0;
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var res = StrToIntList(line).OrderBy(o => o).ToList();
                if (res[0] + res[1] > res[2])
                    ++cpt;
            }
            return cpt;
        }

        private int Part2()
        {
            int cpt = 0;
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();
            string line3 = Console.ReadLine();
            while (!string.IsNullOrEmpty(line1) &&
                !string.IsNullOrEmpty(line2) &&
                !string.IsNullOrEmpty(line3))
            {
                var res1 = StrToIntList(line1);
                var res2 = StrToIntList(line2);
                var res3 = StrToIntList(line3);
                for (int i = 0; i < 3; ++i)
                {
                    var res = new List<int>() { res1[i], res2[i], res3[i] };
                    res = res.OrderBy(o => o).ToList();
                    if (res[0] + res[1] > res[2])
                        ++cpt;
                }

                line1 = Console.ReadLine();
                line2 = Console.ReadLine();
                line3 = Console.ReadLine();
            }
            return cpt;
        }
    }
}
