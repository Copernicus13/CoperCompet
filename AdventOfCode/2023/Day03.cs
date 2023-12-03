using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/3
    /// </summary>
    public class Day03
    {
        private readonly IList<string> _tab = new List<string>();

        public Day03(Part p)
        {
            var result = 0;
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                _tab.Add(line);
            for (int y = 0; y < _tab.Count; ++y)
                for (int x = 0; x < _tab[y].Length; ++x)
                {
                    if (p == Part.Part1)
                    {
                        var str = _tab[y][x..].TakeWhile(char.IsDigit).ToList();
                        if (str.Any())
                        {
                            if (IsNumberOk(x, y, str.Count))
                                result += int.Parse(string.Concat(str));
                            x += str.Count - 1;
                        }
                    }
                    else if (p == Part.Part2)
                    {
                        if (_tab[y][x] == '*')
                            result += FindTwoAdjacentNumbers(x, y);
                    }
                }
            Console.WriteLine(result);
        }

        private bool IsNumberOk(int x, int y, int length)
        {
            GetBoundaries(x, y, length, out var x1, out var y1, out var x2, out var y2);
            int size = length + (x == 0 || x + length == _tab[y].Length ? 1 : 2);
            var result = y != 0 && _tab[y1].Substring(x1, size).Any(a => a != '.') ||
                         x != 0 && _tab[y][x1] != '.' ||
                         x + length != _tab[y].Length && _tab[y][x2] != '.' ||
                         y != _tab.Count - 1 && _tab[y2].Substring(x1, size).Any(a => a != '.');
            return result;
        }

        private int FindTwoAdjacentNumbers(int x, int y)
        {
            GetBoundaries(x, y, 1, out var x1, out var y1, out var x2, out var y2);
            var listNumber = new List<int>();
            if (char.IsDigit(_tab[y][x1]))
                listNumber.Add(GetNumberLeftOrRight(x1, y, true));
            if (char.IsDigit(_tab[y][x2]))
                listNumber.Add(GetNumberLeftOrRight(x2, y));
            if (y != 0)
                listNumber.AddRange(GetNumbersUpOrDown(x, x1, x2, y1));
            if (y != _tab.Count - 1)
                listNumber.AddRange(GetNumbersUpOrDown(x, x1, x2, y2));
            return listNumber.Count == 2 ? listNumber[0] * listNumber[1] : 0;
        }

        private int GetNumberLeftOrRight(int x, int y, bool reverse = false)
        {
            var result = new List<char> { _tab[y][x] };
            if (!reverse)
                for (int i = x + 1; i < _tab[y].Length && char.IsDigit(_tab[y][i]); ++i)
                    result.Add(_tab[y][i]);
            else
                for (int i = x - 1; i >= 0 && char.IsDigit(_tab[y][i]); --i)
                    result.Insert(0, _tab[y][i]);
            return int.Parse(string.Concat(result));
        }

        private IList<int> GetNumbersUpOrDown(int x, int x1, int x2, int y)
        {
            var result = new List<int>();
            if (char.IsDigit(_tab[y][x]))
            {
                int dpt = x;
                while (true)
                {
                    if (!char.IsDigit(_tab[y][dpt]))
                    {
                        ++dpt;
                        break;
                    }

                    if (dpt == 0)
                        break;
                    --dpt;
                }
                result.Add(GetNumberLeftOrRight(dpt != x ? dpt : x, y));
            }
            else
            {
                if (char.IsDigit(_tab[y][x1]))
                    result.Add(GetNumberLeftOrRight(x1, y, true));
                if (char.IsDigit(_tab[y][x2]))
                    result.Add(GetNumberLeftOrRight(x2, y));
            }
            return result;
        }

        private void GetBoundaries(int x, int y, int length, out int x1, out int y1, out int x2, out int y2)
        {
            x1 = x == 0 ? x : x - 1;
            y1 = y == 0 ? y : y - 1;
            x2 = x + length == _tab[y].Length ? _tab[y].Length - 1 : x + length;
            y2 = y == _tab.Count - 1 ? _tab.Count - 1 : y + 1;
        }
    }
}