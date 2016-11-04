using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev._2015_03
{
    public class Exo3
    {
        public Exo3()
        {
            int nbLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < nbLine; ++i)
            {
                string line = Console.ReadLine();

                string word1 = line.Split(' ')[0];
                string word2 = line.Split(' ')[1];

                ICollection<string> factors = new List<string>();

                for (int j = 0; j < word2.Length; ++j)
                    for (int k = 0; k < word2.Length && word2.Substring(k).Length > j; ++k)
                        if (word1.Contains(word2.Substring(k, word2.Substring(k).Length - j)))
                            factors.Add(word2.Substring(k, word2.Substring(k).Length - j));

                Console.WriteLine(factors.Any() ?
                    factors.OrderByDescending(o => o.Length).ThenBy(o => o).First() :
                    "AUCUN FACTEUR");
            }
        }
    }
}
