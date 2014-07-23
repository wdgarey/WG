using System;

using WG.Collections.Nodes;

namespace WG.Collections.Vectors
{
    /// <summary>
    /// A sorted collection of elements.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements to be store in the collection.</typeparam>
    public abstract class Heap<DataType> : Collection
    {
        /// <summary>
        /// The vector of heap nodes.
        /// </summary>
        private HeapVector<DataType> nodes;

        /// <summary>
        /// Accessor to the vector of heap nodes.
        /// </summary>
        protected HeapVector<DataType> Nodes
        {
            get { return this.nodes; }
            set { this.nodes = value; }
        }

        /// <summary>
        /// Gets the number of elements in the heap.
        /// </summary>
        public override int Count
        {
            get { return this.Nodes.Count; }
        }

        /// <summary>
        /// Creates an instance of a Heap.
        /// </summary>
        public Heap()
            : base()
        {
            this.Nodes = new HeapVector<DataType>();
        }

        /// <summary>
        /// Creates an instace of a Heap.
        /// </summary>
        /// <param name="elements">The elements to put into the heap.</param>
        public Heap(DataType[] elements)
            : base()
        {
            HeapNode<DataType>[] nodes = new HeapNode<DataType>[elements.Length];

            for (int index = 0; index < elements.Length; index++)
            {
                DataType element = elements[index];
                HeapNode<DataType> newNode = new HeapNode<DataType>();

                newNode.Element = element;
                newNode.Index = index;

                nodes[index] = newNode;
            }

            this.Nodes = new HeapVector<DataType>(nodes);

            this.Heapify();
        }

        /// <summary>
        /// Creates a new heap node.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        /// <returns>The new heap node.</returns>
        protected virtual HeapNode<DataType> CreateNode(DataType element)
        {
            HeapVector<DataType> nodes = this.Nodes;
            HeapNode<DataType> newNode = new HeapNode<DataType>(element);
            newNode.Index = nodes.Count;

            return newNode;
        }

        /// <summary>
        /// Swaps the node upward until it is in the appropriate position.
        /// </summary>
        /// <param name="node">The node to swap upward.</param>
        protected virtual void SwapUpward(HeapNode<DataType> node)
        {
            bool done = false;
            HeapVector<DataType> nodes = this.Nodes;

            while (node.Index > 0 && !done)
            {
                int parentIndex = node.GetParentIndex();

                HeapNode<DataType> parent = nodes[parentIndex];

                DataType cElement = node.Element;
                DataType pElement = parent.Element;

                if (this.ShouldSwap(pElement, cElement))
                {
                    parent.Element = cElement;
                    node.Element = pElement;

                    node = parent;
                }
                else
                {
                    done = true;
                }
            }
        }

        /// <summary>
        /// Swaps the given node downward until it is in the approiate position.
        /// </summary>
        /// <param name="node">The node to swap downward.</param>
        protected virtual void SwapDownward(HeapNode<DataType> node)
        {
            bool done = false;
            HeapVector<DataType> nodes = this.Nodes;
            int leftIndex = node.GetLeftChildIndex();
            int rightIndex = node.GetRightChildIndex();

            while (leftIndex < nodes.Count && !done)
            {
                HeapNode<DataType> swapNode = node;
                HeapNode<DataType> left = nodes[leftIndex];

                if (this.ShouldSwap(swapNode.Element, left.Element))
                {
                    swapNode = left;
                }

                if (rightIndex <nodes.Count)
                {
                    HeapNode<DataType> right = nodes[rightIndex];

                    if (this.ShouldSwap(swapNode.Element, right.Element))
                    {
                        swapNode = right;
                    }
                }

                if (swapNode == node)
                {
                    done = true;
                }
                else
                {
                    DataType pElement = node.Element;
                    DataType cElement = swapNode.Element;

                    node.Element = cElement;
                    swapNode.Element = pElement;

                    node = swapNode;

                    leftIndex = node.GetLeftChildIndex();
                    rightIndex = node.GetRightChildIndex();
                }
            }
        }

        /// <summary>
        /// Sorts the current elements in the heap to ensure that it is, in-fact, a heap.
        /// </summary>
        protected virtual void Heapify()
        {
            HeapVector<DataType> nodes = this.Nodes;
            HeapNode<DataType> last = nodes.GetLast();
            int lastParentIndex = last.GetParentIndex();

            for (int index = lastParentIndex; index >= 0; index--)
            {
                HeapNode<DataType> parent = nodes[index];

                this.SwapDownward(parent);
            }
        }

        /// <summary>
        /// Indicates whether or not the heap is empty.
        /// </summary>
        /// <returns>True, if the heap contains no elements.</returns>
        public override bool IsEmpty()
        {
            HeapVector<DataType> nodes = this.Nodes;

            bool isEmpty = (nodes.Count < 1);

            return isEmpty;
        }

        /// <summary>
        /// Adds an element to the heap.
        /// </summary>
        /// <param name="element">The element to add to the heap.</param>
        public virtual void Enqueue(DataType element)
        {
            HeapVector<DataType> nodes = this.Nodes;
            HeapNode<DataType> newNode = this.CreateNode(element);

            nodes.Add(newNode);

            this.SwapUpward(newNode);
        }

        /// <summary>
        /// Removes an element from the heap.
        /// </summary>
        /// <param name="element">The element that was removed.</param>
        /// <returns>True, if an element was removed successfully; or false if the heap is empty.</returns>
        public virtual bool Dequeue(out DataType element)
        {
            bool success = false;
            element = default(DataType);
            HeapVector<DataType> nodes = this.Nodes;

            if (!this.IsEmpty())
            {
                success = true;
                HeapNode<DataType> root = nodes.GetFirst();

                element = root.Element;

                HeapNode<DataType> last = nodes.RemoveLast();

                root.Element = last.Element;

                this.SwapDownward(root);
            }

            return success;
        }

        /// <summary>
        /// Indicates whether or no the given elements should be swapped.
        /// </summary>
        /// <param name="pElement">The parent's element.</param>
        /// <param name="cElement">The child's element</param>
        /// <returns>True, if the parent element should be swapped with the child element.</returns>
        protected abstract bool ShouldSwap(DataType pElement, DataType cElement);
    }
}
