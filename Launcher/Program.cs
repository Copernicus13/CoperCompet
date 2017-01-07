using System;
using HackerCup._2017.Qualification;

namespace HackerCup.Launcher
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new ProgressPie();
            Console.Write("Appuyez sur une touche pour continuer…");
            Console.Read();
        }
    }
}
