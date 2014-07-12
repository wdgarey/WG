using System;

namespace WG.Collections.Nodes
{
    /// <summary>
    /// A heap node.
    /// </summary>
    /// <typeparam name="DataType">The data type of the element that is going to be stored in the node.</typeparam>
    public class HeapNode<DataType> : Node<DataType>
    {
        /// <summary>
        /// The index of the node.
        /// </summary>
        private int index;

        /// <summary>
        /// Accessor to the index.
        /// </summary>
        public virtual int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }

        /// <summary>
        /// Creates an instance of a HeapNode.
        /// </summary>
        public HeapNode()
            : base()
        {
            this.Index = 0;
        }

        /// <summary>
        /// Creates an instance of a HeapNode.
        /// </summary>
        /// <param name="index">The index of the node.</param>
        public HeapNode(int index)
            : base()
        {
            this.Index = index;
        }

        /// <summary>
        /// Creates an instance of a HeapNode.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        public HeapNode(DataType element)
            : base(element)
        {
            this.Index = 0;
        }

        /// <summary>
        /// Computes and returns the parent index of the node.
        /// </summary>
        /// <returns>The index of the parent node's computed.</returns>
        public virtual int GetParentIndex()
        {
            int myIndex = this.Index;

            int parentIndex = (myIndex - 1) / 2;

            return parentIndex;
        }
        /// <summary>
        /// Computes and returns the index of the left child node.
        /// </summary>
        /// <returns>The left child node's computed index.</returns>
        public virtual int GetLeftChildIndex()
        {
            int myIndex = this.Index;

            int leftChildIndex = (myIndex * 2) + 1;

            return leftChildIndex;
        }

        /// <summary>
        /// Computes and returns the index of the right child node.
        /// </summary>
        /// <returns>The right child node's computed index.</returns>
        public virtual int GetRightChildIndex()
        {
            int myIndex = this.Index;

            int rightChildIndex = (myIndex * 2) + 2;

            return rightChildIndex;
        }
    }
}
