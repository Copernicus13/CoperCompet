using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/9
    /// </summary>
    public class Day09
    {
        public Day09(Part p)
        {
            string line;
            var list = new List<List<long>>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                list.Add(line.Split(' ').Select(long.Parse).ToList());

            foreach (var numbers in list)
                Extrapolate(numbers);

            if (p == Part.Part1)
                Console.WriteLine(list.Sum(s => s.Last()));
            else if (p == Part.Part2)
                Console.WriteLine(list.Sum(s => s.First()));
        }

        private void Extrapolate(List<long> numbers)
        {
            var extremitiesDelta = new List<(long Head, long Tail)>();
            var currentDeltaSeq = new List<long>(numbers);
            while (currentDeltaSeq.Any(a => a != 0L))
            {
                for (var i = 1; i < currentDeltaSeq.Count; ++i)
                    currentDeltaSeq[i - 1] = currentDeltaSeq[i] - currentDeltaSeq[i - 1];
                currentDeltaSeq.RemoveAt(currentDeltaSeq.Count - 1);
                extremitiesDelta.Add((currentDeltaSeq.First(), currentDeltaSeq.Last()));
            }
            numbers.Insert(0, numbers.First() - extremitiesDelta.ReverseEx().Aggregate(0L, (a, b) => b.Head - a));
            numbers.Add(numbers.Last() + extremitiesDelta.Sum(a => a.Tail));
        }
    }
}