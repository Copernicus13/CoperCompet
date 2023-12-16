using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/12
    /// </summary>
    public class Day12
    {
        private Dictionary<(string, int), long> _memo;

        public Day12(Part p)
        {
            long result = 0;
            string line;
            _memo = new Dictionary<(string, int), long>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                _memo.Clear();
                var str = line.Split(' ')[0];
                var numbers = line.Split(' ')[1].Split(',').Select(int.Parse).ToList();
                if (p == Part.Part1)
                    result += CountArrangements(str, new Queue<int>(numbers));
                else if (p == Part.Part2)
                    result += CountArrangements(
                        string.Join('?', Enumerable.Repeat(str, 5)),
                        new Queue<int>(Enumerable.Repeat(numbers, 5).SelectMany(sm => sm)));
            }

            Console.WriteLine(result);
        }

        private long CountArrangements(string record, Queue<int> queue)
        {
            if (_memo.ContainsKey((record, queue.Count)))
                return _memo[(record, queue.Count)];
            var currentNum = queue.Dequeue();
            bool stopAsked = false;
            long nbArrangement = 0;
            for (int i = 0; i < record.Length && !stopAsked; ++i)
            {
                if (i + currentNum > record.Length) // Current string too short, exit
                    break;
                if (record[i] == '#')   // No need to iterate anymore after that,
                    stopAsked = true;   // we couldn’t let a single # alone behind
                if (record[i] == '.' || record.Substring(i, currentNum).Any(a => a == '.'))
                    continue;
                if (i + currentNum == record.Length)    // End of string reached
                {
                    if (queue.Count == 0)
                        ++nbArrangement;
                    break;
                }
                if (record[i + currentNum] == '#') // Must not finish on a '#'
                    continue;
                var remainder = record.Substring(i + currentNum + 1);
                if (queue.Count > 0 && !string.IsNullOrEmpty(remainder))
                    nbArrangement += CountArrangements(remainder, new Queue<int>(queue));
                else if (queue.Count == 0 && remainder.All(a => a != '#'))
                    ++nbArrangement;
            }
            _memo.Add((record, queue.Count + 1), nbArrangement);
            return nbArrangement;
        }
    }
}