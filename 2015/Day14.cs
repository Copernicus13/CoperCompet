using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/14
    /// </summary>
    public class Day14
    {
        private enum ReinDeer
        {
            Dancer,
            Cupid,
            Rudolph,
            Donner,
            Dasher,
            Blitzen,
            Prancer,
            Comet,
            Vixen
        }

        private readonly IDictionary<ReinDeer, Tuple<int, int, int>> _dict;

        public Day14(Part p)
        {
            int nbReinDeers = Enum.GetValues(typeof(ReinDeer)).Length;
            _dict = new Dictionary<ReinDeer, Tuple<int, int, int>>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var words = line.Split(' ');
                _dict[ToRD(words[0])] = new Tuple<int, int, int>(
                    int.Parse(words[3]), int.Parse(words[6]), int.Parse(words[13]));
            }

            int[] result = new int[nbReinDeers];

            if (p == Part.Part1)
            {
                for (int i = 0; i < nbReinDeers; ++i)
                {
                    var tup = _dict[(ReinDeer)i];
                    var fullCycles = 2503 / (tup.Item2 + tup.Item3);
                    var remnant = 2503 % (tup.Item2 + tup.Item3);
                    result[i] = tup.Item1 * tup.Item2 * fullCycles;
                    if (remnant < tup.Item2)
                        result[i] += tup.Item1 * remnant;
                    else
                        result[i] += tup.Item1 * tup.Item2;
                }
            }
            else if (p == Part.Part2)
            {
                IDictionary<ReinDeer, int> _race = new Dictionary<ReinDeer, int>();
                for (int i = 0; i < nbReinDeers; ++i)
                    _race.Add((ReinDeer)i, 0);

                for (int i = 0; i < 2503; ++i)
                {
                    for (int j = 0; j < nbReinDeers; ++j)
                    {
                        var tup = _dict[(ReinDeer)j];
                        var cycle = tup.Item2 + tup.Item3;
                        var action = i % cycle;
                        if (action < tup.Item2)
                            _race[(ReinDeer)j] += tup.Item1;
                    }
                    var max = _race.Values.Max();
                    _race.Where(w => w.Value == max)
                        .ToList()
                        .ForEach(f => ++result[(int)f.Key]);
                }
            }
            Console.WriteLine(result.ToList().Max());
        }

        private static ReinDeer ToRD(string reinDeer)
        {
            return (ReinDeer)Enum.Parse(typeof(ReinDeer), reinDeer);
        }
    }
}
