using System;
using GoogleCodeJam._2022.Qualification;

namespace GoogleCodeJam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ChainReactions();
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Appuyez sur une touche pour continuer…");
                Console.Read();
            }
        }
    }
}
