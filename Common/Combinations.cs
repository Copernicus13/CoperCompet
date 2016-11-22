using System.Linq;

namespace AdventOfCode.Common
{
    public static class Combinations
    {
        public static T[][] FastPowerSet<T>(T[] seq)
        {
            var powerSet = new T[1 << seq.Length][];
            powerSet[0] = new T[0]; // empty set
            for (int i = 0; i < seq.Length; ++i)
            {
                var cur = seq[i];
                int count = 1 << i;
                for (int j = 0; j < count; ++j)
                {
                    var source = powerSet[j];
                    var destination = powerSet[count + j] = new T[source.Length + 1];
                    for (int q = 0; q < source.Length; ++q)
                        destination[q] = source[q];
                    destination[source.Length] = cur;
                }
            }
            return powerSet;
        }

        public static string[] FastPowerSet(string seq)
        {
            return FastPowerSet(seq.ToCharArray())
                .Select(s => new string(s))
                .ToArray();
        }

        public static T[][] GetAll<T>(T[] seq, int k)
        {
            return FastPowerSet(seq)
                .ToList()
                .Where(w => w.Length == k)
                .ToArray();
        }

        public static T[][] FastGetAll<T>(T[] seq, int rang)
        {
            var powerSet = new T[1 << seq.Length][];
            powerSet[0] = new T[0]; // empty set
            for (int i = 0; i < seq.Length; ++i)
            {
                var cur = seq[i];
                int count = 1 << i;
                for (int j = 0; j < count; ++j)
                {
                    var source = powerSet[j];
                    if (source != null && source.Length < rang)
                    {
                        var destination = powerSet[count + j] = new T[source.Length + 1];
                        for (int q = 0; q < source.Length; ++q)
                            destination[q] = source[q];
                        destination[source.Length] = cur;
                    }
                }
            }
            return powerSet;
        }
    }
}
