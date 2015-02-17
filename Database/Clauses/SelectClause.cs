using System;
using System.Text;
using System.Collections.Generic;

using WG.Database.Attributes;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents the select clause of a SQL statement.
    /// </summary>
    public class SelectClause : AttributeClause
    {
        /// <summary>
        /// Creates an instance of a select clause.
        /// </summary>
        public SelectClause()
            : base("SELECT")
        { }

        /// <summary>
        /// Creates an instance of a select clause.
        /// </summary>
        /// <param name="attributes">The attributes to select.</param>
        public SelectClause(List<SqlAttribute> attributes)
            : base("SELECT", attributes)
        { }

        /// <summary>
        /// Gets and returns the wild card character to use if no attributes exist.
        /// </summary>
        /// <returns>The wild card character.</returns>
        protected virtual char GetWildCardChar()
        {
            return '*';
        }

        /// <summary>
        /// Gets and returns the string to use to separate the attributes to select.
        /// </summary>
        /// <returns>The separator string.</returns>
        protected override string GetSeparatorStr()
        {
            return ",";
        }

        /// <summary>
        /// Creates the string representation of the select clause.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            string representation = this.CreateString();

            if(!this.HasAttributes())
            {
                char wildCardChar = this.GetWildCardChar();
                StringBuilder sb = new StringBuilder(representation);
                sb.Append(' ');
                sb.Append(wildCardChar);

                representation = sb.ToString();
            }

            return representation;
        }
    }
}
