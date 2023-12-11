using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/11
    /// </summary>
    public class Day11
    {
        private readonly Point[] _dirTab = { new(-1, 0), new(0, -1), new(1, 0), new(0, 1) };
        private enum DirName { Left, Up, Right, Down };

        public Day11(Part p)
        {
            long result = 0;

            if (p == Part.Part1)
                result = Part1();
            else if (p == Part.Part2)
                result = Part2();

            Console.WriteLine(result);
        }

        private long Part1()
        {
            long result = 0;
            string line;
            var map = new List<List<char>>();

            // Parse
            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                for (int i = 0; i < (line.All(a => a == '.') ? 2 : 1); ++i)
                {
                    var g = new List<char>();
                    map.Add(g);
                    map.Last().AddRange(line.AsEnumerable());
                }
            }

            // Copy to array
            char[,] tab = new char[map.Count, map[0].Count];
            for (int y = 0; y < tab.GetLength(0); ++y)
                for (int x = 0; x < tab.GetLength(1); ++x)
                    tab[y, x] = map[y][x];

            // Expand universe for columns
            var nbColumnToExpand = new List<int>();
            for (int i = 0; i < tab.GetLength(1); ++i)
                if (tab.GetColumn(i).All(a => a == '.'))
                    nbColumnToExpand.Add(i);
            foreach (var row in map)
                for (var index = nbColumnToExpand.Count - 1; index >= 0; --index)
                    row.Insert(nbColumnToExpand[index], '.');

            // Copy to array again
            tab = new char[map.Count, map[0].Count];
            for (int y = 0; y < tab.GetLength(0); ++y)
                for (int x = 0; x < tab.GetLength(1); ++x)
                    tab[y, x] = map[y][x];

            var galaxies = new List<Point>();
            for (int y = 0; y < tab.GetLength(0); ++y)
                for (int x = 0; x < tab.GetLength(1); ++x)
                    if (tab[y, x] == '#')
                        galaxies.Add(new Point(x, y));

            while (galaxies.Count > 0)
            {
                var currentGalaxy = galaxies[0];
                var tabDistances = ShortestPath(tab, new Point(currentGalaxy.X, currentGalaxy.Y));
                foreach (var point in galaxies.Skip(1))
                    result += tabDistances[point.Y, point.X];
                galaxies.RemoveAt(0);
            }

            return result;
        }

        private long Part2()
        {
            long result = 0;
            string line;
            var map = new List<List<char>>();

            // Parse
            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                var g = new List<char>();
                map.Add(g);
                map.Last().AddRange(line.AsEnumerable());
            }

            // Copy to array
            char[,] tab = new char[map.Count, map[0].Count];
            for (int y = 0; y < tab.GetLength(0); ++y)
                for (int x = 0; x < tab.GetLength(1); ++x)
                    tab[y, x] = map[y][x];

            var galaxies = new List<Point>();
            for (int y = 0; y < tab.GetLength(0); ++y)
                for (int x = 0; x < tab.GetLength(1); ++x)
                    if (tab[y, x] == '#')
                        galaxies.Add(new Point(x, y));

            var rowMalus = new List<int>();
            var colMalus = new List<int>();

            for (int x = 0; x < tab.GetLength(1); ++x)
                if (tab.GetColumn(x).All(a => a == '.'))
                    colMalus.Add(x);

            for (int y = 0; y < tab.GetLength(0); ++y)
                if (tab.GetRow(y).All(a => a == '.'))
                    rowMalus.Add(y);

            while (galaxies.Count > 0)
            {
                var currentGalaxy = galaxies[0];
                var tabDistances = ShortestPathWithMalus(tab,
                    new Point(currentGalaxy.X, currentGalaxy.Y), rowMalus, colMalus, 1000000 - 1);
                foreach (var point in galaxies.Skip(1))
                    result += tabDistances[point.Y, point.X];
                galaxies.RemoveAt(0);
            }

            return result;
        }

        private long[,] ShortestPath(char[,] tab, Point startPoint)
        {
            long[,] mapClone = new long[tab.GetLength(0), tab.GetLength(1)];
            for (int y = 0; y < tab.GetLength(0); ++y)
                for (int x = 0; x < tab.GetLength(1); ++x)
                    mapClone[y, x] = long.MaxValue;
            mapClone[startPoint.Y, startPoint.X] = 0;
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(startPoint.X, startPoint.Y));
            while (queue.Any())
            {
                var current = queue.Dequeue();
                foreach (var dir in _dirTab)
                {
                    var x = current.X + dir.X;
                    var y = current.Y + dir.Y;
                    if (x >= 0 && x < tab.GetLength(1) && y >= 0 && y < tab.GetLength(0) &&
                        mapClone[y, x] == long.MaxValue)
                    {
                        mapClone[y, x] = mapClone[current.Y, current.X] + 1;
                        queue.Enqueue(new Point(x, y));
                    }
                }
            }
            return mapClone;
        }

        private long[,] ShortestPathWithMalus(char[,] tab, Point startPoint,
            List<int> malusRow, List<int> malusColumn, int malusValue)
        {
            long[,] mapClone = new long[tab.GetLength(0), tab.GetLength(1)];
            for (int y = 0; y < tab.GetLength(0); ++y)
                for (int x = 0; x < tab.GetLength(1); ++x)
                    mapClone[y, x] = long.MaxValue;
            mapClone[startPoint.Y, startPoint.X] = 0L;
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(startPoint.X, startPoint.Y));
            while (queue.Any())
            {
                var current = queue.Dequeue();
                for (var i = 0; i < _dirTab.Length; ++i)
                {
                    var dir = _dirTab[i];
                    var x = current.X + dir.X;
                    var y = current.Y + dir.Y;
                    if (x >= 0 && x < tab.GetLength(1) && y >= 0 && y < tab.GetLength(0) &&
                        mapClone[y, x] == long.MaxValue)
                    {
                        long distance = 1L;
                        if (i is (int)DirName.Left or (int)DirName.Right && malusColumn.Contains(current.X) ||
                            i is (int)DirName.Up or (int)DirName.Down && malusRow.Contains(current.Y))
                            distance += malusValue;
                        mapClone[y, x] = mapClone[current.Y, current.X] + distance;
                        queue.Enqueue(new Point(x, y));
                    }
                }
            }
            return mapClone;
        }
    }
}