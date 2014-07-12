using System;

namespace WG.Collections.Interfaces
{
    /// <summary>
    /// An interface that allows an object to be compared to another object.
    /// </summary>
    /// <typeparam name="DataType">The other object that the object can be compared to.</typeparam>
    public interface IRelatable<DataType>
    {
        /// <summary>
        /// Indicates whether or not this object equals th given object.
        /// </summary>
        /// <param name="comparable">The given object.</param>
        /// <returns>True, if the object is equal to the given object.</returns>
        bool IsEqualTo(DataType comparable);

        /// <summary>
        /// Indicates whether or not this object is less than the given object.
        /// </summary>
        /// <param name="comparable">The given object.</param>
        /// <returns>True, if the this object is less than the given object.</returns>
        bool IsLessThan(DataType comparable);

        /// <summary>
        /// Indicates whether or not this object is greater than the given object.
        /// </summary>
        /// <param name="comparable">The given object.</param>
        /// <returns>True, if this object is greater than the given object.</returns>
        bool IsGreaterThan(DataType comparable);
    }
}
