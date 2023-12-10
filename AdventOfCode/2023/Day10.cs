using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/10
    /// </summary>
    public class Day10
    {
        private const int MaTabSize = 140;
        private Point[] _Dir = { new Point(-1, 0), new Point(0, -1), new Point(1, 0), new Point(0, 1) };
        private enum DirName { Left, Up, Right, Down, Start };

        private struct Position
        {
            public Point Pos;
            public DirName DirName;
            public int Distance;
        }

        private readonly char[,] _tab;
        private readonly char[,] _tab2;
        private static readonly char[] SourceArray = { '─', '│', '┌', '┐', '└', '┘', 'S' };

        public Day10(Part p)
        {
            string line = Console.ReadLine()!;
            _tab = new char[line.Length, line.Length];
            for (var x = 0; x < line.Length; ++x)
                _tab[0, x] = line[x];
            for (int y = 1; !string.IsNullOrEmpty(line = Console.ReadLine()!); ++y)
                for (var x = 0; x < line.Length; ++x)
                    _tab[y, x] = line[x];

            var indexStart = _tab.ToList().IndexOf('S');
            var currentPos =
                new Position
                {
                    Pos = new Point(indexStart % _tab.GetLength(1), indexStart / _tab.GetLength(1)),
                    DirName = DirName.Start,
                    Distance = 0
                };

            char currentChar = char.MinValue;
            while (currentChar != 'S')
            {
                currentPos.DirName = NextDir(currentPos.DirName, currentChar);
                ++currentPos.Distance;
                currentPos.Pos = new Point(
                    currentPos.Pos.X + _Dir[(int)currentPos.DirName].X,
                    currentPos.Pos.Y + _Dir[(int)currentPos.DirName].Y);
                currentChar = _tab[currentPos.Pos.Y, currentPos.Pos.X];
                _tab[currentPos.Pos.Y, currentPos.Pos.X] = PrettyPrint(currentChar); // for part 2
            }

            if (p == Part.Part1)
                Console.WriteLine(currentPos.Distance / 2);
            else if (p == Part.Part2)
            {
                _tab[indexStart / _tab.GetLength(1), indexStart % _tab.GetLength(1)] = '┐';

                for (int y = 0; y < _tab.GetLength(0); ++y)
                    for (var x = 0; x < _tab.GetLength(1); ++x)
                        if (!SourceArray.Contains(_tab[y, x]))
                            _tab[y, x] = ' ';

                for (int i = 0; i < _tab.GetLength(0); ++i)
                    Console.WriteLine(_tab.GetRow(i));

                _tab2 = new char[_tab.GetLength(0) * 2, _tab.GetLength(1) * 2];

                // agrandir la map initiale par 2
                for (int y = 0; y < _tab.GetLength(0); ++y)
                    for (var x = 0; x < _tab.GetLength(1); ++x)
                    {
                        _tab2[2 * y, 2 * x] = _tab[y, x];
                        _tab2[2 * y, 2 * x + 1] = AllongeNextChar(DirName.Right, _tab[y, x]);
                        _tab2[2 * y + 1, 2 * x] = AllongeNextChar(DirName.Down, _tab[y, x]);
                        _tab2[2 * y + 1, 2 * x + 1] = ' ';
                    }

                //for (int i = 0; i < 100; ++i)
                //    Console.WriteLine(_tab2.GetRow(i).Take(180).ToArray());

                Fill(0, 0);
                Fill(_tab2.GetLength(1) - 1, 0);
                Fill(_tab2.GetLength(1) - 1, _tab2.GetLength(0) - 1);
                Fill(0, _tab2.GetLength(0) - 1);

                // rétrécir la map agrandie par 2
                for (int y = 0; y < _tab.GetLength(0); ++y)
                    for (var x = 0; x < _tab.GetLength(1); ++x)
                        _tab[y, x] = _tab2[y * 2, x * 2];

                for (int i = 0; i < _tab.GetLength(0); ++i)
                    Console.WriteLine(_tab.GetRow(i));

                //for (int i = 0; i < _tab2.GetLength(0); ++i)
                //    Console.WriteLine(_tab2.GetRow(i).Take(230).ToArray());

                Console.WriteLine(_tab.ToList().Count(c => c == ' '));
            }
        }

        private void Fill(int x, int y)
        {
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(x, y));
            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                if (_tab2[p.Y, p.X] != ' ')
                    continue;
                _tab2[p.Y, p.X] = 'x';
                foreach (var dir in _Dir)
                {
                    var curX = p.X + dir.X;
                    var curY = p.Y + dir.Y;
                    if (curX >= 0 && curX < _tab2.GetLength(1) &&
                        curY >= 0 && curY < _tab2.GetLength(0) &&
                        _tab2[curY, curX] == ' ')
                    {
                        queue.Enqueue(new Point(curX, curY));
                    }
                }
            }
        }

        private static DirName NextDir(DirName currentDir, char currentChar) =>
            (currentDir, currentChar) switch
            {
                // Start is manually adjusted for the input
                (DirName.Start, char.MinValue) => DirName.Down,

                (DirName.Left, '-') => DirName.Left,
                (DirName.Left, 'L') => DirName.Up,
                (DirName.Left, 'F') => DirName.Down,
                (DirName.Up, '|') => DirName.Up,
                (DirName.Up, '7') => DirName.Left,
                (DirName.Up, 'F') => DirName.Right,
                (DirName.Right, '-') => DirName.Right,
                (DirName.Right, 'J') => DirName.Up,
                (DirName.Right, '7') => DirName.Down,
                (DirName.Down, '|') => DirName.Down,
                (DirName.Down, 'J') => DirName.Left,
                (DirName.Down, 'L') => DirName.Right,
                _ => throw new Exception("Invalid input")
            };

        private static char AllongeNextChar(DirName currentDir, char currentChar) =>
            (currentDir, currentChar) switch
            {
                (DirName.Right, '─') => '─',
                (DirName.Right, '┌') => '─',
                (DirName.Right, '└') => '─',
                (DirName.Down, '┌') => '│',
                (DirName.Down, '│') => '│',
                (DirName.Down, '┐') => '│',
                _ => ' '
            };

        private static char PrettyPrint(char currentChar) =>
            currentChar switch
            {
                'S' => 'S',
                '-' => '─',
                'L' => '└',
                'F' => '┌',
                '|' => '│',
                '7' => '┐',
                'J' => '┘',
                _ => throw new Exception("Invalid input")
            };
    }
}