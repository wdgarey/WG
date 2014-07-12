using System;

namespace WG.Collections.Nodes
{
    /// <summary>
    /// A node that can be connected to other nodes.
    /// </summary>
    /// <typeparam name="DataType">The data type of the data that is going to be stored in the node.</typeparam>
    public class LinkedNode<DataType> : Node<DataType>
    {
        /// <summary>
        /// The next node in the connection.
        /// </summary>
        private LinkedNode<DataType> next;

        /// <summary>
        /// The previous node in the connection.
        /// </summary>
        private LinkedNode<DataType> previous;

        /// <summary>
        /// Accessor to the next node in the connection.
        /// </summary>
        public virtual LinkedNode<DataType> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        /// <summary>
        /// Accessor to the previous node in the connection.
        /// </summary>
        public virtual LinkedNode<DataType> Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }

        /// <summary>
        /// Creates an instance of a LinkedNode.
        /// </summary>
        public LinkedNode()
        {
            this.next = null;
            this.previous = null;
        }

        /// <summary>
        /// Creates an instance of a LinkedNode.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        public LinkedNode(DataType element)
            : base(element)
        {
            this.next = null;
        }
    }
}
