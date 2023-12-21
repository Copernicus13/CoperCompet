using System;
using System.Collections.Generic;
using AdventOfCode.Common;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/21
    /// </summary>
    public class Day21
    {
        private readonly PointL[] _dir = { new(-1, 0), new(0, -1), new(1, 0), new(0, 1) };

        public Day21(Part p)
        {
            var startPoint = new PointL(0, 0);
            string line = Console.ReadLine()!;
            char[,] tab = new char[line.Length, line.Length];
            for (int x = 0; x < line.Length; ++x)
                tab[0, x] = line[x];
            for (int y = 1; !string.IsNullOrEmpty(line = Console.ReadLine()!); ++y)
                for (int x = 0; x < line.Length; ++x)
                {
                    if (line[x] == 'S')
                        startPoint = new PointL(x, y);
                    tab[y, x] = line[x];
                }

            if (p == Part.Part1)
                Console.WriteLine(ShortestPath(tab, startPoint, 64));
            else if (p == Part.Part2)
                Console.WriteLine(0);
        }

        private int ShortestPath(char[,] tab, PointL startPoint, int nbSteps)
        {
            var queue = new Queue<(PointL, int)>();
            queue.Enqueue((new PointL(startPoint.X, startPoint.Y), 0));
            var set = new HashSet<PointL>();
            for (int i = 0; i < nbSteps; ++i)
            {
                set.Clear();
                while (queue.Count != 0)
                {
                    var current = queue.Peek();
                    if (current.Item2 != i)
                        break;
                    queue.Dequeue();
                    foreach (var dir in _dir)
                    {
                        long x = current.Item1.X + dir.X;
                        long y = current.Item1.Y + dir.Y;
                        //long correctedX =
                        //    x >= 0 ? x % tab.GetLength(1) : tab.GetLength(1) - (Math.Abs(x) - 1) % tab.GetLength(1) - 1;
                        //long correctedY =
                        //    y >= 0 ? y % tab.GetLength(0) : tab.GetLength(0) - (Math.Abs(y) - 1) % tab.GetLength(0) - 1;
                        if (x >= 0 && x < tab.GetLength(1) && y >= 0 && y < tab.GetLength(0) &&
                            tab[y, x] != '#' && !set.Contains(new PointL(x, y)))
                        {
                            set.Add(new PointL(x, y));
                            queue.Enqueue((new PointL(x, y), i + 1));
                        }
                    }
                }
            }
            return set.Count;
        }
    }
}