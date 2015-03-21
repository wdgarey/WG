using System;

namespace WG.Collections.Nodes
{
    /// <summary>
    /// A linked node that has a prioirty associated with it.
    /// </summary>
    /// <typeparam name="DataType">The data type of the data that will be stored in the node.</typeparam>
    public class PriorityNode<DataType> : LinkedNode<DataType>
    {
        /// <summary>
        /// The priority of the node.
        /// </summary>
        private int priority;

        /// <summary>
        /// Gets or sets the priority of the node.
        /// </summary>
        public virtual int Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }

        /// <summary>
        /// Gets or sets the next link.
        /// </summary>
        public new PriorityNode<DataType> Next
        {
            get { return (base.Next as PriorityNode<DataType>); }
            set { base.Next = value; }
        }

        /// <summary>
        /// Gets or sets the previous link.
        /// </summary>
        public new PriorityNode<DataType> Previous
        {
            get { return (base.Previous as PriorityNode<DataType>); }
            set { base.Previous = value; }
        }

        /// <summary>
        /// Creates an instance of a priority node.
        /// </summary>
        public PriorityNode()
            : base()
        {
            this.Priority = 0;
        }

        /// <summary>
        /// Creates an instance of a priority node.
        /// </summary>
        /// <param name="priority">The priority of the node.</param>
        public PriorityNode(int priority)
            : base()
        {
            this.Priority = priority;
        }

        /// <summary>
        /// Creates an instance of a priority node.
        /// </summary>
        /// <param name="data">The data to store in the node.</param>
        public PriorityNode(DataType data)
            : base(data)
        {
            this.Priority = 0;
        }

        /// <summary>
        /// Creates an instance of a priority node.
        /// </summary>
        /// <param name="data">The data to store in the node.</param>
        /// <param name="priority">The priority of the node.</param>
        public PriorityNode(DataType data, int priority)
            : base(data)
        {
            this.Priority = priority;
        }
    }
}
