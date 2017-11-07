using System.Collections.Generic;

namespace CoperAlgoLib.Data
{
    /// <remarks>
    /// For large dataset, you should consider using a LinkedList
    /// for better performance on Push and Pop operations.
    /// </remarks>
    public sealed class Deque<T> : List<T>
    {
        #region Constructors

        // Initializes a new instance of the Deque<T> class with the specified capacity.
        public Deque(int capacity)
            : base(capacity)
        {
        }

        // Initializes a new instance of the Deque<T> class with the elements from the specified collection.
        public Deque(IEnumerable<T> collection)
            : base(collection)
        {
        }

        // Initializes a new instance of the Deque<T> class.
        public Deque()
            : base()
        {
        }

        #endregion

        // Inserts a single element at the back of this deque.
        public void PushBack(T item) =>
            Add(item);

        // Inserts a single element at the front of this deque.
        public void PushFront(T item) =>
            Insert(0, item);

        // Removes and returns the last element of this deque.
        public T PopBack()
        {
            T ret = default(T);
            if (Count > 0)
            {
                ret = this[Count - 1];
                Remove(ret);
            }
            return ret;
        }

        // Removes and returns the first element of this deque.
        public T PopFront()
        {
            T ret = default(T);
            if (Count > 0)
            {
                ret = this[0];
                Remove(ret);
            }
            return ret;
        }
    }
}
