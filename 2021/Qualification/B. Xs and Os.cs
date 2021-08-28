using System;
using System.Linq;
using CoperAlgoLib.Data;

namespace HackerCup._2021.Qualification
{
    public class XsAndOs
    {
        public XsAndOs()
        {
            int T = int.Parse(Console.ReadLine());
            for (int nbGame = 1; nbGame <= T; ++nbGame)
            {
                int N = int.Parse(Console.ReadLine());
                char[,] map = new char[N, N];
                for (int x = 0; x < N; ++x)
                {
                    string line = Console.ReadLine();
                    for (int y = 0; y < N; ++y)
                        map[x, y] = line[y];
                }

                int nbMins = int.MaxValue;
                int nbWins = 0;
                // Balayage colonnes
                for (int x = 0; x < N; ++x)
                {
                    var col = map.GetColumn(x);
                    var nbEmpty = col.Count(c => c == '.');
                    if (col.Any(a => a == 'O') || nbEmpty > nbMins)
                        continue;
                    if (nbEmpty == nbMins)
                        ++nbWins;
                    else
                    {
                        nbWins = 1;
                        nbMins = nbEmpty;
                    }
                    // Cas particulier, une seule croix qui gagne horizontalement et verticalement
                    // ne doit compter que pour une victoire
                    if (nbMins == 1 &&
                        map.GetRow(col.ToList().IndexOf('.')).Count(c => c == 'X') == N - 1)
                    {
                        --nbWins;
                    }
                }
                // Balayage lignes
                for (int y = 0; y < N; ++y)
                {
                    var lig = map.GetRow(y);
                    var nbEmpty = lig.Count(c => c == '.');
                    if (lig.Any(a => a == 'O') || nbEmpty > nbMins)
                        continue;
                    if (nbEmpty == nbMins)
                        ++nbWins;
                    else
                    {
                        nbWins = 1;
                        nbMins = nbEmpty;
                    }
                }
                if (nbMins != int.MaxValue)
                    Console.WriteLine($"Case #{nbGame}: {nbMins} {nbWins}");
                else
                    Console.WriteLine($"Case #{nbGame}: Impossible");
            }
        }
    }
}
