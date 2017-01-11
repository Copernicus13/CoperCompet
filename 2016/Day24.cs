using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Combinatorics;
using AdventOfCode.Common.Data;

namespace AdventOfCode._2016
{
    public class Day24
    {
        private const int MapWidth = 185;
        private const int MapHeight = 41;

        private Point[] _Dir =
            {
                new Point(0, -1), new Point(-1, 0),
                new Point(0, 1), new Point(1, 0)
            };

        private int[,] _Map = new int[MapHeight, MapWidth];

        public Day24(Part p)
        {
            IDictionary<int, Point> positions = new SortedDictionary<int, Point>();
            for (int y = 0; y < MapHeight; ++y)
            {
                string line = Console.ReadLine();
                for (int x = 0; x < MapWidth; ++x)
                {
                    _Map[y, x] = line[x] == '#' ? -1 : int.MaxValue;
                    if (line[x] != '#' && line[x] != '.')
                        positions[int.Parse(line[x].ToString())] = new Point(x, y);
                }
            }

            int[,] distances = ComputeDistances(positions);
            var permutations = Enumerable.Range(1, positions.Count - 1).ToArray();
            int res = int.MaxValue;
            do
            {
                int cpt = distances[0, permutations[0]];
                for (int i = 0; i < permutations.Length - 1; ++i)
                    cpt += distances[permutations[i], permutations[i + 1]];
                if (p == Part.Part2)
                    cpt += distances[permutations.Last(), 0];
                res = Math.Min(res, cpt);
            } while (Permutations<object>.GetNext(permutations));
            Console.WriteLine(res);
        }

        private int[,] ComputeDistances(IDictionary<int, Point> positions)
        {
            var distances = new int[positions.Count, positions.Count];
            for (int i = 0; i < positions.Count; ++i)
                for (int j = 0; j < positions.Count; ++j)
                    if (j == i)
                        distances[i, j] = 0;
                    else
                        distances[i, j] = ShortestPath(positions[i], positions[j]);
            return distances;
        }

        private int ShortestPath(Point startPoint, Point targetPoint)
        {
            var queue = new Queue<Point>();
            var mapClone = _Map.Clone() as int[,];
            mapClone[startPoint.y, startPoint.x] = 0;
            queue.Enqueue(new Point(startPoint.x, startPoint.y));
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var dir in _Dir)
                {
                    var x = current.x + dir.x;
                    var y = current.y + dir.y;
                    if (x >= 0 && x < MapWidth && y >= 0 && y < MapHeight &&
                        mapClone[y, x] == int.MaxValue)
                    {
                        mapClone[y, x] = mapClone[current.y, current.x] + 1;
                        queue.Enqueue(new Point(x, y));
                    }
                }
            }
            return mapClone[targetPoint.y, targetPoint.x];
        }
    }
}
