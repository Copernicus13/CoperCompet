using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/6
    /// </summary>
    public class Day06
    {
        record Race(long Time, long Distance);

        public Day06(Part p)
        {
            var list = new List<Race>();
            var line1 = Console.ReadLine()!.Split(':')[1];
            var line2 = Console.ReadLine()!.Split(':')[1];

            if (p == Part.Part1)
                list.AddRange(
                    line1.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
                        .Zip(line2.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse),
                             (first, second) => new Race(first, second)));
            else if (p == Part.Part2)
                list.Add(
                    new Race(long.Parse(line1.Replace(" ", string.Empty)),
                             long.Parse(line2.Replace(" ", string.Empty))));

            IList<long> result = new List<long>();
            foreach (var race in list)
            {
                checked
                {
                    // x: time to hold the button
                    // (RefTime - x) * x > DistanceToBeat
                    // Solve -x² + RefTime*x - DistanceToBeat
                    var delta = race.Time * race.Time - 4 * race.Distance;
                    var x1 = (-race.Time - Math.Sqrt(delta)) / -2;
                    var x2 = (-race.Time + Math.Sqrt(delta)) / -2;
                    long intX1 = (long)(x1 - Math.Truncate(x1) == 0d ? --x1 : Math.Truncate(x1));
                    long intX2 = (long)(x2 - Math.Truncate(x2) == 0d ? ++x2 : Math.Ceiling(x2));
                    result.Add(intX1 - intX2 + 1);
                }
            }
            Console.WriteLine(result.Aggregate(1L, (a, b) => a * b));
        }
    }
}