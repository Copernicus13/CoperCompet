using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/16
    /// </summary>
    public class Day16
    {
        private readonly Point[] _dir = { new(-1, 0), new(0, -1), new(1, 0), new(0, 1) };
        private enum DirName { Left, Up, Right, Down };

        public Day16(Part p)
        {
            string line = Console.ReadLine()!;
            char[,] tab = new char[line.Length, line.Length];
            for (var x = 0; x < line.Length; ++x)
                tab[0, x] = line[x];
            for (int y = 1; !string.IsNullOrEmpty(line = Console.ReadLine()!); ++y)
                for (var x = 0; x < line.Length; ++x)
                    tab[y, x] = line[x];

            int result = TraceAndCount(tab, new Point(-1, 0), DirName.Right);
            if (p == Part.Part2)
            {
                for (int y = 0; y < tab.GetLength(0); ++y)
                {
                    result = Math.Max(result, TraceAndCount(tab, new Point(-1, y), DirName.Right));
                    result = Math.Max(result, TraceAndCount(tab, new Point(tab.GetLength(1), y), DirName.Left));
                }
                for (int x = 0; x < tab.GetLength(1); ++x)
                {
                    result = Math.Max(result, TraceAndCount(tab, new Point(x, -1), DirName.Down));
                    result = Math.Max(result, TraceAndCount(tab, new Point(x, tab.GetLength(0)), DirName.Up));
                }
            }
            Console.WriteLine(result);
        }

        private int TraceAndCount(char[,] tab, Point startPoint, DirName direction)
        {
            var memo = new HashSet<(Point, DirName)>();
            var queue = new Queue<(Point P, DirName Dir)>();
            queue.Enqueue((startPoint, direction));
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                var curX = item.P.X + _dir[(int)item.Dir].X;
                var curY = item.P.Y + _dir[(int)item.Dir].Y;
                var curPoint = new Point(curX, curY);
                if (curX < 0 || curX >= tab.GetLength(1) || curY < 0 || curY >= tab.GetLength(0))
                    continue;
                if (memo.Contains((curPoint, item.Dir)))
                    continue;
                switch (item.Dir, tab[curY, curX])
                {
                    case (DirName.Left, '|'):
                    case (DirName.Right, '|'):
                        queue.Enqueue((curPoint, DirName.Up));
                        queue.Enqueue((curPoint, DirName.Down));
                        break;
                    case (DirName.Up, '-'):
                    case (DirName.Down, '-'):
                        queue.Enqueue((curPoint, DirName.Left));
                        queue.Enqueue((curPoint, DirName.Right));
                        break;
                    case (DirName.Left, '/'):
                    case (DirName.Right, '\\'):
                        queue.Enqueue((curPoint, DirName.Down));
                        break;
                    case (DirName.Left, '\\'):
                    case (DirName.Right, '/'):
                        queue.Enqueue((curPoint, DirName.Up));
                        break;
                    case (DirName.Up, '\\'):
                    case (DirName.Down, '/'):
                        queue.Enqueue((curPoint, DirName.Left));
                        break;
                    case (DirName.Up, '/'):
                    case (DirName.Down, '\\'):
                        queue.Enqueue((curPoint, DirName.Right));
                        break;
                    default:
                        queue.Enqueue((curPoint, item.Dir));
                        break;
                }
                memo.Add((curPoint, item.Dir));
            }
            return memo.Select(s => s.Item1).Distinct().Count();
        }
    }
}