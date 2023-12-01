using System;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/1
    /// </summary>
    public class Day01
    {
        public Day01(Part p)
        {
            var result = 0;
            string line;

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                if (p == Part.Part1)
                    result += int.Parse(string.Empty + line.First(char.IsDigit) + line.Last(char.IsDigit));
                else if (p == Part.Part2)
                    result += GetNumber(line);
            }

            Console.WriteLine(result);
        }

        private int GetNumber(string line)
        {
            var digits = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var digitsInLetter = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var idxFirstDigit = line.IndexOfAny(digits);
            var idxLastDigit = line.LastIndexOfAny(digits);
            var idxFirstDigitInLetter = -1;
            var idxLastDigitInLetter = -1;
            for (var i = 0;
                 i < (idxFirstDigit == -1 ? line.Length : idxFirstDigit) && idxFirstDigitInLetter == -1;
                 ++i)
                for (var j = 3; j <= 5 && idxFirstDigitInLetter == -1; ++j)
                    if (i + j <= line.Length)
                        idxFirstDigitInLetter = digitsInLetter.ToList().IndexOf(line.Substring(i, j));

            for (var i = line.Length - 3;
                 i >= (idxLastDigit == -1 ? 0 : idxLastDigit) && idxLastDigitInLetter == -1;
                 --i)
                for (var j = 3; j <= 5 && idxLastDigitInLetter == -1; ++j)
                    if (i + j <= line.Length)
                        idxLastDigitInLetter = digitsInLetter.ToList().IndexOf(line.Substring(i, j));
            var m = int.Parse(
                string.Empty +
                (idxFirstDigitInLetter == -1 ? line[idxFirstDigit] - '0' : idxFirstDigitInLetter + 1) +
                (idxLastDigitInLetter == -1 ? line[idxLastDigit] - '0' : idxLastDigitInLetter + 1));
            return int.Parse(
                string.Empty +
                (idxFirstDigitInLetter == -1 ? line[idxFirstDigit] - '0' : idxFirstDigitInLetter + 1) +
                (idxLastDigitInLetter == -1 ? line[idxLastDigit] - '0' : idxLastDigitInLetter + 1));
        }
    }
}