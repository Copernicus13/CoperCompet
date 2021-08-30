using System;
using HackerCup._2021.Qualification;

namespace HackerCup.Launcher
{
    public static class Program
    {
        public static void Main(string[] _)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new ConsistencyC1();
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Appuyez sur une touche pour continuer…");
                Console.Read();
            }
        }
    }
}
