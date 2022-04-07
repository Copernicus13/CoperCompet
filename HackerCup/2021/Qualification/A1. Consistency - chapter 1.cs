using System;
using System.Linq;

namespace HackerCup._2021.Qualification
{
    public class ConsistencyC1
    {
        public ConsistencyC1()
        {
            int T = int.Parse(Console.ReadLine());
            for (int nbBirthday = 1; nbBirthday <= T; ++nbBirthday)
            {
                string line = Console.ReadLine();
                int nbConsonants = line.Count(c => !IsVowel(c));
                int nbVowels = line.Count(c => IsVowel(c));
                var groupSimilarLetters = line
                    .GroupBy(k => k, (a, b) => new { Char = a, Count = b.Count(), IsVowel = IsVowel(a) });
                var maxSimilarConsonants = groupSimilarLetters
                    .Where(w => !w.IsVowel)
                    .DefaultIfEmpty(new { Char = default(char), Count = 0, IsVowel = default(bool) })
                    .Max(m => m.Count);
                var maxSimilarVowels = groupSimilarLetters
                    .Where(w => w.IsVowel)
                    .DefaultIfEmpty(new { Char = default(char), Count = 0, IsVowel = default(bool) })
                    .Max(m => m.Count);

                Console.WriteLine($"Case #{nbBirthday}: " +
                    Math.Min(2 * (nbConsonants - maxSimilarConsonants) + nbVowels,
                             2 * (nbVowels - maxSimilarVowels) + nbConsonants));
            }
        }

        private static bool IsVowel(char c) => "AEIOU".Contains(c);
    }
}
