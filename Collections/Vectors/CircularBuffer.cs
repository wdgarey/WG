using System;

using WG.Collections.Nodes;

namespace WG.Collections.Vectors
{
    /// <summary>
    /// A circular collection of elements.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored in the buffer.</typeparam>
    public class CircularBuffer<DataType> : Collection
    {
        /// <summary>
        /// The index of the next free space in the buffer.
        /// </summary>
        private int next;

        /// <summary>
        /// The index of the first element in the buffer.
        /// </summary>
        private int first;

        /// <summary>
        /// The array of elements.
        /// </summary>
        private DataType[] elements;

        /// <summary>
        /// Accessor the next free space in the buffer.
        /// </summary>
        protected virtual int Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        /// <summary>
        /// Accessor to the index of the first element in the buffer.
        /// </summary>
        protected virtual int First
        {
            get { return this.first; }
            set { this.first = value; }
        }

        /// <summary>
        /// Accessor to the array of elements.
        /// </summary>
        protected virtual DataType[] Elements
        {
            get { return this.elements; }
            set { this.elements = value; }
        }

        /// <summary>
        /// Accessor to the size of the Vector.
        /// </summary>
        public virtual int Size
        {
            get { return this.Elements.Length; }
        }

        /// <summary>
        /// Creates an instance of a CircularBuffer.
        /// </summary>
        /// <param name="size">The capacity of the buffer.</param>
        public CircularBuffer(int size)
            : base()
        {
            this.Next = 0;
            this.First = 0;
            this.Elements = new DataType[size];
        }

        /// <summary>
        /// Increments the index that points to the first element in the buffer.
        /// </summary>
        protected virtual void IncrementFirst()
        {
            int size = this.Size;
            int first = this.First;

            first = (first + 1) % size;

            this.First = first;
        }

        /// <summary>
        /// Increments the index of the next free space in the buffer.
        /// </summary>
        protected virtual void IncrementNext()
        {
            int size = this.Size;
            int next = this.Next;

            next = (next + 1) % size;

            this.Next = next;
        }

        /// <summary>
        /// Indicates whether or not the buffer is full.
        /// </summary>
        /// <returns>True, if the buffer is full.</returns>
        public virtual bool IsFull()
        {
            int size = this.Size;
            int count = this.Count;

            bool isFull = (count == size);

            return isFull;
        }

        /// <summary>
        /// Empties the buffer.
        /// </summary>
        public virtual void Empty()
        {
            DataType[] elements = this.Elements;

            for (int index = 0; index < elements.Length; index++)
            {
                elements[index] = default(DataType);
            }

            this.Next = 0;
            this.First = 0;
            this.Count = 0;
        }

        /// <summary>
        /// Tries to add an element to the buffer.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns>True if the element was added, or false if the buffer is full and the element was NOT added.</returns>
        public virtual bool TryAdd(DataType element)
        {
            bool notFull = !(this.IsFull());

            if (notFull)
            {
                int next = this.Next;
                DataType[] elements = this.Elements;

                elements[next] = element;

                this.IncrementNext();
                this.IncrementCount();
            }

            return notFull;
        }

        /// <summary>
        /// Tries to take the first element from the buffer.
        /// </summary>
        /// <param name="element">The first element in the buffer.</param>
        /// <returns>True, if the first element was removed, or false if the buffer was empty and the element was NOT removed.</returns>
        public virtual bool TryTake(out DataType element)
        {
            element = default(DataType);
            bool notEmpty = !(this.IsEmpty());

            if (notEmpty)
            {
                int first = this.First;
                DataType[] elements = this.Elements;

                element = elements[first];
                
                elements[first]=  default(DataType);

                this.IncrementFirst();
                this.DecrementCount();
            }

            return notEmpty;
        }
    }
}
