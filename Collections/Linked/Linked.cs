using System;

using WG.Collections.Nodes;

namespace WG.Collections.Linked
{
    /// <summary>
    /// A collection of linked elements.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored in the collection.</typeparam>
    public abstract class Linked<DataType> : Collection
    {
        /// <summary>
        /// The sentinel node at the front of the collection.
        /// </summary>
        private LinkedNode<DataType> front;

        /// <summary>
        /// The sentinel node at the back of the collection.
        /// </summary>
        private LinkedNode<DataType> back;

        /// <summary>
        /// Accessor to the sentinel node at the front of the collection.
        /// </summary>
        protected virtual LinkedNode<DataType> Front
        {
            get { return this.front; }
            set { this.front = value; }
        }

        /// <summary>
        /// Accessor to the sentinel node at the back of the collection.
        /// </summary>
        protected virtual LinkedNode<DataType> Back
        {
            get { return this.back; }
            set { this.back = value; }
        }

        /// <summary>
        /// Creates an instance of a Stack.
        /// </summary>
        public Linked()
            : base()
        {
            LinkedNode<DataType> back = new LinkedNode<DataType>();
            LinkedNode<DataType> front = new LinkedNode<DataType>();

            back.Next = front;
            front.Previous = back;

            this.Back = back;
            this.Front = front;
        }

        /// <summary>
        /// Indicates wether or not the linked collection is empty.
        /// </summary>
        /// <returns>True, if the collection is empty.</returns>
        public override bool IsEmpty()
        {
            LinkedNode<DataType> back = this.Back;
            LinkedNode<DataType> front = this.Front;

            bool isEmpty = (back.Next == front && front.Previous == back);

            return isEmpty;
        }

        /// <summary>
        /// Adds a node to the front of the collection.
        /// </summary>
        /// <param name="node">The node to add to the front of the collection.</param>
        protected virtual void AddToFront(LinkedNode<DataType> node)
        {
            LinkedNode<DataType> front = this.Front;

            front.Previous.Next = node;
            node.Previous = front.Previous;
            front.Previous = node;
            node.Next = front;

            this.IncrementCount();
        }

        /// <summary>
        /// Adds a node to the back of the collection.
        /// </summary>
        /// <param name="node">The node to add to the back of the collection.</param>
        protected virtual void AddToBack(LinkedNode<DataType> node)
        {
            LinkedNode<DataType> back = this.Back;

            back.Next.Previous = node;
            node.Next = back.Next;
            back.Next = node;
            node.Previous = back;

            this.IncrementCount();
        }

        /// <summary>
        /// Inserts a node into the collection at the given index.
        /// </summary>
        /// <param name="index">The index to insert the node at.</param>
        /// <param name="node">The node to insert into the collection.</param>
        /// <returns>True, if the node was inserted successfully.</returns>
        protected virtual bool Insert(int index, LinkedNode<DataType> node)
        {
            bool valid = false;
            LinkedNode<DataType> front = this.Front;
            LinkedNode<DataType> back = this.Back;
            LinkedNode<DataType> temp = back.Next;
            int position = 0;
            while (temp != front && !valid)
            {
                if (position == index)
                {
                    valid = true;

                    node.Next = temp;
                    node.Previous = temp.Previous;
                    temp.Previous.Next = node;
                    temp.Previous = node;

                    this.IncrementCount();
                }

                temp = temp.Next;
                position++;
            }

            return valid;
        }

        /// <summary>
        /// Gets the first node in the collection.
        /// </summary>
        /// <returns>The first node in the collection; or null if the collection is empty.</returns>
        protected virtual LinkedNode<DataType> GetFirst()
        {   
            LinkedNode<DataType> first = null;

            if (!this.IsEmpty())
            {
                LinkedNode<DataType> front = this.Front;
                first = front.Previous;
            }

            return first;
        }

        /// <summary>
        /// Gets the last node in the collection.
        /// </summary>
        /// <returns>The last node in the collection; or null if the collection is empty.</returns>
        protected virtual LinkedNode<DataType> GetLast()
        {   
            LinkedNode<DataType> last = null;

            if (!this.IsEmpty())
            {
                LinkedNode<DataType> back = this.Back;
                last = back.Next;
            }

            return last;
        }

        /// <summary>
        /// Gets a node at the given index.
        /// </summary>
        /// <param name="index">The node at the given index.</param>
        /// <returns>The node at the given index; or null if a node does not exist at the given index.</returns>
        protected virtual LinkedNode<DataType> Get(int index)
        {
            LinkedNode<DataType> node = null;
            LinkedNode<DataType> front = this.Front;
            LinkedNode<DataType> back = this.Back;
            LinkedNode<DataType> temp = back.Next;

            int position = 0;
            while (temp != front && node == null)
            {
                if (position == index)
                {
                    node = temp;
                }

                temp = temp.Next;
                position++;
            }

            return node;
        }

        /// <summary>
        /// Removes and returns the first node in the collection.
        /// </summary>
        /// <returns>The first node in the collection; or null if the collection is empty.</returns>
        protected virtual LinkedNode<DataType> RemoveFirst()
        {
            LinkedNode<DataType> first = null;

            if (!this.IsEmpty())
            {
                LinkedNode<DataType> front = this.Front;
                first = front.Previous;

                front.Previous = first.Previous;
                first.Previous.Next = front;

                first.Next = null;
                first.Previous = null;

                this.DecrementCount();
            }

            return first;
        }

        /// <summary>
        /// Removes and returns the last node in the collection.
        /// </summary>
        /// <returns>The last node in the collection; or null if the collection is empty.</returns>
        protected virtual LinkedNode<DataType> RemoveLast()
        {
            LinkedNode<DataType> last = null;

            if (!this.IsEmpty())
            {
                LinkedNode<DataType> back = this.Back;
                last = back.Next;

                back.Next = last.Next;
                last.Next.Previous = back;

                last.Next = null;
                last.Previous = null;

                this.DecrementCount();
            }

            return last;
        }

        /// <summary>
        /// Removes the node containing the given element.
        /// </summary>
        /// <param name="element">The element of the node.</param>
        /// <returns>The node that was removed; or null if the element was not found in any of the nodes.</returns>
        protected LinkedNode<DataType> Remove(DataType element)
        {
            LinkedNode<DataType> node = null;
            LinkedNode<DataType> front = this.Front;
            LinkedNode<DataType> back = this.Back;
            LinkedNode<DataType> temp = back.Next;

            while (temp != front && node == null)
            {
                if (temp.Element.Equals(element))
                {
                    node = temp;

                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;

                    node.Next = null;
                    node.Previous = null;

                    this.DecrementCount();
                }

                temp = temp.Next;
            }

            return node;
        }

        /// <summary>
        /// Removes the node at the given index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The node that was removed; or null if no node is at the given index.</returns>
        protected LinkedNode<DataType> Remove(int index)
        {
            LinkedNode<DataType> node = null;
            LinkedNode<DataType> front = this.Front;
            LinkedNode<DataType> back = this.Back;
            LinkedNode<DataType> temp = back.Next;

            int position = 0;
            while (temp != front && node == null)
            {
                if (position == index)
                {
                    node = temp;

                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;

                    node.Next = null;
                    node.Previous = null;

                    this.DecrementCount();
                }

                temp = temp.Next;
                position++;
            }

            return node;
        }

        /// <summary>
        /// Indicates whether or not the given element is contained with in the collection.
        /// </summary>
        /// <param name="element">The element to search for.</param>
        /// <returns>True, if the element is contained within the list.</returns>
        public virtual bool Contains(DataType element)
        {
            bool found = false;
            LinkedNode<DataType> front = this.Front;
            LinkedNode<DataType> back = this.Back;
            LinkedNode<DataType> temp = back.Next;

            while (temp != front && !found)
            {
                if (temp.Element.Equals(element))
                {
                    found = true;
                }

                temp = temp.Next;
            }

            return found;
        }

        /// <summary>
        /// Gets the index of the given element in the list.
        /// </summary>
        /// <param name="element">The element to get the index of.</param>
        /// <param name="index">The index of the element.</param>
        /// <returns>True, if the element was found.</returns>
        public virtual bool Find(DataType element, out int index)
        {
            index = -1;
            bool found = false;
            LinkedNode<DataType> front = this.Front;
            LinkedNode<DataType> back = this.Back;
            LinkedNode<DataType> temp = back.Next;

            int position = 0;
            while (temp != front && !found)
            {
                DataType data = temp.Element;

                if (element.Equals(data))
                {
                    found = true;
                    index = position;
                }

                temp = temp.Next;

                position++;
            }

            return found;
        }
    }
}
