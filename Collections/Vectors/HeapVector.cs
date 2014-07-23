using System;

using WG.Collections.Nodes;

namespace WG.Collections.Vectors
{
    /// <summary>
    /// A vector used in a heap.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored in the heap nodes.</typeparam>
    public class HeapVector<DataType> : DynamicVector<HeapNode<DataType>>
    {
        /// <summary>
        /// Creates an instance of a heap vector.
        /// </summary>
        public HeapVector()
            : base()
        { }

        /// <summary>
        /// Creates an instance of a HeapVector.
        /// </summary>
        /// <param name="nodes">The nodes that will make up the vector.</param>
        public HeapVector(HeapNode<DataType>[] nodes)
            : base(nodes)
        { }

        /// <summary>
        /// Set the first node in the vector to the given vector.
        /// </summary>
        /// <param name="first">The node to put first.</param>
        public void SetFirst(HeapNode<DataType> first)
        {
            this.Set(0, first);
        }

        /// <summary>
        /// Gets the first node in the vector.
        /// </summary>
        /// <returns>The first node in the vector.</returns>
        public HeapNode<DataType> GetFirst()
        {
            HeapNode<DataType> first = this.Get(0);

            return first;
        }

        /// <summary>
        /// Removes the last node in the vector.
        /// </summary>
        /// <returns>The node that was removed.</returns>
        public HeapNode<DataType> RemoveLast()
        {
            int lastIndex = this.Count - 1;

            HeapNode<DataType> lastNode = base.Remove(lastIndex);

            return lastNode;
        }

        /// <summary>
        /// Gets the last node in the vector.
        /// </summary>
        /// <returns>The last node in the vector.</returns>
        public HeapNode<DataType> GetLast()
        {
            int lastIndex = this.Count - 1;

            HeapNode<DataType> lastNode = this.Get(lastIndex);

            return lastNode;
        }
    }
}
