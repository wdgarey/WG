using System;
using System.Collections.Generic;

using WG.Database.Attributes;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents a collection of values.
    /// </summary>
    public class Values : AttributeClause
    {
        /// <summary>
        /// Creats an instance of values.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        public Values(List<SqlAttribute> attributes)
            : base("", attributes)
        { }

        /// <summary>
        /// Gets the value separator string.
        /// </summary>
        /// <returns>The separator string.</returns>
        protected override string GetSeparatorStr()
        {
            return ",";
        }

        /// <summary>
        /// Gets the opening delimiter string of the value collection.
        /// </summary>
        /// <returns>The opening delimiter string.</returns>
        protected override string GetOpenDelimiterStr()
        {
            return "(";
        }

        /// <summary>
        /// Gets the closing delimiter string of the value collection.
        /// </summary>
        /// <returns>The closing delimiter string.</returns>
        protected override string GetCloseDelimiterStr()
        {
            return ")";
        }

        /// <summary>
        /// Creates a string representation of the values.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            string representation = base.CreateString();
            List<SqlAttribute> attributes = this.Attributes;
            
            foreach(SqlAttribute attribute in attributes)
            {
                string attrValueStr = attribute.GetValueStr();
                string attrFullName = attribute.GetFullName();

                representation = representation.Replace(attrFullName, attrValueStr);
            }

            return representation;
        }
    }
}
