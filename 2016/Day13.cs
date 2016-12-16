using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Data;

namespace AdventOfCode._2016
{
    public class Day13
    {
        private const int MapWidth = 100;
        private const int MapHeight = 100;
        private readonly Point StartPoint = new Point(1, 1);
        private readonly Point TargetPoint = new Point(31, 39);
        private const int NbStepsForPart2 = 50;

        private Point[] _Dir =
            {
                new Point(0, -1), new Point(-1, 0),
                new Point(0, 1), new Point(1, 0)
            };

        private int[,] _Map = new int[MapHeight, MapWidth];

        public Day13(Part p)
        {
            int designerNumber = int.Parse(Console.ReadLine());

            for (int y = 0; y < MapHeight; ++y)
                for (int x = 0; x < MapWidth; ++x)
                    _Map[y, x] =
                        NbSetBit((x + y) * (x + y) + 3 * x + y + designerNumber) % 2 == 0 ?
                            int.MaxValue : -1;

            ShortestPath(p, StartPoint, TargetPoint);
        }

        private void ShortestPath(Part p, Point startPoint, Point targetPoint)
        {
            var queue = new Queue<Point>();
            _Map[startPoint.y, startPoint.x] = 0;
            queue.Enqueue(new Point(startPoint.x, startPoint.y));
            while (queue.Any())
            {
                var current = queue.Dequeue();

                foreach (var dir in _Dir)
                {
                    var x = current.x + dir.x;
                    var y = current.y + dir.y;
                    if (x >= 0 && x < MapWidth && y >= 0 && y < MapHeight &&
                        _Map[y, x] == int.MaxValue)
                    {
                        _Map[y, x] = _Map[current.y, current.x] + 1;
                        queue.Enqueue(new Point(x, y));
                    }
                }
            }

            if (p == Part.Part1)
                Console.WriteLine(_Map[targetPoint.y, targetPoint.x]);
            else if (p == Part.Part2)
            {
                int cpt = 0;
                for (int j = 0; j < MapHeight; ++j)
                    for (int i = 0; i < MapWidth; ++i)
                        if (_Map[j, i] >= 0 && _Map[j, i] <= NbStepsForPart2)
                            ++cpt;
                Console.WriteLine(cpt);
            }
        }

        private static int NbSetBit(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return ((i + (i >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
        }
    }
}