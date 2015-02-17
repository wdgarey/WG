using System;


namespace WG.Database.Attributes.Conditions
{
    /// <summary>
    /// An objec that represents an OR condition.
    /// </summary>
    public class OrCondition : Condition
    {
        /// <summary>
        /// Creates an instance of an OR condition.
        /// </summary>
        /// <param name="attribute">The attribute that will be evaluated in the condition.</param>
        public OrCondition(SqlAttribute attribute)
            : base("OR", attribute)
        { }
    }
}
