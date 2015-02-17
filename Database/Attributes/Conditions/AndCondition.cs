using System;

using WG.Database.Attributes;

namespace WG.Database.Attributes.Conditions
{
    /// <summary>
    /// An object that represents an AND condition.
    /// </summary>
    public class AndCondition : Condition
    {
        /// <summary>
        /// Creates an instance of an AND condition.
        /// </summary>
        /// <param name="attribute">The attribute to be evaluated in the AND condition.</param>
        public AndCondition(SqlAttribute attribute)
            : base("AND", attribute)
        { }
    }
}
