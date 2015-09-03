using System;
using WG.Collections.Nodes;
using WG.Collections.Interfaces;

namespace WG.Collections.Trees
{
    /// <summary>
    /// A binary search tree.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are goin to be stored in the tree.</typeparam>
    public class BinarySearchTree<DataType> : Collection where DataType : IRelatable<DataType>
    {
        /// <summary>
        /// The root of the tree.
        /// </summary>
        private BTNode<DataType> root;

        /// <summary>
        /// Accessor to the root of the tree.
        /// </summary>
        protected virtual BTNode<DataType> Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        /// <summary>
        /// Creates an instance of a BinarySearchTree.
        /// </summary>
        public BinarySearchTree()
            : base()
        {
            this.Root = null;
        }

        /// <summary>
        /// Rotates a subtree to the left.
        /// </summary>
        /// <param name="node">The root node of the subtree to rotate left.</param>
        protected void RotateLeft(BTNode<DataType> node)
        {
            BTNode<DataType> right = node.Right;

            node.Right = right.Left;
            right.Left = node;

            if (node.HasRight())
            {
                node.Right.Parent = node;
            }

            if (node.IsRight())
            {
                node.Parent.Right = right;
            }
            else if (node.IsLeft())
            {
                node.Parent.Left = right;
            }
            else
            {
                this.Root = right;
            }

            right.Parent = node.Parent;
            node.Parent = right;
        }

        /// <summary>
        /// Rotates a subtree to the right.
        /// </summary>
        /// <param name="node">The root node of the subtree to roate right.</param>
        protected void RotateRight(BTNode<DataType> node)
        {
            BTNode<DataType> left = node.Left;

            node.Left = left.Right;

            node.Left = left.Right;
            left.Right = node;

            if (node.HasLeft())
            {
                node.Left.Parent = node;
            }

            if (node.IsRight())
            {
                node.Parent.Right = left;
            }
            else if (node.IsLeft())
            {
                node.Parent.Left = left;
            }
            else
            {
                this.Root = left;
            }

            left.Parent = node.Parent;
            node.Parent = left;
        }

        /// <summary>
        /// Gets the node containing the given element.
        /// </summary>
        /// <param name="element">The given element.</param>
        /// <returns>The node that contains the given element; or null if no node contains the element.</returns>
        protected virtual BTNode<DataType> Get(DataType element)
        {
            bool found = false;
            BTNode<DataType> temp = this.Root;

            while (temp != null && !found)
            {
                DataType tempElement = temp.Element;

                if (element.IsLessThan(tempElement))
                {
                    temp = temp.Left;
                }
                else if (element.IsGreaterThan(tempElement))
                {
                    temp = temp.Right;
                }
                else if (element.IsEqualTo(tempElement))
                {
                    found = true;
                }
            }

            return temp;
        }

        /// <summary>
        /// Inserts a new node into the tree.
        /// </summary>
        /// <param name="newNode">The node to insert.</param>
        protected virtual void Insert(BTNode<DataType> newNode)
        {
            BTNode<DataType> temp = this.Root;
            DataType newElement = newNode.Element;

            if (temp == null)
            {
                this.Root = newNode;
            }

            while (temp != null)
            {
                DataType tempElement = temp.Element;
                newNode.Parent = temp;

                if (newElement.IsLessThan(tempElement))
                {
                    temp = temp.Left;

                    if (temp == null)
                    {
                        newNode.Parent.Left = newNode;
                    }
                }
                else
                {
                    temp = temp.Right;

                    if (temp == null)
                    {
                        newNode.Parent.Right = newNode;
                    }
                }
            }
        }

        /// <summary>
        /// Removes the given node from the tree.
        /// </summary>
        /// <param name="node">The node to remove from the tree.</param>
        protected virtual void Remove(BTNode<DataType> node)
        {
            if (node.HasBoth())
            {
                BTNode<DataType> predecessor = node.GetPredecessor();
                node.Element = predecessor.Element;

                this.Remove(predecessor);
            }
            else if (node.HasLeft())
            {
                node.Element = node.Left.Element;
                this.Remove(node.Left);
            }
            else if (node.HasRight())
            {
                node.Element = node.Right.Element;
                this.Remove(node.Right);
            }
            else
            {
                if (node.IsLeft())
                {
                    node.Parent.Left = null;
                }
                else if (node.IsRight())
                {
                    node.Parent.Right = null;
                }
                else
                {
                    this.Root = null;
                }
            }
        }

        /// <summary>
        /// The recursive function used to order the elements of the tree in descending order.
        /// </summary>
        /// <param name="node">The node to start sorting at.</param>
        /// <param name="index">The index to store the element at.</param>
        /// <param name="collection">The collection to store the element in.</param>
        protected virtual void GetInOrder(BTNode<DataType> node, ref int index, DataType[] collection)
        {
            if (node.HasLeft())
            {
                this.GetInOrder(node.Left, ref index, collection);
            }

            collection[index++] = node.Element;

            if (node.HasRight())
            {
                this.GetInOrder(node.Right, ref index, collection);
            }
        }

        /// <summary>
        /// Indicates whether or not the tree is empty.
        /// </summary>
        /// <returns>True, if the tree contains no elements.</returns>
        public override bool IsEmpty()
        {
            BTNode<DataType> root = this.Root;

            bool isEmpty = (root == null);

            return isEmpty;
        }

        /// <summary>
        /// Adds an element to the tree.
        /// </summary>
        /// <param name="element">The element to add to the tree.</param>
        public virtual void Enqueue(DataType element)
        {
            BTNode<DataType> node = new BTNode<DataType>();
            node.Element = element;

            this.Insert(node);

            this.IncrementCount();
        }

        /// <summary>
        /// Searches for the given element in the tree.
        /// </summary>
        /// <param name="element">The element to search for.</param>
        /// <returns>True, if the element was found.</returns>
        public virtual bool Search(DataType element)
        {
            bool found = true;
            BTNode<DataType> node = this.Get(element);

            if (node == null)
            {
                found = false;
            }

            return found;
        }

        /// <summary>
        /// Removes an element from the tree.
        /// </summary>
        /// <param name="element">The element to remove from the tree.</param>
        /// <returns>True, if the element was removed.</returns>
        public virtual bool Remove(DataType element)
        {
            bool found = false;
            BTNode<DataType> node = this.Get(element);

            if (node != null)
            {
                found = true;
                this.Remove(node);

                this.DecrementCount();
            }

            return found;
        }

        /// <summary>
        /// Gets the largest element in the tree.
        /// </summary>
        /// <param name="max">The largest element in the tree.</param>
        /// <returns>True, if there is a largest element in the tree.</returns>
        public virtual bool GetMax(out DataType max)
        {   
            bool maxExists = false;
            max = default(DataType);
            BTNode<DataType> temp = this.Root;

            if (temp != null)
            {
                maxExists = true;

                while (temp.Right != null)
                {
                    temp = temp.Right;
                }

                max = temp.Element;
            }

            return maxExists;
        }

        /// <summary>
        /// Gets the smallest element in the tree.
        /// </summary>
        /// <param name="min">The smallest element in the tree.</param>
        /// <returns>True, if there is a smallest element in the tree.</returns>
        public virtual bool GetMin(out DataType min)
        {
            bool minExists = false;
            min = default(DataType);
            BTNode<DataType> temp = this.Root;

            if (temp != null)
            {
                minExists = true;

                while (temp.Left != null)
                {
                    temp = temp.Left;
                }

                min = temp.Element;
            }

            return minExists;
        }

        /// <summary>
        /// Gets the elements of the tree and stores them in order from smallest to largest.
        /// </summary>
        /// <returns>The array of ordered elements.</returns>
        public virtual DataType[] GetInOrder()
        {
            int count = this.Count;
            DataType[] elements = new DataType[count];

            if (!this.IsEmpty())
            {
                int startIndex = 0;

                BTNode<DataType> root = this.Root;

                this.GetInOrder(root, ref startIndex, elements);
            }

            return elements;
        }

        /// <summary>
        /// Indicates whether or not there exists an element, x, such that x is greater than or equal to a,
        /// and x is less than or equal to b.
        /// </summary>
        /// <param name="a">The a element.</param>
        /// <param name="b">The b element.</param>
        /// <returns>True, if there exists an element between a and b, inclusive.</returns>
        public virtual bool Between(DataType a, DataType b)
        {
            BTNode<DataType> temp = this.Root;

            bool found = false;

            while (temp != null && !found)
            {
                if (a.IsGreaterThan(temp.Element))
                {
                    temp = temp.Right;
                }
                else if (b.IsLessThan(temp.Element))
                {
                    temp = temp.Left;
                }
                else
                {
                    found = true;
                }
            }

            return found;
        }
    }
}
