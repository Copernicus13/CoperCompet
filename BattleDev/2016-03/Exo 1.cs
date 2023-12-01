using System;

namespace BattleDev._2016_03
{
    public class Exo1
    {
        public Exo1()
        {
            int nbWords = int.Parse(Console.ReadLine());
            int longest = 0;

            for (int i = 0; i < nbWords; ++i)
            {
                longest = Math.Max(Console.ReadLine().Length, longest);
            }

            Console.WriteLine(longest);
        }
    }
}
