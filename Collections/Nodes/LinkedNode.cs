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
            this.Next = null;
            this.Previous = null;
        }

        /// <summary>
        /// Creates an instance of a LinkedNode.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        public LinkedNode(DataType element)
            : base(element)
        {
            this.Next = null;
            this.Previous = null;
        }

        /// <summary>
        /// Indiciates whether or not there is a node next in the connection.
        /// </summary>
        /// <returns>True, if there is a node next in the connection.</returns>
        public virtual bool HasNext()
        {
            LinkedNode<DataType> next = this.Next;

            bool hasNext = (next != null);

            return hasNext;
        }

        /// <summary>
        /// Indicates whether or not there is a node previous in the connection.
        /// </summary>
        /// <returns>True, if there is a node previous in the connection.</returns>
        public virtual bool HasPrevious()
        {
            LinkedNode<DataType> previous = this.Previous;

            bool hasPrevious = (previous != null);

            return hasPrevious;
        }

        /// <summary>
        /// Sets the next node to the given node (assumes the given node has no links).
        /// </summary>
        /// <param name="node">The given node.</param>
        public virtual void SetNext(LinkedNode<DataType> node)
        {
            if (node != null)
            {
                LinkedNode<DataType> myNext = this.Next;

                this.Next = node;
                node.Next = myNext;
                node.Previous = this;

                if (myNext != null)
                {
                    myNext.Previous = node;
                }
            }
        }


        /// <summary>
        /// Sets the previous node to the given node (assumes the given node has no links).
        /// </summary>
        /// <param name="node">The given node.</param>
        public virtual void SetPrevious(LinkedNode<DataType> node)
        {
            if (node != null)
            {
                LinkedNode<DataType> myPrev = this.Previous;

                this.Previous = node;
                node.Previous = myPrev;
                node.Next = this;

                if (myPrev != null)
                {
                    myPrev.Next = node;
                }
            }
        }

        /// <summary>
        /// Removes the next node in the link.
        /// </summary>
        public virtual void RemoveNext()
        {
            if(this.HasNext())
            {
                LinkedNode<DataType> next = this.Next;

                this.Next = next.Next;
                this.Next.Previous = this;

                next.ClearAll();
            }
        }

        /// <summary>
        /// Removes the previous node in the link.
        /// </summary>
        public virtual void RemovePrevious()
        {
            if(this.HasPrevious())
            {
                LinkedNode<DataType> previous = this.Previous;

                this.Previous = previous.Previous;
                this.Previous.Next = this;

                previous.ClearAll();
            }
        }

        /// <summary>
        /// Clears the next node in the link.
        /// </summary>
        public virtual void ClearNext()
        {
            this.Next = null;
        }

        /// <summary>
        /// Clears the previous node in the link.
        /// </summary>
        public virtual void ClearPrevious()
        {
            this.Previous = null;
        }

        /// <summary>
        /// Clears the next and previous links.
        /// </summary>
        public virtual void ClearAll()
        {
            this.ClearNext();
            this.ClearPrevious();
        }
    }
}
