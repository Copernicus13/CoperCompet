using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/10
    /// </summary>
    public class Day10
    {
        public class Bot
        {
            public int Id { get; private set; }
            public IList<int> Values { get; set; } = new List<int>();

            public int HighVal { get { return Values.Any() ? Values.Max() : -1; } }
            public int LowVal { get { return Values.Any() ? Values.Min() : -1; } }
            public bool HasAtLeast2Chips { get { return Values.Count >= 2; } }

            public Bot(int id)
            {
                Id = id;
            }
        }

        public Day10(Part p)
        {
            string line;
            IList<string> instr = new List<string>();
            IList<Bot> bots = new List<Bot>();
            IList<Bot> output = new List<Bot>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                instr.Add(line);

            var lastBotId = instr.Max(w => int.Parse(w.Split(' ')[w.Split(' ')[0] == "bot" ? 1 : 5]));
            var lastOutputId = instr
                .Where(w => w.Split(' ')[0] == "bot" && (w.Split(' ')[5] == "output" || w.Split(' ')[10] == "output"))
                .Max(s => s.Split(' ')[5] == "output" ?
                    s.Split(' ')[10] == "output" ?
                        Math.Max(int.Parse(s.Split(' ')[6]), int.Parse(s.Split(' ')[11])) :
                        int.Parse(s.Split(' ')[6]) :
                    int.Parse(s.Split(' ')[11]));

            for (int i = 0; i <= lastBotId; ++i)
                bots.Add(new Bot(i));
            for (int i = 0; i <= lastOutputId; ++i)
                output.Add(new Bot(i));

            foreach (var s in instr.Where(w => w.Split(' ')[0] == "value"))
            {
                int nBot = int.Parse(s.Split(' ')[5]);
                int value = int.Parse(s.Split(' ')[1]);
                if (s.Split(' ')[4] == "bot")
                    bots[nBot].Values.Add(value);
                else
                    output[nBot].Values.Add(value);
            }

            bool modif = false;
            int res = 0;
            do
            {
                modif = false;
                foreach (var s in instr.Where(w => w.Split(' ')[0] == "bot"))
                {
                    int nBot = int.Parse(s.Split(' ')[1]);
                    if (!bots[nBot].HasAtLeast2Chips)
                        continue;

                    modif = true;

                    if (p == Part.Part1 && bots.Any(a => a.LowVal == 17 && a.HighVal == 61))
                        res = bots.First(a => a.LowVal == 17 && a.HighVal == 61).Id;

                    int nLowBot = int.Parse(s.Split(' ')[6]);
                    int nHighBot = int.Parse(s.Split(' ')[11]);
                    if (s.Split(' ')[5] == "bot")
                        bots[nLowBot].Values.Add(bots[nBot].LowVal);
                    else
                        output[nLowBot].Values.Add(bots[nBot].LowVal);
                    if (s.Split(' ')[10] == "bot")
                        bots[nHighBot].Values.Add(bots[nBot].HighVal);
                    else
                        output[nHighBot].Values.Add(bots[nBot].HighVal);
                    bots[nBot].Values.Remove(bots[nBot].LowVal);
                    bots[nBot].Values.Remove(bots[nBot].HighVal);
                }
            } while (modif);

            if (p == Part.Part1)
                Console.WriteLine(res);
            else if (p == Part.Part2)
                Console.WriteLine(output.Where(w => new List<int> { 0, 1, 2 }.Contains(w.Id))
                    .Aggregate(1, (a, b) => a * b.Values.Aggregate(1, (c, d) => c * d)));
        }
    }
}
