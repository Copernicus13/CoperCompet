﻿using System;
using AdventOfCode.Common;

namespace AdventOfCode.Launcher
{
    public static class Program
    {
        public static void Main(string[] _)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new _2021.Day03(Part.Part2);
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Appuyez sur une touche pour continuer…");
                Console.Read();
            }
        }
    }
}