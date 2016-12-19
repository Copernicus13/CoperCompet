using System.Collections.Generic;

namespace AdventOfCode.Common.Data
{
    public static class LinkedListExtensions
    {
        public static LinkedListNode<T> CircularNext<T>(this LinkedListNode<T> node) =>
            node.Next ?? node.List.First;

        public static LinkedListNode<T> CircularPrevious<T>(this LinkedListNode<T> node) =>
            node.Previous ?? node.List.Last;
    }
}
