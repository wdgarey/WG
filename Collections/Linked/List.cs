using System;
using WG.Collections.Nodes;

namespace WG.Collections.Linked
{
    /// <summary>
    /// A linked list of elements.
    /// </summary>
    /// <typeparam name="DataType">The type of the elements to be stored.</typeparam>
    public class List<DataType> : Linked<DataType>
    {
        /// <summary>
        /// Creates an instance of a LinkedList.
        /// </summary>
        public List()
            : base()
        { }

        /// <summary>
        /// Adds an element to the list.
        /// </summary>
        /// <param name="element">The element to add to the list.</param>
        public virtual void Add(DataType element)
        {
            LinkedNode<DataType> newNode = new LinkedNode<DataType>(element);

            base.AddToFront(newNode);
        }


        /// <summary>
        /// Inserts an element into the list.
        /// </summary>
        /// <param name="index">The index at which to insert the element.</param>
        /// <param name="element">The element to insert.</param>
        public virtual void Insert(int index, DataType element)
        {
            LinkedNode<DataType> newNode = new LinkedNode<DataType>(element);

            base.Insert(index, newNode);
        }

        /// <summary>
        /// Gets the element at the given index.
        /// </summary>
        /// <param name="index">The 0 based index of the element.</param>
        /// <param name="element">The element at the given index.</param>
        /// <returns>True, if an element is at the given index.</returns>
        public virtual bool Get(int index, out DataType element)
        {
            element = default(DataType);
            bool valid = false;

            LinkedNode<DataType> node = base.Get(index);

            if (node != null)
            {
                valid = true;

                element = node.Element;
            }

            return valid;
        }

        /// <summary>
        /// Removes the given element from the list.
        /// </summary>
        /// <param name="element">The element to remove from the list.</param>
        /// <returns>True, if the given element was removed successfully.</returns>
        public new bool Remove(DataType element)
        {
            bool found = false;
            LinkedNode<DataType> node = base.Remove(element);

            if (node != null)
            {
                found = true;
            }

            return found;
        }

        /// <summary>
        /// Removes the element at the given index.
        /// </summary>
        /// <param name="index">The index of the element to remove.</param>
        /// <returns>True, if the element at the given index was removed successfully.</returns>
        public virtual bool RemoveAt(int index)
        {
            bool valid = false;
            LinkedNode<DataType> node = base.Remove(index);

            if (node != null)
            {
                valid = true;
            }

            return valid;
        }
    }
}
