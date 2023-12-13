using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/13
    /// </summary>
    public class Day13
    {
        public Day13(Part p)
        {
            long result = 0;
            string line;

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                var map = new List<List<char>> { new List<char>(line) };
                while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                    map.Add(new List<char>(line));

                // Copy to array
                char[,] tab = new char[map.Count, map[0].Count];
                for (int y = 0; y < tab.GetLength(0); ++y)
                    for (int x = 0; x < tab.GetLength(1); ++x)
                        tab[y, x] = map[y][x];

                var initResult = FindReflection(tab);
                if (p == Part.Part1)
                    result += initResult.Score;
                else
                {
                    bool found = false;
                    for (int y = 0; y < tab.GetLength(0) && !found; ++y)
                        for (int x = 0; x < tab.GetLength(1) && !found; ++x)
                        {
                            char init = tab[y, x];
                            tab[y, x] = init == '#' ? '.' : '#';
                            // Try FindReflection in normal and reverse way
                            for (int b = 1; b >= 0 && !found; --b)
                            {
                                var intermResult = FindReflection(tab, b == 0);
                                if (intermResult.IsValid &&
                                    intermResult.Score != initResult.Score &&
                                    (intermResult.XSym == -1 || intermResult.XSym != initResult.XSym) &&
                                    (intermResult.YSym == -1 || intermResult.YSym != initResult.YSym))
                                {
                                    result += intermResult.Score;
                                    found = true;
                                }
                            }
                            tab[y, x] = init;
                        }
                }
            }

            Console.WriteLine(result);
        }

        private (bool IsValid, long Score, int XSym, int YSym) FindReflection(char[,] tab, bool reverse = false)
        {
            // Vertical then horizontal in normal, horizontal then vertical in reverse
            var dim = Enumerable.Range(0, 2);
            if (reverse)
                dim = dim.Reverse();
            foreach (int dimension in dim)
            {
                // Ascendant iteration in normal, descendant in reverse
                var indexes = Enumerable.Range(0, tab.GetLength(dimension));
                if (reverse)
                    indexes = indexes.Reverse();
                char[] lastLine = new char[tab.GetLength(dimension)];
                foreach (int i in indexes)
                {
                    var line = GetLine(tab, dimension, i);
                    if (line.SequenceEqual(lastLine))
                    {
                        int idx = reverse ? i + 1 : i;
                        bool isSymetric = true;
                        int idx1 = idx - 1, idx2 = idx;
                        while (idx1 >= 0 && idx2 < tab.GetLength(dimension) && isSymetric)
                            if (!GetLine(tab, dimension, idx1--).SequenceEqual(GetLine(tab, dimension, idx2++)))
                                isSymetric = false;
                        if (isSymetric)
                            return (true,
                                idx * (dimension == 0 ? 100 : 1),
                                dimension == 1 ? idx : -1,
                                dimension == 0 ? idx : -1);
                    }
                    lastLine = line;
                }
            }
            return (false, 0, 0, 0);
        }

        private static char[] GetLine(char[,] tab, int dim, int idx) =>
            dim == 0 ? tab.GetRow(idx) : tab.GetColumn(idx);
    }
}