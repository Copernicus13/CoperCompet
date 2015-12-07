using System;
using AdventOfCode.Common;

namespace AdventOfCode.Launcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new _2015.Day1(Part.Part2);
            Console.Write("Appuyez sur une touche pour continuer…");
            Console.ReadKey();
        }
    }
}
