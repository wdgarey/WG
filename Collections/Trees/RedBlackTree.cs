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

        /// <summary>
        /// The new node doesn't have a parent so it is the root, just color it black.
        /// </summary>
        /// <param name="newNode">The newly added node.</param>
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

        /// <summary>
        /// The new node has a parent, and the parent is red.
        /// </summary>
        /// <param name="newNode">The newly added node.</param>
        protected void InsertCase2(RBTNode<DataType> newNode)
        {
            if (newNode.Parent.IsRed())
            {
                this.InsertCase3(newNode);
            }
        }

        /// <summary>
        /// If the parent is red and the parents sibling is red, then
        /// color the  grandparent red and the parent and uncle black.
        /// </summary>
        /// <param name="newNode">The new node.</param>
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

        /// <summary>
        /// If the parent is red, the uncle is black, and the node and parent
        /// are "zig-zagged" then rotate them appropriately to put them in a straight
        /// line. (Need to make sure it is a straight line here given the situation
        /// so that in the next case we can rotate the straight line into a balanced
        /// sub-tree of three.
        /// </summary>
        /// <param name="newNode">The new node.</param>
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

        /// <summary>
        /// The node and the parent are in a straight line and the parent is red,
        /// so marke the node black, the grandparent red, and finally rotate the node
        /// appropriately so that a balanced sub-tree of three is made.
        /// </summary>
        /// <param name="node">The node to consider.</param>
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

        /// <summary>
        /// If the parent of the node that was removed is black and
        /// the node is red then just color the node black. But if the
        /// parent is black and the node to remove is black we need to
        /// do more.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        protected virtual void RemoveCase1(RBTNode<DataType> node)
        {
            if (!node.HasParent() || node.Parent.IsBlack())
            {
                if (node.IsRed())
                {
                    node.MarkAsBlack();
                }
                else
                {
                    this.RemoveCase2(node);
                }
            }
        }

        /// <summary>
        /// If the node that is being removed is black and the parent is black, then
        /// we need to do more.
        /// </summary>
        /// <param name="node">The node being removed.</param>
        protected virtual void RemoveCase2(RBTNode<DataType> node)
        {
            if (node.HasParent())
            {
                this.RemoveCase3(node);
            }
        }

        /// <summary>
        /// If the node's parent is black, the node is black, and the node's
        /// sibling is red, then color the parent red, mark the sibling as black,
        /// and rotate the parent appropriately.
        /// </summary>
        /// <param name="node">The node being removed.</param>
        protected virtual void RemoveCase3(RBTNode<DataType> node)
        {
            RBTNode<DataType> sibling = node.GetSibling();

            if (sibling.IsRed())
            {
                RBTNode<DataType> parent = node.Parent;

                parent.MarkAsRed();
                sibling.MarkAsBlack();

                if (node.IsLeft())
                {
                    this.RotateLeft(parent);
                }
                else
                {
                    this.RotateRight(parent);
                }
            }

            this.RemoveCase4(node);
        }

        /// <summary>
        /// If the parent is black, the sibling is black, and the siblings children are black,
        /// then mark the sibling as red (pushing the color problem up the tree) and start with
        /// the parent. Else, if the same case applies but the parent is red then just color the
        /// sibling red and the parent black. Otherwise there is more that needs to be done.
        /// </summary>
        /// <param name="node">The node being removed.</param>
        protected virtual void RemoveCase4(RBTNode<DataType> node)
        {
            RBTNode<DataType> parent = node.Parent;
            RBTNode<DataType> sibling = node.GetSibling();

            if (parent.IsBlack() && sibling.IsBlack() && (!sibling.HasLeft() || sibling.Left.IsBlack()) && ( !sibling.HasRight() || sibling.Right.IsBlack()))
            {
                sibling.MarkAsRed();
                this.RemoveCase2(parent);
            }
            else if (parent.IsRed() && sibling.IsBlack() && (!sibling.HasLeft() || sibling.Left.IsBlack()) && (!sibling.HasRight() || sibling.Right.IsBlack()))
            {
                sibling.MarkAsRed();
                parent.MarkAsBlack();
            }
            else
            {
                this.RemoveCase5(node);
            }
        }

        /// <summary>
        /// If the sibling is black, the node is left, the siblings right child is black and the
        /// sibling's left child is red, color the sibling red and the left child black so that
        /// you have a red node and two black nodes (or vice versa) and rotate the sibling. Otherwise there is more
        /// that needs to be done.
        /// </summary>
        /// <param name="node">The node being removed.</param>
        protected virtual void RemoveCase5(RBTNode<DataType> node)
        {
            RBTNode<DataType> sibling = node.GetSibling();

            if (sibling.IsBlack())
            {
                if (node.IsLeft() && (!sibling.HasRight() || sibling.Right.IsBlack()) && (sibling.HasLeft() && sibling.Left.IsRed()))
                {
                    sibling.MarkAsRed();
                    sibling.Left.MarkAsBlack();
                    this.RotateRight(sibling);
                }
                else if (node.IsRight() && (!sibling.HasLeft() || sibling.Left.IsBlack()) && (sibling.HasRight() && sibling.Right.IsRed()))
                {
                    sibling.MarkAsRed();
                    sibling.Right.MarkAsBlack();
                    this.RotateLeft(sibling);
                }
            }

            this.RemoveCase6(node);
        }

        /// <summary>
        /// If the node is left or right and the siblings children are the same
        /// color then make the sibling teh same color as the parent and mark
        /// the parent as black. And if the node is left color the sibling's
        /// right child as black and rotate the parent left (or vice-versa).
        /// </summary>
        /// <param name="node">The node being removed.</param>
        protected virtual void RemoveCase6(RBTNode<DataType> node)
        {
            RBTNode<DataType> parent = node.Parent;
            RBTNode<DataType> sibling = node.GetSibling();

            sibling.MarkAs(parent);
            parent.MarkAsBlack();

            if (node.IsLeft())
            {
                sibling.Right.MarkAsBlack();
                this.RotateLeft(parent);
            }
            else
            {
                sibling.Left.MarkAsBlack();
                this.RotateRight(parent);
            }
        }

        /// <summary>
        /// Inserts the given node into the tree.
        /// </summary>
        /// <param name="newNode">The node to insert into the tree.</param>
        protected virtual void Insert(RBTNode<DataType> newNode)
        {
            base.Insert(newNode);

            this.InsertCase1(newNode);
        }

        /// <summary>
        /// Removes the given node from the tree.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        protected virtual void Remove(RBTNode<DataType> node)
        {
            if (node.HasBoth())
            {
                RBTNode<DataType> predecessor = node.GetPredecessor();
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
                    this.RemoveCase1(node);
                    node.Parent.Left = null;
                }
                else if (node.IsRight())
                {
                    this.RemoveCase1(node);
                    node.Parent.Right = null;
                }
                else
                {
                    this.Root = null;
                }
            }
        }

        /// <summary>
        /// Gets the node containing the given element.
        /// </summary>
        /// <param name="element">The element of the node to get.</param>
        /// <returns>The node containing the given element, or NULL if no node contains the given element.</returns>
        protected new RBTNode<DataType> Get(DataType element)
        {
            BTNode<DataType> node = base.Get(element);

            return (node as RBTNode<DataType>);
        }

        /// <summary>
        /// Adds and element to the tree.
        /// </summary>
        /// <param name="element">The element to add to the tree.</param>
        public override void Enqueue(DataType element)
        {
            RBTNode<DataType> node = new RBTNode<DataType>();
            node.Element = element;

            this.Insert(node);

            this.IncrementCount();
        }

        /// <summary>
        /// Removes an element from the tree.
        /// </summary>
        /// <param name="element">The element to remove from the tree.</param>
        /// <returns>True, if the element was found and removed.</returns>
        public override bool Remove(DataType element)
        {
            bool found = false;
            RBTNode<DataType> node = this.Get(element);

            if (node != null)
            {
                found = true;
                this.Remove(node);

                this.DecrementCount();
            }

            return found;
        }
    }
}
