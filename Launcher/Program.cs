using System;
using HackerCup._2017.Round1;

namespace HackerCup.Launcher
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new FightingTheZombies();
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Appuyez sur une touche pour continuer…");
                Console.Read();
            }
        }
    }
}
