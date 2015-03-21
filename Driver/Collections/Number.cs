using System;

using WG.Collections.Interfaces;

namespace Driver.Collections
{
    /// <summary>
    /// A number.
    /// </summary>
    public class Number : IRelatable<Number>
    {
        /// <summary>
        /// The value.
        /// </summary>
        private int value;

        /// <summary>
        /// Accessor to the value.
        /// </summary>
        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Creates an instance of a Number.
        /// </summary>
        /// <param name="value">The value of the number.</param>
        public Number(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Indicates whether or not this number is another number.
        /// </summary>
        /// <param name="comparable">The other number.</param>
        /// <returns>True, if this number is equal to the given number.</returns>
        public bool IsEqualTo(Number comparable)
        {
            return (this.Value == comparable.Value);
        }

        /// <summary>
        /// Indicates whether or not this number is less than another number.
        /// </summary>
        /// <param name="comparable">The other number.</param>
        /// <returns>True, if this number is less than the other number.</returns>
        public bool IsLessThan(Number comparable)
        {
            return (this.Value < comparable.Value);
        }

        /// <summary>
        /// Indicates whether or no this number is greater than another number.
        /// </summary>
        /// <param name="comparable">The other number.</param>
        /// <returns>True, if this number is greater than the other number.</returns>
        public bool IsGreaterThan(Number comparable)
        {
            return (this.Value > comparable.Value);
        }

        /// <summary>
        /// Gets the string representation of the number.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return this.Value.ToString("N");
        }
    }
}
