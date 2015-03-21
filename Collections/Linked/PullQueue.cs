using System;

using WG.Collections.Nodes;

namespace WG.Collections.Linked
{
    /// <summary>
    /// A queue that allows elements to be pulled out in no particular order.
    /// </summary>
    /// <typeparam name="DataType">The data type of the data to be stored in the pull queue.</typeparam>
    public class PullQueue<DataType> : Queue<DataType>
    {
        /// <summary>
        /// Creates an instance of a pull queue.
        /// </summary>
        public PullQueue()
            : base()
        { }

        /// <summary>
        /// Pulls the given element out of the queue.
        /// </summary>
        /// <param name="element">The element to pull from the queue.</param>
        /// <returns>True, if the element was found and removed.</returns>
        public virtual bool Pull(DataType element)
        {
            bool success = false;
            LinkedNode<DataType> node = this.Remove(element);

            if(node != null)
            {
                success = true;
            }

            return success;
        }

        /// <summary>
        /// Pulls the element at the given index out of the queue.
        /// </summary>
        /// <param name="index">The index of the element to pull from the queue.</param>
        /// <param name="element">The element that was pulled from the queue.</param>
        /// <returns>True, if the element at the given index was removed.</returns>
        public virtual bool Pull(int index, out DataType element)
        {
            bool success = false;
            element = default(DataType);
            LinkedNode<DataType> node = this.Remove(index);

            if (node != null)
            {
                success = true;
                element = node.Element;
            }

            return success;
        }
    }
}
