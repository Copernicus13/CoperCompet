using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/5
    /// </summary>
    public class Day05
    {
        private readonly List<List<(Range<long> Range, long Offset)>> _maps;

        public Day05(Part p)
        {
            long startTime = Stopwatch.GetTimestamp();

            _maps = ParseInput(p);

            var result = new long[_maps[0].Count];
            for (var i = 0; i < _maps[0].Count; ++i)
                result[i] = GetLocation(_maps[0][i].Range);

            Console.WriteLine(result.ToList().Min());

            Console.WriteLine(Stopwatch.GetElapsedTime(startTime));
        }

        private long GetLocation(Range<long> range)
        {
            var result = long.MaxValue;
            for (var number = range.Minimum; number <= range.Maximum; ++number)
            {
                var lastValue = number;
                for (var i = 1; i < _maps.Count; ++i)
                {
                    var index = _maps[i].FindIndex(s => s.Range.ContainsValue(lastValue));
                    lastValue = index != -1 ? lastValue + _maps[i][index].Offset : lastValue;
                }
                result = Math.Min(result, lastValue);
            }
            return result;
        }

        private List<List<(Range<long>, long)>> ParseInput(Part p)
        {
            var result = new List<(Range<long> Range, long Offset)>[8];
            result[0] = new List<(Range<long> Range, long Offset)>();
            var line = Console.ReadLine()!;
            if (p == Part.Part1)
                result[0].AddRange(
                    line.Split(':')[1]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => (new Range<long>(long.Parse(s), 1), 0L)));
            else if (p == Part.Part2)
                result[0].AddRange(
                    line.Split(':')[1]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Chunk(2)
                        .Select(s => (new Range<long>(long.Parse(s[0]), long.Parse(s[1])), 0L)));

            Console.ReadLine();
            for (var i = 1; i < 8; ++i)
            {
                result[i] = new List<(Range<long> Range, long Offset)>();
                Console.ReadLine();
                while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                {
                    var list = line.Split(' ').Select(long.Parse).ToList();
                    result[i].Add((new Range<long>(list[1], list[2]), list[0] - list[1]));
                }
            }
            return result.ToList();
        }
    }
}