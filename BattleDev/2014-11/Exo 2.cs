using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev._2014_11
{
    public class Exo2
    {
        public Exo2()
        {
            int[,] map = new int[5, 5];

            for (int i = 0; i < 5; ++i)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 5; ++j)
                    map[i, j] = int.Parse(line.Split(' ')[j]);
            }

            int nbTirage = int.Parse(Console.ReadLine());

            IList<int> list = new List<int>();

            for (int i = 0; i < nbTirage; ++i)
                list.Add(int.Parse(Console.ReadLine()));

            for (int i = 1; i <= nbTirage; ++i)
            {
                if (IsBingo(map, list.Take(i).ToList()))
                {
                    Console.WriteLine($"OK {i}");
                    return;
                }
            }
            Console.WriteLine("NOK");
        }

        private bool IsBingo(int[,] map, IList<int> list)
        {
            for (int i = 0; i < 5; ++i)
            {
                var subMap = map.GetSubMap(i, 0, 1, 5).ToList();
                if (subMap.All(a => list.Contains(a)))
                    return true;
            }
            for (int i = 0; i < 5; ++i)
            {
                var subMap = map.GetSubMap(0, i, 5, 1).ToList();
                if (subMap.All(a => list.Contains(a)))
                    return true;
            }
            bool ok = false;
            for (int i = 0; i < 5; ++i)
            {
                if (!list.Contains(map[i, i]))
                {
                    ok = false;
                    break;
                }
                ok = true;
            }
            if (ok)
                return true;
            for (int i = 0; i < 5; ++i)
            {
                if (!list.Contains(map[i, 4 - i]))
                {
                    ok = false;
                    break;
                }
                ok = true;
            }
            if (ok)
                return true;
            return false;
        }
    }

    public static class ExtensionExo2
    {
        public static T[,] GetSubMap<T>(this T[,] map, int x, int y, int width, int height)
            where T : struct
        {
            T[,] subMap = new T[width, height];
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    subMap[i, j] = map[x + i, y + j];
            return subMap;
        }

        public static List<T> ToList<T>(this T[,] map, bool rowFirst = true)
            where T : struct
        {
            var width = map.GetLength(0);
            var height = map.GetLength(1);
            var result = new List<T>();
            if (rowFirst)
                for (int i = 0; i < width; ++i)
                    for (int j = 0; j < height; ++j)
                        result.Add(map[i, j]);
            else
                for (int j = 0; j < height; ++j)
                    for (int i = 0; i < width; ++i)
                        result.Add(map[i, j]);
            return result;
        }
    }
}
