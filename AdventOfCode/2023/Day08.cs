using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib;
using CoperAlgoLib.Data;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/8
    /// </summary>
    public class Day08
    {
        public Day08(Part p)
        {
            string line;
            var maps = new Dictionary<string, Tuple<string, string>>();
            var instructions = new LinkedList<char>(Console.ReadLine()!.ToList());
            Console.ReadLine();
            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                var str = line.Split(new[] { '=', ',' }, StringSplitOptions.TrimEntries);
                maps.Add(str[0], new Tuple<string, string>(str[1].TrimStart('('), str[2].TrimEnd(')')));
            }

            ulong result = 0;
            var currentNode = instructions.First;
            if (p == Part.Part1)
            {
                line = "AAA";
                do
                {
                    ++result;
                    line = currentNode!.Value == 'L' ? maps[line].Item1 : maps[line].Item2;
                    currentNode = currentNode.CircularNext();
                } while (line != "ZZZ");
            }
            else if (p == Part.Part2)
            {
                var finishPointsDistance = new List<int>();
                var startingPoints = new List<string>(maps.Keys.Where(w => w.EndsWith('A')));
                foreach (var point in startingPoints)
                {
                    int cpt = 0;
                    line = point;
                    currentNode = instructions.First;
                    do
                    {
                        ++cpt;
                        line = currentNode!.Value == 'L' ? maps[line].Item1 : maps[line].Item2;
                        currentNode = currentNode.CircularNext();
                    } while (!line.EndsWith('Z'));
                    finishPointsDistance.Add(cpt);
                }
                var pgcd = finishPointsDistance
                    .Skip(1)
                    .Select(Maths.GetFactors)
                    .Aggregate(
                        new HashSet<int>(Maths.GetFactors(finishPointsDistance[0])),
                        (h, e) => { h.IntersectWith(e); return h; })
                    .Max();
                // PPCM using PGCD
                result = finishPointsDistance
                    .Skip(1)
                    .Aggregate((ulong)finishPointsDistance[0], (h, e) => h * (ulong)e / (ulong)pgcd);
            }
            Console.WriteLine(result);
        }
    }
}