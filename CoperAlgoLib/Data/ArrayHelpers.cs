using System.Collections.Generic;
using System.Linq;

namespace CoperAlgoLib.Data
{
    public static class ArrayHelpers
    {
        public static T[,] GetSubArray<T>(this T[,] map, int x, int y, int width, int height)
        {
            var subMap = new T[height, width];
            for (int j = 0; j < height; ++j)
                for (int i = 0; i < width; ++i)
                    subMap[j, i] = map[y + j, x + i];
            return subMap;
        }

        public static T[] GetRow<T>(this T[,] map, int row)
        {
            var width = map.GetLength(1);
            var subMap = new T[width];
            for (int i = 0; i < width; ++i)
                subMap[i] = map[row, i];
            return subMap;
        }

        public static T[] GetColumn<T>(this T[,] map, int column)
        {
            var height = map.GetLength(0);
            var subMap = new T[height];
            for (int j = 0; j < height; ++j)
                subMap[j] = map[j, column];
            return subMap;
        }

        public static List<T> ToList<T>(this T[,] map, bool rowFirst = true)
        {
            var width = map.GetLength(1);
            var height = map.GetLength(0);
            var result = new List<T>();
            if (rowFirst)
                for (int j = 0; j < height; ++j)
                    result.AddRange(map.GetRow(j).ToList());
            else
                for (int i = 0; i < width; ++i)
                    result.AddRange(map.GetColumn(i).ToList());
            return result;
        }

        public static List<List<T>> ToListList<T>(this T[,] map, bool rowFirst = true)
        {
            var width = map.GetLength(1);
            var height = map.GetLength(0);
            var result = new List<List<T>>();
            if (rowFirst)
                for (int j = 0; j < height; ++j)
                    result.Add(map.GetRow(j).ToList());
            else
                for (int i = 0; i < width; ++i)
                    result.Add(map.GetColumn(i).ToList());
            return result;
        }
    }
}
