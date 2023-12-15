using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/15
    /// </summary>
    public class Day15
    {
        public Day15(Part p)
        {
            int HASH(string str) => str.Aggregate((byte)0, (i, c) => (byte)((i + c) * 17));

            int result = 0;
            // Warning, input line is too long to be copied/pasted directly in
            // the terminal, be sure to put it in a file, and use input redirection.
            string line = Console.ReadLine()!;

            if (p == Part.Part1)
                result = line.Split(',').Aggregate(0, (acc, step) => acc + HASH(step));
            else if (p == Part.Part2)
            {
                var separator = new[] { '=', '-' };
                var boxes = new List<(string LensLabel, int FocalLength)>[256];
                for (int i = 0; i < boxes.Length; ++i)
                    boxes[i] = new List<(string, int)>();
                foreach (string step in line.Split(','))
                {
                    var tmp = step.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    int idxBox = HASH(tmp[0]);
                    int idxLens = boxes[idxBox].FindIndex(f => f.LensLabel == tmp[0]);
                    if (tmp.Length == 1 && idxLens != -1)
                        boxes[idxBox].RemoveAt(idxLens);
                    else if (tmp.Length == 2)
                    {
                        if (idxLens != -1)
                            boxes[idxBox][idxLens] = (tmp[0], int.Parse(tmp[1]));
                        else
                            boxes[idxBox].Add((tmp[0], int.Parse(tmp[1])));
                    }
                }

                for (int i = 0; i < boxes.Length; ++i)
                    for (int j = 0; j < boxes[i].Count; ++j)
                        result += (i + 1) * (j + 1) * boxes[i][j].FocalLength;
            }

            Console.WriteLine(result);
        }
    }
}