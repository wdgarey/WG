using System;

using WG.Collections.Nodes;

namespace WG.Collections.Linked
{
    /// <summary>
    /// A stack of elements.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that will be stored.</typeparam>
    public class Stack<DataType> : Linked<DataType>
    {
        /// <summary>
        /// Creates an instance of a Stack.
        /// </summary>
        public Stack()
            : base()
        { }

        /// <summary>
        /// Adds an element to the top of the stack.
        /// </summary>
        /// <param name="element">The element to add to the top of the stack.</param>
        public void Push(DataType element)
        {
            LinkedNode<DataType> newNode = new LinkedNode<DataType>(element);

            this.AddToFront(newNode);
        }

        /// <summary>
        /// Gets and removes the element at the top of the stack.
        /// </summary>
        /// <param name="element">The element that was removed from the top of the stack.</param>
        /// <returns>True, if there was an element at the top of the stack.</returns>
        public bool Pop(out DataType element)
        {
            bool success = false;
            element = default(DataType);
            LinkedNode<DataType> first = this.RemoveFirst();

            if (first != null)
            {
                success = true;
                element = first.Element;
            }

            return success;
        }

        /// <summary>
        /// Gets the element at the top of the stack.
        /// </summary>
        /// <param name="element">The element at the top of the stack.</param>
        /// <returns>True, if there was an element a the top of the stack.</returns>
        public virtual bool Peek(out DataType element)
        {
            bool success = false;
            element = default(DataType);
            LinkedNode<DataType> first = this.GetFirst();

            if (first != null)
            {
                success = true;

                element = first.Element;
            }

            return success;
        }
    }
}
