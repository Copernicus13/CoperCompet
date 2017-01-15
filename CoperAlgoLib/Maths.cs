using System.Collections.Generic;

namespace CoperAlgoLib
{
    public static class Maths
    {
        public static IEnumerable<int> GetFactors(int x)
        {
            for (int factor = 1; factor * factor <= x; ++factor)
                if (x % factor == 0)
                {
                    yield return factor;
                    if (factor * factor != x)
                        yield return x / factor;
                }
        }
    }
}
