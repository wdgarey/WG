using System;
using System.Text;
using System.Collections.Generic;

using WG.Database.Attributes;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents a set clause.
    /// </summary>
    public class SetClause : AttributeClause
    {
        /// <summary>
        /// Creates an instance of a set clause.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        public SetClause(List<SqlAttribute> attributes)
            : base("SET", attributes)
        { }

        /// <summary>
        /// Gets and returns the clause attribute seperator string.
        /// </summary>
        /// <returns>The separator string.</returns>
        protected override string GetSeparatorStr()
        {
            return ",";
        }

        /// <summary>
        /// Gets and returns the opening delimiter string of the clause.
        /// </summary>
        /// <returns>The opening delimiter.</returns>
        protected override string GetOpenDelimiterStr()
        {
            return "";
        }

        /// <summary>
        /// Gets and returns the closing delimiter string of the clause.
        /// </summary>
        /// <returns>The closing delimiter.</returns>
        protected override string GetCloseDelimiterStr()
        {
            return "";
        }
    }
}
