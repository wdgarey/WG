using System;
using System.Text;

using WG.Database.Clauses;

namespace WG.Database.Attributes.Conditions
{
    /// <summary>
    /// An object that represents an SQL condition clause.
    /// </summary>
    public class Condition : AttributeClause
    {
        /// <summary>
        /// Creates an instance of a condition.
        /// </summary>
        /// <param name="keyWord">The key word of the condition.</param>
        /// <param name="attribute">The attribute that will be evaluated in the condition.</param>
        public Condition(string keyWord, SqlAttribute attribute)
            : base(keyWord, attribute)
        { }

        /// <summary>
        /// Gets and returns the separator string for a condition clause.
        /// </summary>
        /// <returns>The separator string.</returns>
        protected override string GetSeparatorStr()
        {
            return "";
        }

        /// <summary>
        /// Gets and returns the opening delimiter string.
        /// </summary>
        /// <returns>The opening delimiter string.</returns>
        protected override string GetOpenDelimiterStr()
        {
            return "";
        }

        /// <summary>
        /// Gets and returns the closing delimiter string.
        /// </summary>
        /// <returns>The closing delimiter string.</returns>
        protected override string GetCloseDelimiterStr()
        {
            return "";
        }
    }
}
