using System;

namespace WG.Collections.Vectors
{
    /// <summary>
    /// A heap that stores elements in ascending order.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored in the heap.</typeparam>
    public class MaxHeap<DataType> : Heap<DataType> where DataType : WG.Collections.Interfaces.IRelatable<DataType>
    {
        /// <summary>
        /// Creates an instance of a MaxHeap.
        /// </summary>
        public MaxHeap()
            : base()
        { }

        /// <summary>
        /// Creates an instance of a MaxHeap.
        /// </summary>
        /// <param name="elements">The elements to store in the heap.</param>
        public MaxHeap(DataType[] elements)
            : base(elements)
        { }

        /// <summary>
        /// Indicates whether or no the given elements should be swapped.
        /// </summary>
        /// <param name="pElement">The parent's element.</param>
        /// <param name="cElement">The child's element</param>
        /// <returns>True, if the parent element should be swapped with the child element.</returns>
        protected override bool ShouldSwap(DataType pElement, DataType cElement)
        {
            bool shouldSwap = false;

            if (cElement.IsGreaterThan(pElement))
            {
                shouldSwap = true;
            }

            return shouldSwap;
        }
    }
}
