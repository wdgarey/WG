using System;

namespace WG.Collections.Vectors
{
    /// <summary>
    /// An array of elements that can change size.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that will be stored in the array.</typeparam>
    public class Vector<DataType> : Collection
    {
        /// <summary>
        /// The array of elements.
        /// </summary>
        private DataType[] elements;

        /// <summary>
        /// Accessor to the array of elements.
        /// </summary>
        protected virtual DataType[] Elements
        {
            get { return this.elements; }
            set { this.elements = value; }
        }

        /// <summary>
        /// Accessor to the array of elements.
        /// </summary>
        /// <param name="index">The index of the element.</param>
        /// <returns>The element.</returns>
        public virtual DataType this[int index]
        {
            get { return this.Get(index); }
            set { this.Set(index, value); }
        }

        /// <summary>
        /// Accessor to the size of the Vector.
        /// </summary>
        public virtual int Size
        {
            get { return this.Elements.Length; }
        }

        /// <summary>
        /// Accessor to the number of elements that can be stored in the vector.
        /// </summary>
        public override int Count
        {
            get { return this.Size; }
        }

        /// <summary>
        /// Creates an instance of a vector.
        /// </summary>
        public Vector()
        {
            this.Elements = new DataType[0];
        }

        /// <summary>
        /// Creates an instance of a Vector.
        /// </summary>
        /// <param name="initSize">The initial size of the vector.</param>
        public Vector(int initSize)
        {
            this.Elements = new DataType[initSize];
        }

        /// <summary>
        /// Gets the element at the given index.
        /// </summary>
        /// <param name="index">The given index.</param>
        /// <returns>The element at the given index.</returns>
        protected virtual DataType Get(int index)
        {
            DataType[] elements = this.Elements;

            DataType element = elements[index];

            return element;
        }

        /// <summary>
        /// Sets the element at the given index.
        /// </summary>
        /// <param name="index">The given index.</param>
        /// <param name="element">The element to store at the index.</param>
        protected virtual void Set(int index, DataType element)
        {
            DataType[] elements = this.Elements;

            elements[index] = element;
        }

        /// <summary>
        /// Resizes the vector.
        /// </summary>
        /// <param name="newSize">The new size.</param>
        /// <returns>True, if the resize was successful.</returns>
        public virtual bool Resize(int newSize)
        {
            bool success = true;

            try
            {
                int origSize = this.Size;
                DataType[] origElements = this.Elements;
                DataType[] newElements = new DataType[newSize];
                int count = origSize < newSize ? origSize : newSize;

                for (int index = 0; index < count; index++)
                {
                    newElements[index] = origElements[index];
                }

                this.Elements = newElements;
            }
            catch (OutOfMemoryException ex)
            {
                success = false;
            }

            return success;
        }
    }
}
