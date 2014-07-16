using System;

namespace WG.Collections.Nodes
{
    /// <summary>
    /// A binary tree node.
    /// </summary>
    /// <typeparam name="DataType">The data type of the element that is going to be stored in the node.</typeparam>
    public class BTNode<DataType> : ChildNode<DataType>
    {
        /// <summary>
        /// The left child node.
        /// </summary>
        private BTNode<DataType> left;

        /// <summary>
        /// The right child node.
        /// </summary>
        private BTNode<DataType> right;

        /// <summary>
        /// Accessor to the left child node.
        /// </summary>
        public virtual BTNode<DataType> Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        /// <summary>
        /// Accessor to the right child node.
        /// </summary>
        public virtual BTNode<DataType> Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        /// <summary>
        /// Accessor to the parent node.
        /// </summary>
        public new BTNode<DataType> Parent
        {
            get { return (base.Parent as BTNode<DataType>); }
            set { base.Parent = value; }
        }

        /// <summary>
        /// Creates an instance of a BTNode.
        /// </summary>
        public BTNode()
            : base()
        {
            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// Creates an instance of a BTNode.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        public BTNode(DataType element)
            : base(element)
        {
            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// Indicates whether or not this node is the left child of another node.
        /// </summary>
        /// <returns>True, if this node is the left child of another node.</returns>
        public virtual bool IsLeft()
        {
            bool isLeft = false;
            BTNode<DataType> parent = this.Parent;

            if (parent != null && parent.Left == this)
            {
                isLeft = true;
            }

            return isLeft;
        }

        /// <summary>
        /// Indicates whether or not this node is the right child of another node.
        /// </summary>
        /// <returns>True, if this node is the right child of another node.</returns>
        public virtual bool IsRight()
        {
            bool isRight = false;
            BTNode<DataType> parent = this.Parent;

            if (parent != null && parent.Right == this)
            {
                isRight = true;
            }

            return isRight;
        }

        /// <summary>
        /// Indicates whether or not his node has a left child.
        /// </summary>
        /// <returns>True, if this node has a left child.</returns>
        public virtual bool HasLeft()
        {
            BTNode<DataType> left = this.Left;

            bool hasLeft = (left != null);

            return hasLeft;
        }

        /// <summary>
        /// Indicates whether or not this node has a right child.
        /// </summary>
        /// <returns>True, if this node has a right child.</returns>
        public virtual bool HasRight()
        {
            BTNode<DataType> right = this.Right;

            bool hasRight = (right != null);

            return hasRight;
        }

        /// <summary>
        /// Indicates whether or not this node has both a left and right child.
        /// </summary>
        /// <returns>True, if the node has both a left and right child.</returns>
        public virtual bool HasBoth()
        {
            bool hasLeft = this.HasLeft();
            bool hasRight = this.HasRight();

            bool hasBoth = hasLeft && hasRight;

            return hasBoth;
        }

        /// <summary>
        /// Indicates whether or not this node has an uncle.
        /// </summary>
        /// <returns>True, if this node has an uncle.</returns>
        public virtual bool HasUncle()
        {
            bool hasUncle = true;

            BTNode<DataType> uncle = this.GetUncle();

            if (uncle == null)
            {
                hasUncle = false;
            }

            return hasUncle;
        }


        /// <summary>
        /// Gets the grand parent of this node.
        /// </summary>
        /// <returns>The grandparent node; or null if no grandparent exists.</returns>
        public new BTNode<DataType> GetGrandparent()
        {
            ChildNode<DataType> grandparent = base.GetGrandparent();

            return (grandparent as BTNode<DataType>);
        }


        /// <summary>
        /// Gets the uncle of this node.
        /// </summary>
        /// <returns>The uncle of this node; or null if no grandparent exists.</returns>
        public virtual BTNode<DataType> GetUncle()
        {
            BTNode<DataType> uncle = null;
            BTNode<DataType> parent = this.Parent;

            if (parent != null)
            {
                uncle = parent.GetSibling();
            }

            return uncle;
        }

        /// <summary>
        /// Gets the sibling of the node.
        /// </summary>
        /// <returns>The sibling of the node; or null if there is no parent or sibling.</returns>
        public virtual BTNode<DataType> GetSibling()
        {
            BTNode<DataType> sibling = null;
            BTNode<DataType> parent = this.Parent;

            if (this.IsLeft())
            {
                sibling = parent.Right;
            }
            else if (this.IsRight())
            {
                sibling = parent.Left;
            }

            return sibling;
        }

        /// <summary>
        /// Gets the node's successing child.
        /// </summary>
        /// <returns>The successing child; or null if th node has no children.</returns>
        public virtual BTNode<DataType> GetSuccessor()
        {
            BTNode<DataType> successor = this.Right;

            if (successor != null)
            {
                while (successor.Left != null)
                {
                    successor = successor.Left;
                }
            }

            return successor;
        }

        /// <summary>
        /// Gets the node's predecessing child.
        /// </summary>
        /// <returns>The predecessing child; or null if th node has no children.</returns>
        public virtual BTNode<DataType> GetPredecessor()
        {
            BTNode<DataType> descendant = this.Left;

            while (descendant.Right != null)
            {
                descendant = descendant.Right;
            }

            return descendant;
        }
    }
}
