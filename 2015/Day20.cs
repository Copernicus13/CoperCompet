using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day20
    {
        private const int NB = 1000000;

        public Day20(Part p)
        {
            int target = int.Parse(Console.ReadLine());

            IList<int> elves = new List<int>(NB);
            IList<int> houses = new List<int>(NB);
            int coef = p == Part.Part1 ? 10 : 11;
            for (int i = 0; i < NB; ++i)
                elves.Add(coef * (i + 1));

            for (int i = 1; i <= NB; ++i)
            {
                houses.Add(0);
                foreach (var f in Maths.GetFactors(i))
                    if (p == Part.Part1 || p == Part.Part2 && f * 50 >= i)
                        houses[i - 1] += elves[f - 1];
                if (houses[i - 1] >= target)
                    break;
            }

            Console.WriteLine(houses.Count);
        }
    }
}