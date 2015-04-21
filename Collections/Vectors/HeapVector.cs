using System;

using WG.Collections.Nodes;

namespace WG.Collections.Vectors
{
    /// <summary>
    /// A vector used in a heap.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored in the heap nodes.</typeparam>
    public class HeapVector<DataType> : DynamicVector<DataType>
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
        public HeapVector(DataType[] nodes)
            : base(nodes)
        { }

        /// <summary>
        /// Gets the first index of the heap vector.
        /// </summary>
        /// <returns>The first index.</returns>
        public virtual int GetFirstIndex()
        {
            return 0;
        }

        /// <summary>
        /// Gets the last index of the heap vector.
        /// </summary>
        /// <returns>The last index.</returns>
        public virtual int GetLastIndex()
        {
            int lastIndex = this.Count - 1;

            return lastIndex;
        }

        /// <summary>
        /// Set the first element in the vector to the given vector.
        /// </summary>
        /// <param name="first">The element to put first.</param>
        public void SetFirst(DataType first)
        {
            int firstIndex = this.GetFirstIndex();

            base.Set(0, first);
        }

        /// <summary>
        /// Gets the first node in the vector.
        /// </summary>
        /// <returns>The first node in the vector.</returns>
        public HeapNode<DataType> GetFirst()
        {
            int firstIndex = this.GetFirstIndex();
            DataType firstElem = base.Get(firstIndex);

            HeapNode<DataType> first = new HeapNode<DataType>(firstIndex, firstElem);

            return first;
        }

        /// <summary>
        /// Removes the last node in the vector.
        /// </summary>
        /// <returns>The node that was removed.</returns>
        public HeapNode<DataType> RemoveLast()
        {
            int lastIndex = this.GetLastIndex();
            DataType lastElem = base.Remove(lastIndex);

            HeapNode<DataType> lastNode = new HeapNode<DataType>(lastIndex, lastElem);

            return lastNode;
        }

        /// <summary>
        /// Gets the last node in the vector.
        /// </summary>
        /// <returns>The last node in the vector.</returns>
        public HeapNode<DataType> GetLast()
        {
            int lastIndex = this.GetLastIndex();
            DataType lastElem = base.Get(lastIndex);

            HeapNode<DataType> lastNode = new HeapNode<DataType>(lastIndex, lastElem);

            return lastNode;
        }

        /// <summary>
        /// Gets the node at the given index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The node.</returns>
        public virtual HeapNode<DataType> Get(int index)
        {
            DataType nodeElem = base.Get(index);

            HeapNode<DataType> node = new HeapNode<DataType>(index, nodeElem);

            return node;
        }

        /// <summary>
        /// Sets the node at the given index.
        /// </summary>
        /// <param name="node">The node.</param>
        public virtual void Set(HeapNode<DataType> node)
        {
            int index = node.Index;
            DataType elem = node.Element;

            base.Set(index, elem);
        }
    }
}
