using System;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2016
{
    public class Day08
    {
        public Day08(Part p)
        {
            bool[,] lcd = new bool[6, 50];
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                int var1 = 0, var2 = 0;
                var words = line.Split(' ');
                switch (words[0])
                {
                    case "rect":
                        var1 = int.Parse(words[1].Split('x')[0]);
                        var2 = int.Parse(words[1].Split('x')[1]);
                        for (int y = 0; y < var2; ++y)
                            for (int x = 0; x < var1; ++x)
                                lcd[y, x] = true;
                        break;
                    case "rotate":
                        var1 = int.Parse(words[2].Split('=')[1]);
                        var2 = int.Parse(words[4]);
                        if (words[1] == "row")
                        {
                            bool[,] lcdTmp = CloneLcd(lcd);
                            for (int x = 0; x < lcd.GetLength(1); ++x)
                                lcd[var1, (x + var2) % lcd.GetLength(1)] = lcdTmp[var1, x];
                        }
                        else if (words[1] == "column")
                        {
                            bool[,] lcdTmp = CloneLcd(lcd);
                            for (int y = 0; y < lcd.GetLength(0); ++y)
                                lcd[(y + var2) % 6, var1] = lcdTmp[y, var1];
                        }
                        break;
                }
            }
            if (p == Part.Part1)
                Console.WriteLine(lcd.Cast<bool>().Count(b => b == true));
            else if (p == Part.Part2)
                for (int y = 0; y < lcd.GetLength(0); ++y)
                {
                    for (int x = 0; x < lcd.GetLength(1); ++x)
                        Console.Write(lcd[y, x] ? '█' : ' ');
                    Console.WriteLine();
                }
        }

        private bool[,] CloneLcd(bool[,] lcd)
        {
            bool[,] result = new bool[lcd.GetLength(0), lcd.GetLength(1)];
            for (int y = 0; y < result.GetLength(0); ++y)
                for (int x = 0; x < result.GetLength(1); ++x)
                    result[y, x] = lcd[y, x];
            return result;
        }
    }
}
