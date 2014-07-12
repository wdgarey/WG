using System;

using WG.Collections.Nodes;

namespace WG.Collections.Linked
{
    /// <summary>
    /// A queue of elements.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored in the queue.</typeparam>
    public class Queue<DataType> : Linked<DataType>
    {
        /// <summary>
        /// Creates an instance of a Queue.
        /// </summary>
        public Queue()
            : base()
        { }

        /// <summary>
        /// Adds am element to the back of the queue.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public virtual void Enqueue(DataType element)
        {
            LinkedNode<DataType> newNode = new LinkedNode<DataType>(element);

            this.AddToFront(newNode);
        }

        /// <summary>
        /// Gets and removes the element at the front of the queue.
        /// </summary>
        /// <param name="element">The element that was removed from the front of the queue.</param>
        /// <returns>True, if there was an element at the front of the queue.</returns>
        public virtual bool Dequeue(out DataType element)
        {
            bool success = false;
            element = default(DataType);
            LinkedNode<DataType> last = this.RemoveLast();

            if (last != null)
            {
                success = true;

                element = last.Element;
            }

            return success;
        }

        /// <summary>
        /// Gets the element at the front of the queue.
        /// </summary>
        /// <param name="element">The element at the front of the queue.</param>
        /// <returns>True, if there is an element at the front of the queue.</returns>
        public virtual bool Peek(out DataType element)
        {
            bool success = false;
            element = default(DataType);
            LinkedNode<DataType> last = this.GetLast();

            if (last != null)
            {
                success = true;

                element = last.Element;
            }

            return success;
        }
    }
}
