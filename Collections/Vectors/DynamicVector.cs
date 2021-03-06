﻿using System;

namespace WG.Collections.Vectors
{
    /// <summary>
    /// A vector that resizes automatically.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored in the vector.</typeparam>
    public class DynamicVector<DataType> : Vector<DataType>
    {
        /// <summary>
        /// Creates an instance of a DynamicVector.
        /// </summary>
        public DynamicVector()
            : base(0)
        { }

        /// <summary>
        /// Creates an instance of a DynamicVector.
        /// </summary>
        /// <param name="elements">The elements that will make up the dynamic vector.</param>
        public DynamicVector(DataType[] elements)
            : base(elements)
        { }

        /// <summary>
        /// Shifts all the elements past the given index one place foward, overwritting the element at the given index.
        /// </summary>
        /// <param name="index">The index to starting shifting foward at.</param>
        protected virtual void ShiftFoward(int index)
        {
            int count = this.Count;

            for (int position = index; position < count - 1; position++)
            {
                int nextPos = position + 1;

                DataType element = this.Get(nextPos);

                this.Set(position, element);
            }

            this.Shrink();
        }

        /// <summary>
        /// Shifts all elements, starting at the given index back one place.
        /// </summary>
        /// <param name="index">The index to start shifting the elements back at.</param>
        protected virtual void ShiftBack(int index)
        {
            int next = this.Count;

            this.Grow();

            for (int position = next - 1; position >= index; position--)
            {
                int nextPos = position + 1;
                DataType element = this.Get(position);
                this.Set(nextPos, element);
            }
        }

        /// <summary>
        /// Tries to shrink the vector.
        /// </summary>
        /// <returns>True, if the vector shrunk.</returns>
        protected virtual bool Shrink()
        {
            bool downSize = false;
            int size = this.Size;
            int count = this.Count - 1;
            int halfSize = size / 2;

            if (count < halfSize)
            {
                downSize = this.Resize(halfSize);
            }

            this.Count = count;

            return downSize;
        }

        /// <summary>
        /// Tries to expand the vector.
        /// </summary>
        /// <returns>True, if the vector grew.</returns>
        protected virtual bool Grow()
        {
            bool upSize = false;
            int size = this.Size;
            int count = this.Count + 1;

            if (size == 0)
            {
                upSize = this.Resize(1);
            }
            else if (count >= size)
            {
                int newSize = size * 2;
                upSize = this.Resize(newSize);
            }

            this.Count = count;

            return upSize;
        }

        /// <summary>
        /// Adds an element to the vector.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public virtual void Add(DataType element)
        {
            int next = this.Count;

            this.Grow();

            this.Set(next, element);
        }

        /// <summary>
        /// Inserts an element into the vector.
        /// </summary>
        /// <param name="index">The index to insert at.</param>
        /// <param name="element">The element to insert.</param>
        public virtual void Insert(int index, DataType element)
        {
            this.ShiftBack(index);

            this.Set(index, element);
        }

        /// <summary>
        /// Removes an element from the vector.
        /// </summary>
        /// <param name="index">The index of the element to remove.</param>
        /// <returns>The element that was removed.</returns>
        public virtual DataType Remove(int index)
        {
            DataType element = this.Get(index);

            this.ShiftFoward(index);

            return element;
        }
    }
}
