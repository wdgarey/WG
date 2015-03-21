using System;

namespace WG.Collections.Linked
{
    /// <summary>
    /// A queue that assembles elements based on their priority.
    /// </summary>
    /// <typeparam name="DataType">The data type of the elements that are going to be stored.</typeparam>
    public class HighPriorityQueue<DataType> : PriorityQueue<DataType>
    {
        /// <summary>
        /// Creates an instance of a high priority queue.
        /// </summary>
        /// <param name="defaultPriority">The default priority to assign to elements</param>
        public HighPriorityQueue(int defaultPriority = 0)
            : base(defaultPriority)
        { }

        /// <summary>
        /// Returns the priority with the higher precedence, i.e. the higher value.
        /// </summary>
        /// <param name="priority1">The first priority.</param>
        /// <param name="priority2">The second priority.</param>
        /// <returns>The priority with the higher precedence.</returns>
        protected override int GetHigherPrecedence(int priority1, int priority2)
        {
            int higherPrec = priority1 > priority2 ? priority1 : priority2;

            return higherPrec;
        }
    }
}
