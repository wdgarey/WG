using System;

namespace WG.Collections
{
    /// <summary>
    /// A generic collection of elements.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that will be stored.</typeparam>
    public abstract class Collection
    {
        /// <summary>
        /// The number of elements in the collection.
        /// </summary>
        private int count;

        /// <summary>
        /// Accessor to the number of elements in the collection.
        /// </summary>
        public virtual int Count
        {
            get { return this.count; }
            protected set { this.count = value; }
        }

        /// <summary>
        /// Creates an instance of a collection.
        /// </summary>
        public Collection()
        {
            this.Count = 0;
        }

        /// <summary>
        /// Increases the count representing the number of elements by 1.
        /// </summary>
        protected virtual void IncrementCount()
        {
            int count = this.Count;

            count = count + 1;

            this.Count = count;
        }

        /// <summary>
        /// Decreases the count representing the number of elements by 1.
        /// </summary>
        protected virtual void DecrementCount()
        {
            int count = this.Count;

            count = count - 1;

            this.Count = count;
        }

        /// <summary>
        /// Indicates whether or no the collection is empty.
        /// </summary>
        /// <returns>True, if the collection does not contain any elements.</returns>
        public virtual bool IsEmpty()
        {
            int count = this.count;

            bool isEmpty = (count < 1);

            return isEmpty;
        }

        /// <summary>
        /// Gets the string representation of the collection.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            int count = this.Count;

            return count.ToString();
        }
    }
}
