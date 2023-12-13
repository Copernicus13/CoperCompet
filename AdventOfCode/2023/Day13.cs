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

                int x, y;
                // Copy to array
                char[,] tab = new char[map.Count, map[0].Count];
                for (y = 0; y < tab.GetLength(0); ++y)
                    for (x = 0; x < tab.GetLength(1); ++x)
                        tab[y, x] = map[y][x];

                if (p == Part.Part1)
                    result += FindReflection(tab).Item2;
                else
                {
                    var h = new List<(bool, long, int, int)>();
                    var initResult = FindReflection(tab);
                    for (y = 0; y < tab.GetLength(0); ++y)
                    {
                        for (x = 0; x < tab.GetLength(1); ++x)
                        {
                            char init = tab[y, x];
                            tab[y, x] = init == '#' ? '.' : '#';
                            var intermResult = FindReflection(tab);
                            if (intermResult.Item1 &&
                                intermResult.Item2 != initResult.Item2 &&
                                (initResult.Item3 == -1 || initResult.Item3 != intermResult.Item3) &&
                                (initResult.Item4 == -1 || initResult.Item4 != intermResult.Item4) &&
                                !h.Contains(intermResult))
                            {
                                h.Add(intermResult);
                            }
                            else
                            {
                                intermResult = FindReflection(tab, false);
                                if (intermResult.Item1 &&
                                    intermResult.Item2 != initResult.Item2 &&
                                    (initResult.Item3 == -1 || initResult.Item3 != intermResult.Item3) &&
                                    (initResult.Item4 == -1 || initResult.Item4 != intermResult.Item4) &&
                                    !h.Contains(intermResult))
                                {
                                    h.Add(intermResult);
                                }
                                else
                                {
                                    intermResult = FindReflectionReverse(tab);
                                    if (intermResult.Item1 &&
                                        intermResult.Item2 != initResult.Item2 &&
                                        (initResult.Item3 == -1 || initResult.Item3 != intermResult.Item3) &&
                                        (initResult.Item4 == -1 || initResult.Item4 != intermResult.Item4) &&
                                        !h.Contains(intermResult))
                                    {
                                        h.Add(intermResult);
                                    }
                                    else
                                    {
                                        intermResult = FindReflectionReverse(tab, false);
                                        if (intermResult.Item1 &&
                                            intermResult.Item2 != initResult.Item2 &&
                                            (initResult.Item3 == -1 || initResult.Item3 != intermResult.Item3) &&
                                            (initResult.Item4 == -1 || initResult.Item4 != intermResult.Item4) &&
                                            !h.Contains(intermResult))
                                        {
                                            h.Add(intermResult);
                                        }
                                    }
                                }
                            }
                            tab[y, x] = init;
                        }
                    }
                    if (h.Count == 0)
                        throw new Exception();
                    if (h.Count > 1)
                        throw new Exception();
                    result += h[0].Item2;
                }
            }

            Console.WriteLine(result);
        }

        private (bool, long, int, int) FindReflection(char[,] tab, bool rowFirst = true)
        {
            if (rowFirst)
            {
                char[] lastRow = new char[tab.GetLength(0)];
                // Horizontal
                for (int y = 0; y < tab.GetLength(0); ++y)
                {
                    var row = tab.GetRow(y);
                    if (row.SequenceEqual(lastRow))
                    {
                        var f = CheckSymetry(tab, -1, y);
                        if (f.Item1)
                            return (true, f.Item2, -1, y);
                    }
                    lastRow = row;
                }

                char[] lastCol = new char[tab.GetLength(1)];
                // Vertical
                for (int x = 0; x < tab.GetLength(1); ++x)
                {
                    var col = tab.GetColumn(x);
                    if (col.SequenceEqual(lastCol))
                    {
                        var f = CheckSymetry(tab, x, -1);
                        if (f.Item1)
                            return (true, f.Item2, x, -1);
                    }
                    lastCol = col;
                }
            }
            else
            {
                char[] lastCol = new char[tab.GetLength(1)];
                // Vertical
                for (int x = 0; x < tab.GetLength(1); ++x)
                {
                    var col = tab.GetColumn(x);
                    if (col.SequenceEqual(lastCol))
                    {
                        var f = CheckSymetry(tab, x, -1);
                        if (f.Item1)
                            return (true, f.Item2, x, -1);
                    }
                    lastCol = col;
                }

                char[] lastRow = new char[tab.GetLength(0)];
                // Horizontal
                for (int y = 0; y < tab.GetLength(0); ++y)
                {
                    var row = tab.GetRow(y);
                    if (row.SequenceEqual(lastRow))
                    {
                        var f = CheckSymetry(tab, -1, y);
                        if (f.Item1)
                            return (true, f.Item2, -1, y);
                    }
                    lastRow = row;
                }
            }

            return (false, 0, 0, 0);
        }

        private (bool, long, int, int) FindReflectionReverse(char[,] tab, bool rowFirst = true)
        {
            if (rowFirst)
            {
                char[] lastRow = new char[tab.GetLength(0)];
                // Horizontal
                for (int y = tab.GetLength(0) - 1; y >= 0; --y)
                {
                    var row = tab.GetRow(y);
                    if (row.SequenceEqual(lastRow))
                    {
                        var f = CheckSymetry(tab, -1, y + 1);
                        if (f.Item1)
                            return (true, f.Item2, -1, y + 1);
                    }
                    lastRow = row;
                }

                char[] lastCol = new char[tab.GetLength(1)];
                // Vertical
                for (int x = tab.GetLength(1) - 1; x >= 0; --x)
                {
                    var col = tab.GetColumn(x);
                    if (col.SequenceEqual(lastCol))
                    {
                        var f = CheckSymetry(tab, x + 1, -1);
                        if (f.Item1)
                            return (true, f.Item2, x + 1, -1);
                    }
                    lastCol = col;
                }
            }
            else
            {
                char[] lastCol = new char[tab.GetLength(1)];
                // Vertical
                for (int x = tab.GetLength(1) - 1; x >= 0; --x)
                {
                    var col = tab.GetColumn(x);
                    if (col.SequenceEqual(lastCol))
                    {
                        var f = CheckSymetry(tab, x + 1, -1);
                        if (f.Item1)
                            return (true, f.Item2, x + 1, -1);
                    }
                    lastCol = col;
                }

                char[] lastRow = new char[tab.GetLength(0)];
                // Horizontal
                for (int y = tab.GetLength(0) - 1; y >= 0; --y)
                {
                    var row = tab.GetRow(y);
                    if (row.SequenceEqual(lastRow))
                    {
                        var f = CheckSymetry(tab, -1, y + 1);
                        if (f.Item1)
                            return (true, f.Item2, -1, y + 1);
                    }
                    lastRow = row;
                }
            }

            return (false, 0, 0, 0);
        }

        private (bool, long) CheckSymetry(char[,] tab, int x, int y)
        {
            // Horizontal
            if (x == -1)
            {
                int y1 = y - 1, y2 = y;
                while (y1 >= 0 && y2 < tab.GetLength(0))
                    if (!tab.GetRow(y1--).SequenceEqual(tab.GetRow(y2++)))
                        return (false, 0);
                return (true, y * 100);
            }

            // Vertical
            int x1 = x - 1, x2 = x;
            while (x1 >= 0 && x2 < tab.GetLength(1))
                if (!tab.GetColumn(x1--).SequenceEqual(tab.GetColumn(x2++)))
                    return (false, 0);

            return (true, x);
        }
    }
}