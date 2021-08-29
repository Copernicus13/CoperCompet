using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CoperAlgoLib.Data;

namespace HackerCup._2021.Qualification
{
    public class GoldMineC1
    {
        public GoldMineC1()
        {
            int T = int.Parse(Console.ReadLine());
            for (int nbMine = 1; nbMine <= T; ++nbMine)
            {
                int N = int.Parse(Console.ReadLine());
                List<int> ores = new List<int>();
                string line = Console.ReadLine();
                ores.AddRange(line.Split(' ').Select(s => int.Parse(s)));

                var adjMtx = GetAdjacencyMatrix(N);

                var treeList = ConstructTreeList(N, ores, adjMtx);

                // Trouver 2 branches distinctes qui partent de la racine et qui maximise le résultat
                var query = treeList
                    .Where(w => w.IsLeaf)
                    .GroupBy(
                        k => GetNextRoot(k),
                        s => s,
                        (a, b) => new { NodeFollowingRoot = a, AllLeafs = b })
                    .ToList();

                if (query.Count < 2)
                    Console.WriteLine($"Case #{nbMine}: {query[0].AllLeafs.Max(m => m.ValuesBottomAggregate)}");
                else
                {
                    var result = query
                        .Select(s => s.AllLeafs.Max(m => m.ValuesBottomAggregate))
                        .OrderByDescending(o => o)
                        .Take(2)
                        .Sum();
                    Console.WriteLine($"Case #{nbMine}: {result - treeList[0].Value}");
                }
            }
        }

        private static bool[,] GetAdjacencyMatrix(int N)
        {
            bool[,] adjMtx = new bool[N, N];
            for (int i = 0; i < N - 1; ++i)
            {
                string line = Console.ReadLine();
                var c1 = int.Parse(line.Split(' ')[0]) - 1;
                var c2 = int.Parse(line.Split(' ')[1]) - 1;
                adjMtx[c1, c2] = adjMtx[c2, c1] = true;
            }
            return adjMtx;
        }

        private static Caves[] ConstructTreeList(int N, List<int> ores, bool[,] adjMtx)
        {
            var listNodes = new Caves[N];
            var queue = new Queue<int>();
            queue.Enqueue(0);
            listNodes[0] = new Caves
            {
                Id = 1,
                Value = ores[0],
                ValuesBottomAggregate = ores[0]
            };
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();
                for (int idx = 0; idx < N; ++idx)
                {
                    if (adjMtx[idx, currentNode] && listNodes[idx] == null)
                    {
                        listNodes[idx] = new Caves
                        {
                            Id = idx + 1,
                            Value = ores[idx],
                            ValuesBottomAggregate = ores[idx] + listNodes[currentNode].ValuesBottomAggregate,
                            Father = listNodes[currentNode]
                        };
                        listNodes[currentNode].Childrens.Add(listNodes[idx]);
                        queue.Enqueue(idx);
                    }
                }
            }
            return listNodes;
        }

        private static Caves GetNextRoot(Caves k)
        {
            if (k.IsRoot)
                return k;
            while (!k.Father.IsRoot)
                k = k.Father;
            return k;
        }

        [DebuggerDisplay("Cave #{Id}, NbDirectChilds = {Childrens.Count}")]
        private class Caves
        {
            public Caves()
            {
                Childrens = new List<Caves>();
            }

            public Caves Father { get; set; }
            public List<Caves> Childrens { get; }

            public int Value { get; set; }
            public int ValuesBottomAggregate { get; set; }

            public bool IsRoot => Father == null;
            public bool IsLeaf => !Childrens.Any();

            public int Id { get; set; }
        }
    }
}
