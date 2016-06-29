using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    /// <summary>
    /// A Generic implementation of a Min Heap
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> where T : IComparable
    {
        T[] data;
        /// <summary>
        /// Number of elements in the heap
        /// </summary>
        public int Count { get; protected set; }
        /// <summary>
        /// Create the heap out of an existing array.  If any of the nodes are null,
        /// don't use them.
        /// </summary>
        /// <param name="data">Array of data</param>
        public MinHeap(T[] data)
        {
            this.data = new T[data.Length];
            Count = 0;
            for (int idx = 0; idx < data.Length; idx++)
            {
                if (data[idx] != null)
                {
                    this.data[Count++] = data[idx];
                }
            }
            Heapify();
        }
        public void Heapify()
        {
            int start = Parent(data.Length - 1);

            while (start >= 0)
            {
                SiftDown(start);
                start--;
            }
        }
        /// <summary>
        /// Establish the heap property by sifting down
        /// </summary>
        /// <param name="start">start node</param>
        private void SiftDown(int start)
        {
            int root = start;

            while (Child1(root) < Count)
            {
                int child = Child1(root);
                int swap = root;

                if (data[swap].CompareTo(data[child]) > 0)
                {
                    swap = child;
                }
                child++;
                if ((child < Count) && (data[swap].CompareTo(data[child]) > 0))
                {
                    swap = child;
                }
                if (swap == root)
                    return;
                else
                {
                    Swap(root, swap);
                    root = swap;
                }
            }
        }
        /// <summary>
        /// Swap two elements of the heap
        /// </summary>
        /// <param name="root"></param>
        /// <param name="swap"></param>
        private void Swap(int root, int swap)
        {
            T temp = data[root];
            data[root] = data[swap];
            data[swap] = temp;
        }

        /// <summary>
        /// Shift the node up until it meets the heap property
        /// </summary>
        /// <param name="idx">Position of the node to shift</param>
        private void SiftUp(int idx)
        {
            int child = idx;
            while (child > 0)
            {
                int parent = Parent(child);
                if (data[parent].CompareTo(data[child]) > 0)
                {
                    Swap(parent, child);
                }
                else
                {
                    return;
                }
            }
        }
        public void Add(T item)
        {
            if (Count == data.Length)
            {
                throw new Exception("Heap is full");
            }
            data[Count] = item;
            SiftUp(Count++); 
        }
        public T Pop()
        {
            T top = data[0];
            data[0] = data[Count-- - 1];
            SiftDown(0);
            return top;
        }
        private int Child1(int idx)
        {
            return 2 * idx + 1;
        }
        private int Parent(int idx)
        {
            return (idx - 1) / 2;
        }
    }
}
