using System;

using WG.Collections.Nodes;
using WG.Collections.Interfaces;

namespace WG.Collections.Trees
{
    /// <summary>
    /// Red-Black binary search tree.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored in the tree.</typeparam>
    public class RedBlackTree<DataType> : BinarySearchTree<DataType> where DataType : IRelatable<DataType>
    {
        /// <summary>
        /// Accessor to the root of the red black tree.
        /// </summary>
        protected new RBTNode<DataType> Root
        {
            get { return (base.Root as RBTNode<DataType>); }
            set { base.Root = value; }
        }

        /// <summary>
        /// Creates an instance of a RedBlackTree.
        /// </summary>
        public RedBlackTree()
            : base()
        { }


        /// <summary>
        /// Rotates a subtree to the left.
        /// </summary>
        /// <param name="node">The root node of the subtree to rotate left.</param>
        protected void RotateLeft(RBTNode<DataType> node)
        {
            RBTNode<DataType> right = node.Right;

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
        protected void RotateRight(RBTNode<DataType> node)
        {
            RBTNode<DataType> left = node.Left;

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


        protected void InsertCase1(RBTNode<DataType> newNode)
        {
            if (!newNode.HasParent())
            {
                newNode.MarkAsBlack();
            }
            else
            {
                this.InsertCase2(newNode);
            }
        }

        protected void InsertCase2(RBTNode<DataType> newNode)
        {
            if (newNode.Parent.IsRed())
            {
                this.InsertCase3(newNode);
            }
        }

        protected void InsertCase3(RBTNode<DataType> newNode)
        {
            RBTNode<DataType> uncle = newNode.GetUncle();

            if (uncle != null && uncle.IsRed())
            {
                RBTNode<DataType> grandparent = newNode.GetGrandparent();

                newNode.Parent.MarkAsBlack();
                uncle.MarkAsBlack();

                grandparent.MarkAsRed();

                this.InsertCase1(grandparent);
            }
            else
            {
                this.InsertCase4(newNode);
            }
        }

        protected void InsertCase4(RBTNode<DataType> newNode)
        {
            RBTNode<DataType> node = newNode;
            RBTNode<DataType> parent = node.Parent;

            if (node.IsRight() && parent.IsLeft())
            {
                this.RotateLeft(parent);

                node = node.Left;
            }
            else if (node.IsLeft() && parent.IsRight())
            {
                this.RotateRight(parent);

                node = node.Right;
            }

            this.InsertCase5(node);
        }

        protected void InsertCase5(RBTNode<DataType> node)
        {
            RBTNode<DataType> grandparent = node.GetGrandparent();

            node.Parent.MarkAsBlack();

            grandparent.MarkAsRed();

            if (node.IsLeft())
            {
                this.RotateRight(grandparent);
            }
            else
            {
                this.RotateLeft(grandparent);
            }
        }

        protected virtual void RemoveCase1(RBTNode<DataType> node)
        {
            throw new NotImplementedException("Have yet to implement deletion cases.");
        }

        protected virtual void Insert(RBTNode<DataType> newNode)
        {
            base.Insert(newNode);

            this.InsertCase1(newNode);
        }

        protected virtual void Remove(RBTNode<DataType> node)
        {
            base.Remove(node);

            this.RemoveCase1(node);
        }

        protected new RBTNode<DataType> Get(DataType element)
        {
            BTNode<DataType> node = base.Get(element);

            return (node as RBTNode<DataType>);
        }

        public override void Enqueue(DataType element)
        {
            RBTNode<DataType> node = new RBTNode<DataType>();
            node.Element = element;

            this.Insert(node);

            this.IncrementCount();
        }

        public override bool Remove(DataType element)
        {
            bool found = false;
            RBTNode<DataType> node = this.Get(element);

            if (node != null)
            {
                found = true;
                this.Remove(node);
            }
            return found;
        }
    }
}
