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
        public Day03(Part p)
        {
            var result = 0;
            string line;
            var tab = new List<string>();
            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                tab.Add(line);
            for (int y = 0; y < tab.Count; ++y)
                for (int x = 0; x < tab[y].Length; ++x)
                {
                    if (p == Part.Part1)
                    {
                        var str = tab[y][x..].TakeWhile(char.IsDigit).ToList();
                        if (str.Any())
                        {
                            if (IsNumberOK(tab, x, y, str.Count))
                                result += int.Parse(string.Concat(str));
                            x += str.Count - 1;
                        }
                    }
                    else if (p == Part.Part2)
                    {
                        if (tab[y][x] == '*')
                            result += FindTwoAdjacentNumbers(tab, x, y);
                    }
                }
            Console.WriteLine(result);
        }

        private bool IsNumberOK(List<string> tab, int x, int y, int length)
        {
            int x1 = x == 0 ? x : x - 1;
            int y1 = y == 0 ? y : y - 1;
            int x2 = x + length == tab[y].Length ? tab[y].Length - 1 : x + length;
            int y2 = y == tab.Count - 1 ? tab.Count - 1 : y + 1;
            int size = length + (x == 0 || x + length == tab[y].Length ? 1 : 2);
            var result = y != 0 && tab[y1].Substring(x1, size).Any(a => a != '.') ||
                         x != 0 && tab[y][x1] != '.' ||
                         x + length != tab[y].Length && tab[y][x2] != '.' ||
                         y != tab.Count - 1 && tab[y2].Substring(x1, size).Any(a => a != '.');
            return result;
        }

        private int FindTwoAdjacentNumbers(List<string> tab, int x, int y)
        {
            var listNumber = new List<int>();
            int x1 = x == 0 ? x : x - 1;
            int y1 = y == 0 ? y : y - 1;
            int x2 = x + 1 == tab[y].Length ? tab[y].Length - 1 : x + 1;
            int y2 = y == tab.Count - 1 ? tab.Count - 1 : y + 1;
            if (char.IsDigit(tab[y][x1]))
                listNumber.Add(GetNumberReverse(tab, x1, y));
            if (char.IsDigit(tab[y][x2]))
                listNumber.Add(GetNumber(tab, x2, y));
            if (y != 0)
            {
                if (char.IsDigit(tab[y1][x]))
                {
                    int dpt = x;
                    while (true)
                    {
                        if (!char.IsDigit(tab[y1][dpt]))
                        {
                            ++dpt;
                            break;
                        }
                        if (dpt == 0)
                            break;
                        --dpt;
                    }
                    listNumber.Add(GetNumber(tab, dpt != x ? dpt : x, y1));
                }
                else
                {
                    if (char.IsDigit(tab[y1][x1]))
                        listNumber.Add(GetNumberReverse(tab, x1, y1));
                    if (char.IsDigit(tab[y1][x2]))
                        listNumber.Add(GetNumber(tab, x2, y1));
                }
            }
            if (y != tab.Count - 1)
            {
                if (char.IsDigit(tab[y2][x]))
                {
                    int dpt = x;
                    while (true)
                    {
                        if (!char.IsDigit(tab[y2][dpt]))
                        {
                            ++dpt;
                            break;
                        }
                        if (dpt == 0)
                            break;
                        --dpt;
                    }
                    listNumber.Add(GetNumber(tab, dpt != x ? dpt : x, y2));
                }
                else
                {
                    if (char.IsDigit(tab[y2][x1]))
                        listNumber.Add(GetNumberReverse(tab, x1, y2));
                    if (char.IsDigit(tab[y2][x2]))
                        listNumber.Add(GetNumber(tab, x2, y2));
                }
            }
            return listNumber.Count == 2 ? listNumber[0] * listNumber[1] : 0;
        }

        private int GetNumber(List<string> tab, int x, int y)
        {
            var result = new List<char> { tab[y][x] };
            for (int i = x + 1; i < tab[y].Length; ++i)
                if (char.IsDigit(tab[y][i]))
                    result.Add(tab[y][i]);
                else
                    break;
            return int.Parse(string.Concat(result));
        }

        private int GetNumberReverse(List<string> tab, int x, int y)
        {
            var result = new List<char> { tab[y][x] };
            for (int i = x - 1; i >= 0; --i)
                if (char.IsDigit(tab[y][i]))
                    result.Insert(0, tab[y][i]);
                else
                    break;
            return int.Parse(string.Concat(result));
        }
    }
}