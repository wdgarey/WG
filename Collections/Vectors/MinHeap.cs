using System;

namespace WG.Collections.Vectors
{
    /// <summary>
    /// A heap that stores elements in descending order.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored in the heap.</typeparam>
    public class MinHeap<DataType> : Heap<DataType> where DataType : WG.Collections.Interfaces.IRelatable<DataType>
    {
        /// <summary>
        /// Creates an instance of a MinHeap.
        /// </summary>
        public MinHeap()
            : base()
        { }

        /// <summary>
        /// Creates an instance of a MinHeap.
        /// </summary>
        /// <param name="elements">The elements to store in the heap.</param>
        public MinHeap(DataType[] elements)
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

            if (cElement.IsLessThan(pElement))
            {
                shouldSwap = true;
            }

            return shouldSwap;
        }
    }
}
