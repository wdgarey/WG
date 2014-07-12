using System;

namespace WG.Collections.Nodes
{
    /// <summary>
    /// A parented node.
    /// </summary>
    /// <typeparam name="DataType">The data type of the element that will be stored in the node.</typeparam>
    public class ChildNode<DataType> : Node<DataType>
    {
        /// <summary>
        /// The parent node.
        /// </summary>
        private ChildNode<DataType> parent;

        /// <summary>
        /// Accessor to the parent node.
        /// </summary>
        public virtual ChildNode<DataType> Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        /// <summary>
        /// Creates an instance of a ParentedNode.
        /// </summary>
        public ChildNode()
            : base()
        {
            this.Parent = null;
        }

        /// <summary>
        /// Creates an instance of a ParentedNode.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        public ChildNode(DataType element)
            : base(element)
        {
            this.Parent = null;
        }

        /// <summary>
        /// Indicates whether or not this node has a parent.
        /// </summary>
        /// <returns>True, if this node has a parent.</returns>
        public virtual bool HasParent()
        {
            bool hasParent = false;
            ChildNode<DataType> parent = this.Parent;

            if (parent != null)
            {
                hasParent = true;
            }

            return hasParent;
        }

        /// <summary>
        /// Indicates whether or not this node's parent has parent.
        /// </summary>
        /// <returns>True, if this node has a parent and the parent has a parent.</returns>
        public virtual bool HasGrandParent()
        {
            bool hasGrandparent = false;
            ChildNode<DataType> parent = this.Parent;

            if (parent != null && parent.HasParent())
            {
                hasGrandparent = parent.HasParent();
            }

            return hasGrandparent;
        }

        /// <summary>
        /// Gets the grandparent of this node.
        /// </summary>
        /// <returns>The grandparent of this node; or null if there is no parent or no grandparent</returns>
        public virtual ChildNode<DataType> GetGrandparent()
        {
            ChildNode<DataType> grandparent = null;
            ChildNode<DataType> parent = this.Parent;

            if (parent != null)
            {
                grandparent = parent.Parent;
            }

            return grandparent;
        }
    }
}
