using System;

using WG.Collections.Nodes;

namespace WG.Collections.Linked
{
    /// <summary>
    /// A queue that assembles elements based on their priority.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that will be stored in the queue.</typeparam>
    public abstract class PriorityQueue<DataType> : Queue<DataType>
    {
        /// <summary>
        /// The default priority of an elemement.
        /// </summary>
        private int defaultPriority;

        /// <summary>
        /// Gets or sets the default priority of an element.
        /// </summary>
        public virtual int DefaultPriority
        {
            get { return this.defaultPriority; }
            set { this.defaultPriority = value; }
        }

        /// <summary>
        /// Gets or sets the front sentinel node of the queue.
        /// </summary>
        public new PriorityNode<DataType> Front
        {
            get { return (base.Front as PriorityNode<DataType>); }
            set { base.Front = value; }
        }

        /// <summary>
        /// Gets or sets the back sentinel node of the queue.
        /// </summary>
        public new PriorityNode<DataType> Back
        {
            get { return (base.Back as PriorityNode<DataType>); }
            set { base.Back = value; }
        }

        /// <summary>
        /// Creates an instance of a priority queue.
        /// </summary>
        /// <param name="defaultPriority">The default priority to assign to elements.</param>
        public PriorityQueue(int defaultPriority = 0)
            : base()
        {
            this.DefaultPriority = defaultPriority;
            this.Back = new PriorityNode<DataType>();
            this.Front = new PriorityNode<DataType>();

            this.Back.SetNext(this.Front);
        }

        /// <summary>
        /// Adds a node to the front of the queue.
        /// </summary>
        /// <param name="node">The node to add.</param>
        protected virtual void AddToFront(PriorityNode<DataType> node)
        {
            bool done = false;
            int myPriority = node.Priority;
            PriorityNode<DataType> temp = this.Front;
            PriorityNode<DataType> back = this.Back;
            
            while(temp.HasPrevious() && !done)
            {
                temp = temp.Previous;
                int theirPriority = temp.Priority;
                int highestPrec = this.GetHigherPrecedence(myPriority, theirPriority);

                if (highestPrec == theirPriority || temp == back)
                {
                    done = true;
                }
            }

            temp.SetNext(node);
        }

        /// <summary>
        /// Adds a node to the back of the queue.
        /// </summary>
        /// <param name="node">The node to add.</param>
        protected virtual void AddToBack(PriorityNode<DataType> node)
        {
            bool done = false;
            int myPriority = node.Priority;
            PriorityNode<DataType> temp = this.Back;
            PriorityNode<DataType> front = this.Front;

            while(temp.HasNext() && !done)
            {
                temp = temp.Next;
                int theirPriority = temp.Priority;
                int highestPrec = this.GetHigherPrecedence(myPriority, theirPriority);

                if (highestPrec == theirPriority || temp == front)
                {
                    done = true;
                }
            }

            temp.SetPrevious(node);
        }

        /// <summary>
        /// Adds an element to the queue using the default priority.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public override void Enqueue(DataType element)
        {
            int defaultPriority = this.DefaultPriority;

            this.Enqueue(element, defaultPriority);
        }

        /// <summary>
        /// Adds an element to the queue using the given priority.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <param name="priority">The priority of the element.</param>
        public virtual void Enqueue(DataType element, int priority)
        {
            PriorityNode<DataType> node = new PriorityNode<DataType>(element, priority);

            this.AddToBack(node);
        }

        /// <summary>
        /// Returns the priority that has a higher precedence.
        /// </summary>
        /// <param name="priority1">The first priority.</param>
        /// <param name="priority2">The second priority.</param>
        /// <returns>The prioity with the greater precedence.</returns>
        protected abstract int GetHigherPrecedence(int priority1, int priority2);
    }
}
