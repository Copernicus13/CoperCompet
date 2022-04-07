using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam._2022.Qualification
{
    public class ChainReactions
    {
        private class NodeInfos
        {
            public int Id;
            public int? Link;
            public int Weight;
            public int? MaximizedWeight;
            public bool IsLeaf;
            public int ChildrensCount;
        }

        public ChainReactions()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                int N = int.Parse(Console.ReadLine());
                var F = new List<NodeInfos> { new NodeInfos() }; // First NodeInfos is abyss
                var notLeaves = new bool[N + 1];
                var numbers = Console.ReadLine().Split(' ');
                for (int i = 0; i < N; ++i)
                    F.Add(new NodeInfos { Id = i + 1, Weight = int.Parse(numbers[i]) });
                numbers = Console.ReadLine().Split(' ');
                for (int i = 0; i < N; ++i)
                {
                    int link = int.Parse(numbers[i]);
                    F[i + 1].Link = link;
                    ++F[link].ChildrensCount;
                    notLeaves[link] = true;
                }
                for (int i = 1; i < notLeaves.Length; ++i)
                    if (!notLeaves[i])
                        F[i].IsLeaf = true;

                Console.WriteLine($"Case #{nbCase}: {Solve(F)}");
            }
        }

        private int Solve(List<NodeInfos> nodes)
        {
            var initiators = new Queue<int>(nodes.Where(w => w.IsLeaf).Select(s => s.Id).ToList());
            while (initiators.Any())
            {
                int nb = initiators.Dequeue();
                if (nb == 0)
                    break;
                var parent = nodes[nb].Link.Value;
                if (nodes[parent].MaximizedWeight.HasValue)
                    continue;

                if (nodes[parent].ChildrensCount == 1)
                    nodes[parent].MaximizedWeight = Math.Max(nodes[nb].MaximizedWeight ?? nodes[nb].Weight, nodes[parent].Weight);
                else
                {
                    var list = nodes.Where(w => w.Link == parent && w.Id != nb).ToList();
                    if (list.All(a => a.MaximizedWeight.HasValue || a.IsLeaf))
                    {
                        list.Add(nodes[nb]);
                        nodes[parent].MaximizedWeight = GetMaxFun(list, nodes[parent].Weight);
                    }
                    else
                    {
                        initiators.Enqueue(nb);
                        continue;
                    }
                }
                initiators.Enqueue(parent);
            }
            return nodes[0].MaximizedWeight.Value;
        }

        private int? GetMaxFun(List<NodeInfos> list, int parentWeight)
        {
            int min = list.Min(m => m.MaximizedWeight ?? m.Weight);
            int result = Math.Max(min, parentWeight);
            return result + list.Sum(s => s.MaximizedWeight ?? s.Weight) - min;
        }
    }
}
