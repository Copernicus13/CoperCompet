using System;
using System.Collections.Generic;

namespace BattleDev._2014_11
{
    public class Exo3
    {
        public Exo3()
        {
            IList<int> paveA = new List<int>();
            IList<int> paveB = new List<int>();

            string line = Console.ReadLine();
            for (int i = 0; i < 6; ++i)
                paveA.Add(int.Parse(line.Split(' ')[i]));
            line = Console.ReadLine();
            for (int i = 0; i < 6; ++i)
                paveB.Add(int.Parse(line.Split(' ')[i]));

            if (paveA[0].Between(paveB[0], paveB[3]) && paveA[1].Between(paveB[1], paveB[4]) && paveA[2].Between(paveB[2], paveB[5]) || // 1er pavé
                paveA[3].Between(paveB[0], paveB[3]) && paveA[1].Between(paveB[1], paveB[4]) && paveA[2].Between(paveB[2], paveB[5]) ||
                paveA[0].Between(paveB[0], paveB[3]) && paveA[4].Between(paveB[1], paveB[4]) && paveA[2].Between(paveB[2], paveB[5]) ||
                paveA[3].Between(paveB[0], paveB[3]) && paveA[4].Between(paveB[1], paveB[4]) && paveA[2].Between(paveB[2], paveB[5]) ||
                paveA[0].Between(paveB[0], paveB[3]) && paveA[1].Between(paveB[1], paveB[4]) && paveA[5].Between(paveB[2], paveB[5]) ||
                paveA[3].Between(paveB[0], paveB[3]) && paveA[1].Between(paveB[1], paveB[4]) && paveA[5].Between(paveB[2], paveB[5]) ||
                paveA[0].Between(paveB[0], paveB[3]) && paveA[4].Between(paveB[1], paveB[4]) && paveA[5].Between(paveB[2], paveB[5]) ||
                paveA[3].Between(paveB[0], paveB[3]) && paveA[4].Between(paveB[1], paveB[4]) && paveA[5].Between(paveB[2], paveB[5]) ||
                paveB[0].Between(paveA[0], paveA[3]) && paveB[1].Between(paveA[1], paveA[4]) && paveB[2].Between(paveA[2], paveA[5]) || // 2è pavé
                paveB[3].Between(paveA[0], paveA[3]) && paveB[1].Between(paveA[1], paveA[4]) && paveB[2].Between(paveA[2], paveA[5]) ||
                paveB[0].Between(paveA[0], paveA[3]) && paveB[4].Between(paveA[1], paveA[4]) && paveB[2].Between(paveA[2], paveA[5]) ||
                paveB[3].Between(paveA[0], paveA[3]) && paveB[4].Between(paveA[1], paveA[4]) && paveB[2].Between(paveA[2], paveA[5]) ||
                paveB[0].Between(paveA[0], paveA[3]) && paveB[1].Between(paveA[1], paveA[4]) && paveB[5].Between(paveA[2], paveA[5]) ||
                paveB[3].Between(paveA[0], paveA[3]) && paveB[1].Between(paveA[1], paveA[4]) && paveB[5].Between(paveA[2], paveA[5]) ||
                paveB[0].Between(paveA[0], paveA[3]) && paveB[4].Between(paveA[1], paveA[4]) && paveB[5].Between(paveA[2], paveA[5]) ||
                paveB[3].Between(paveA[0], paveA[3]) && paveB[4].Between(paveA[1], paveA[4]) && paveB[5].Between(paveA[2], paveA[5]))
                Console.WriteLine("Collision");
            else
                Console.WriteLine("Pas de collision");
        }
    }

    public static class ExtensionExo3
    {
        public static bool Between(this int obj, int bInf, int bSup)
        {
            return obj > bInf && obj < bSup;
        }
    }
}
