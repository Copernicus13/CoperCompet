using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/22
    /// </summary>
    public class Day22
    {
        private const int MapWidth = 39;
        private const int MapHeight = 25;

        private Point[] _Dir =
            {
                new Point(0, -1), new Point(-1, 0),
                new Point(0, 1), new Point(1, 0)
            };

        public Day22(Part p)
        {
            // Tuple<int, int> -> Item1 = Size (capacity), Item2 = Used
            Tuple<int, int>[,] grid = new Tuple<int, int>[MapHeight, MapWidth];
            string line;
            Console.ReadLine();
            Console.ReadLine();
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var splitted = line.Split(new[] { '-', ' ', 'x', 'y', 'T' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1).Take(4)
                    .Select(s => int.Parse(s))
                    .ToList();
                grid[splitted[1], splitted[0]] = new Tuple<int, int>(splitted[2], splitted[3]);
            }

            var list = grid.ToList();
            int res = 0;
            if (p == Part.Part1)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i].Item2 == 0)
                        continue;
                    for (int j = 0; j < list.Count; ++j)
                    {
                        if (j == i)
                            continue;
                        if (list[i].Item2 <= list[j].Item1 - list[j].Item2)
                            ++res;
                    }
                }
            }
            else if (p == Part.Part2)
            {
                int idx = list.FindIndex(w => w.Item2 == 0);
                var startPoint = new Point(idx % MapWidth, idx / MapWidth);
                var intermediatePoint = new Point(MapWidth - 1, 0);
                var endPoint = new Point(0, 0);
                res = ShortestPath(PrepareMap(grid), startPoint, intermediatePoint) +
                    (ShortestPath(PrepareMap(grid), intermediatePoint, endPoint) - 1) * 5;
            }
            Console.WriteLine(res);
        }

        private int[,] PrepareMap(Tuple<int, int>[,] grid)
        {
            int[,] map = new int[MapHeight, MapWidth];
            for (int y = 0; y < MapHeight; ++y)
                for (int x = 0; x < MapWidth; ++x)
                    map[y, x] = grid[y, x].Item1 < 100 ? int.MaxValue : -1;
            return map;
        }

        private int ShortestPath(int[,] map, Point startPoint, Point targetPoint)
        {
            var queue = new Queue<Point>();
            map[startPoint.Y, startPoint.X] = 0;
            queue.Enqueue(new Point(startPoint.X, startPoint.Y));
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var dir in _Dir)
                {
                    var x = current.X + dir.X;
                    var y = current.Y + dir.Y;
                    if (x >= 0 && x < MapWidth && y >= 0 && y < MapHeight &&
                        map[y, x] == int.MaxValue)
                    {
                        map[y, x] = map[current.Y, current.X] + 1;
                        queue.Enqueue(new Point(x, y));
                    }
                }
            }
            return map[targetPoint.Y, targetPoint.X];
        }
    }
}
