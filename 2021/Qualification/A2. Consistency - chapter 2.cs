using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerCup._2021.Qualification
{
    public class ConsistencyC2
    {
        public ConsistencyC2()
        {
            int T = int.Parse(Console.ReadLine());
            for (int nbBirthday = 1; nbBirthday <= T; ++nbBirthday)
            {
                string word = Console.ReadLine();
                int K = int.Parse(Console.ReadLine());
                var availReplacements = new Dictionary<char, string>();
                for (int i = 0; i < K; ++i)
                {
                    string line = Console.ReadLine();
                    if (!availReplacements.ContainsKey(line[0]))
                        availReplacements.Add(line[0], line[1].ToString());
                    else
                        availReplacements[line[0]] += line[1];
                }

                // Déjà bon, on affiche le résultat et on poursuit le traitement
                if (IsConsistent(word))
                {
                    Console.WriteLine($"Case #{nbBirthday}: 0");
                    continue;
                }

                // Calcul pour chaque lettre du coût nécessaire pour atteindre toutes les autres lettres possibles
                var distances = new Dictionary<char, List<CharDist>>();
                foreach (var k in availReplacements.Keys)
                {
                    distances.Add(k, new List<CharDist>());
                    var queue = new Queue<CharDist>();
                    queue.Enqueue(new CharDist { Char = k, Distance = 0 });
                    while (queue.Any())
                    {
                        var c = queue.Dequeue();
                        if (!availReplacements.ContainsKey(c.Char))
                            continue;
                        foreach (var v in availReplacements[c.Char])
                        {
                            if (k != v && !distances[k].Any(a => a.Char == v))
                            {
                                var cd = new CharDist { Char = v, Distance = c.Distance + 1 };
                                queue.Enqueue(cd);
                                distances[k].Add(cd);
                            }
                        }
                    }
                }

                // Recherche des lettres candidates
                var candidates = new List<char>();
                var p = distances.First(w => word.Contains(w.Key));
                candidates.Add(p.Key);
                foreach (var q in p.Value)
                    candidates.Add(q.Char);
                foreach (var cd in distances.Where(w => word.Contains(w.Key)).Skip(1))
                {
                    foreach (var tr in candidates.Where(w => !cd.Value.Select(s => s.Char).Contains(w)).ToList())
                        if (tr != cd.Key)
                            candidates.Remove(tr);
                }

                // Aucun candidat, on affiche le résultat et on poursuit le traitement
                if (!candidates.Any())
                {
                    Console.WriteLine($"Case #{nbBirthday}: -1");
                    continue;
                }

                // Calcul du coût pour le mot courant des remplacements pour toutes les lettres candidates
                var candidatesCost = new int[candidates.Count];
                foreach (var c in word)
                {
                    for (int i = 0; i < candidates.Count; ++i)
                    {
                        if (c == candidates[i] || candidatesCost[i] == int.MaxValue)
                            continue;
                        if (!distances.ContainsKey(c))
                            candidatesCost[i] = int.MaxValue;
                        else
                            candidatesCost[i] += distances[c].Single(s => s.Char == candidates[i]).Distance;
                    }
                }

                // Choix du coût minimum parmi les candidats
                var result = candidatesCost.Min();
                Console.WriteLine($"Case #{nbBirthday}: {(result == int.MaxValue ? -1 : result)}");
            }
        }

        private bool IsConsistent(string str) => str.All(a => a == str[0]);

        [DebuggerDisplay("Char: {Char}, Distance: {Distance}")]
        private struct CharDist
        {
            public char Char { get; set; }
            public int Distance { get; set; }
        }
    }
}
