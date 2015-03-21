using System;

namespace WG.Collections.Nodes
{
    /// <summary>
    /// A node.
    /// </summary>
    /// <typeparam name="DataType">The data type of the element that is going to be stored in the node.</typeparam>
    public class Node<DataType>
    {
        /// <summary>
        /// The stored element.
        /// </summary>
        private DataType element;

        /// <summary>
        /// Accessor to the stored element.
        /// </summary>
        public virtual DataType Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        /// <summary>
        /// Creates an instance of a Node.
        /// </summary>
        public Node()
        {
            this.Element = default(DataType);
        }

        /// <summary>
        /// Creates an instance of a node.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        public Node(DataType element)
        {
            this.Element = element;
        }

        /// <summary>
        /// Gets the string represenation of the node.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string representation = this.Element.ToString();

            return representation;
        }
    }
}
