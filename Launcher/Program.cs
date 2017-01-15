using System;

namespace AdventOfCode.Launcher
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new _2016.Day25();
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Appuyez sur une touche pour continuer…");
                Console.Read();
            }
        }
    }
}
