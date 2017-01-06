using System;
using AdventOfCode.Common;

namespace AdventOfCode.Launcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new _2016.Day21(Part.Part2);
            Console.Write("Appuyez sur une touche pour continuer…");
            Console.Read();
        }
    }
}
