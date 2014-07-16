using System;
using System.Text;

namespace WG.Collections.Nodes
{
    /// <summary>
    /// A red black tree node.
    /// </summary>
    /// <typeparam name="DataType">The data type of the element that is going to be stored in the node.</typeparam>
    public class RBTNode<DataType> : BTNode<DataType>
    {
        /// <summary>
        /// Indicates whether or not this node is black.
        /// </summary>
        private bool black;

        /// <summary>
        /// Accessor the indicator that indicates whether or not this node is black.
        /// </summary>
        protected bool Black
        {
            get { return this.black; }
            set { this.black = value; }
        }

        /// <summary>
        /// Accessor to the left child.
        /// </summary>
        public new RBTNode<DataType> Left
        {
            get { return (base.Left as RBTNode<DataType>); }
            set { base.Left = value; }
        }

        /// <summary>
        /// Accessor to the right child.
        /// </summary>
        public new RBTNode<DataType> Right
        {
            get { return (base.Right as RBTNode<DataType>); }
            set { base.Right = value; }
        }

        /// <summary>
        /// Accessor to the parent.
        /// </summary>
        public new RBTNode<DataType> Parent
        {
            get { return (base.Parent as RBTNode<DataType>); }
            set { base.Parent = value; }
        }

        /// <summary>
        /// Creates an instance of an RBTNode.
        /// </summary>
        public RBTNode()
            : base()
        {
            this.Black = false;
        }

        /// <summary>
        /// Creates an instance of an RBTNode.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        public RBTNode(DataType element)
            : base(element)
        {
            this.Black = false;
        }

        /// <summary>
        /// Indicates whether or not this node is red.
        /// </summary>
        /// <returns>True, if this node is red.</returns>
        public virtual bool IsRed()
        {
            bool isRed = !this.IsBlack();

            return isRed;
        }

        /// <summary>
        /// Indicates whether or not this node is black.
        /// </summary>
        /// <returns>True, if this node is black.</returns>
        public virtual bool IsBlack()
        {
            bool isBlack = this.Black;

            return isBlack;
        }

        /// <summary>
        /// Colors this node red.
        /// </summary>
        public virtual void MarkAsRed()
        {
            this.Black = false;
        }

        /// <summary>
        /// Colors this node black.
        /// </summary>
        public virtual void MarkAsBlack()
        {
            this.Black = true;
        }

        /// <summary>
        /// Colors this node the same color as the given node.
        /// </summary>
        /// <param name="node">The given node.</param>
        public virtual void MarkAs(RBTNode<DataType> node)
        {
            this.Black = node.Black;
        }

        /// <summary>
        /// Gets the grand parent of this node.
        /// </summary>
        /// <returns>The grandparent node; or null if no grandparent exists.</returns>
        public new RBTNode<DataType> GetGrandparent()
        {
            BTNode<DataType> grandparent = base.GetGrandparent();

            return (grandparent as RBTNode<DataType>);
        }

        /// <summary>
        /// Gets the uncle of this node.
        /// </summary>
        /// <returns>The uncle of this node; or null if no grandparent exists.</returns>
        public new RBTNode<DataType> GetUncle()
        {
            BTNode<DataType> uncle = base.GetUncle();

            return (uncle as RBTNode<DataType>);
        }

        /// <summary>
        /// Gets the sibling of the node.
        /// </summary>
        /// <returns>The sibling of the node; or null if there is no parent or sibling.</returns>
        public new RBTNode<DataType> GetSibling()
        {
            BTNode<DataType> sibling = base.GetSibling();

            return (sibling as RBTNode<DataType>);
        }

        /// <summary>
        /// Gets the node's successing child.
        /// </summary>
        /// <returns>The successing child; or null if th node has no children.</returns>
        public new RBTNode<DataType> GetSuccessor()
        {
            BTNode<DataType> successor = base.GetSuccessor();

            return (successor as RBTNode<DataType>);
        }

        /// <summary>
        /// Gets the node's predecessing child.
        /// </summary>
        /// <returns>The predecessing child; or null if th node has no children.</returns>
        public new RBTNode<DataType> GetPredecessor()
        {
            BTNode<DataType> descendant = base.GetPredecessor();

            return (descendant as RBTNode<DataType>);
        }

        /// <summary>
        /// Gets the string representation of the node.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string representation = base.ToString();
            StringBuilder sb = new StringBuilder(representation);

            sb.Append("-" + (this.IsBlack() ? "Black" : "Red"));

            return sb.ToString();
        }
    }
}
