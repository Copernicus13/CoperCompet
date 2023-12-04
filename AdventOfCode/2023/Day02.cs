using System;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/2
    /// </summary>
    public class Day02
    {
        private struct Game
        {
            public int IdGame { get; set; }
            public int MaxNbRed { get; set; }
            public int MaxNbGreen { get; set; }
            public int MaxNbBlue { get; set; }
            public readonly int Power => MaxNbRed * MaxNbGreen * MaxNbBlue;
        }

        private readonly Game _refGame = new Game { IdGame = 0, MaxNbRed = 12, MaxNbGreen = 13, MaxNbBlue = 14 };

        public Day02(Part p)
        {
            var result = 0;
            string line;

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                var cube = ParseLine(line);
                if (p == Part.Part1)
                {
                    if (cube.MaxNbRed <= _refGame.MaxNbRed ||
                        cube.MaxNbGreen <= _refGame.MaxNbGreen ||
                        cube.MaxNbBlue <= _refGame.MaxNbBlue)
                        result += cube.IdGame;
                }
                else
                    result += cube.Power;
            }

            Console.WriteLine(result);
        }

        private Game ParseLine(string line)
        {
            var result = new Game { IdGame = int.Parse(line.Substring(5, line.IndexOf(':') - 5)) };
            foreach (var set in line.Split(':')[1].Split(';').Select(s => s.Trim()))
            {
                foreach (var cube in set.Split(',').Select(s => s.Trim()))
                {
                    var infoCube = cube.Split(' ');
                    var value = int.Parse(infoCube[0]);
                    if (infoCube[1] == "red" && value > result.MaxNbRed)
                        result.MaxNbRed = value;
                    else if (infoCube[1] == "green" && value > result.MaxNbGreen)
                        result.MaxNbGreen = value;
                    else if (infoCube[1] == "blue" && value > result.MaxNbBlue)
                        result.MaxNbBlue = value;
                }
            }
            return result;
        }
    }
}