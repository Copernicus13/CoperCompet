using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/17
    /// </summary>
    public class Day17
    {
        public record TreeNode
        {
            public Point P;
            public int NbStep;
            public DirName Dir;
            public override string ToString() => $"Point:{P.X};{P.Y}-Dir:{Dir}-Cruc={NbStep}";
        }

        private readonly Point[] _dirTab = { new(-1, 0), new(0, -1), new(1, 0), new(0, 1) };
        public enum DirName { Left, Up, Right, Down };

        public Day17(Part p)
        {
            string line;
            var map = new List<List<int>>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                map.Add(line.Select(s => s - '0').ToList().ConvertAll(Convert.ToInt32));

            var tab = map.ToJaggedArray();

            int result = ShortestPath(tab, p,
                new Point(0, 0), new Point(tab.GetLength(1) - 1, tab.GetLength(0) - 1));

            Console.WriteLine(result);
        }

        private int ShortestPath(int[,] tab, Part p, Point startPoint, Point finishPoint)
        {
            var root = new TreeNode
            {
                P = new Point(startPoint.X, startPoint.Y),
                Dir = DirName.Right,
                NbStep = 0
            };
            var queue = new PriorityQueue<TreeNode, int>();
            var explored = new HashSet<int>();
            queue.Enqueue(root, 0);
            queue.Enqueue(root with { Dir = DirName.Down }, 0);
            while (queue.Count > 0)
            {
                var current = queue.Peek();
                var heatLoss = queue.UnorderedItems.First(i => i.Element == current).Priority;
                queue.Dequeue();
                for (var i = 0; i < _dirTab.Length; ++i)
                {
                    if (p == Part.Part2 && current.NbStep < 4 && (int)current.Dir != i)
                        continue;
                    if (current.Dir == DirName.Left && i == (int)DirName.Right)
                        continue;
                    if (current.Dir == DirName.Up && i == (int)DirName.Down)
                        continue;
                    if (current.Dir == DirName.Right && i == (int)DirName.Left)
                        continue;
                    if (current.Dir == DirName.Down && i == (int)DirName.Up)
                        continue;
                    int nbStepCrucible = 1;
                    if ((int)current.Dir == i)
                    {
                        nbStepCrucible = current.NbStep + 1;
                        if (p == Part.Part1 && nbStepCrucible == 4)
                            continue;
                        if (p == Part.Part2 && nbStepCrucible == 11)
                            continue;
                    }
                    var dir = _dirTab[i];
                    var x = current.P.X + dir.X;
                    var y = current.P.Y + dir.Y;
                    if (x >= 0 && x < tab.GetLength(1) && y >= 0 && y < tab.GetLength(0))
                    {
                        var newNode = new TreeNode
                        {
                            P = new Point(x, y),
                            NbStep = nbStepCrucible,
                            Dir = (DirName)i
                        };
                        if (explored.Contains(((tab.GetLength(1) * y + x) << 6) + (nbStepCrucible << 2) + i))
                            continue;
                        explored.Add(((tab.GetLength(1) * y + x) << 6) + (nbStepCrucible << 2) + i);
                        queue.Enqueue(newNode, heatLoss + tab[y, x]);
                    }
                    if (x == finishPoint.X && y == finishPoint.Y)
                        return heatLoss + tab[y, x];
                }
            }
            return -1;
        }
    }
}