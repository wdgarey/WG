using System;
using System.Text;
using System.Collections.Generic;

using WG.Database.Attributes;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents an attribute clause in an SQL statement.
    /// </summary>
    public abstract class AttributeClause : Clause
    {
        /// <summary>
        /// The collection of attributes to use in the clause.
        /// </summary>
        private List<SqlAttribute> attributes;

        /// <summary>
        /// Gets or sets the collection of attributes to use in the clause.
        /// </summary>
        public virtual List<SqlAttribute> Attributes
        {
            get { return this.attributes; }
            set { this.attributes = value; }
        }

        /// <summary>
        /// Creates an instance of an attribute clause.
        /// </summary>
        /// <param name="keyWord">The key word of the clause.</param>
        public AttributeClause(string keyWord)
            : base(keyWord)
        {
            this.Attributes = new List<SqlAttribute>();
        }

        /// <summary>
        /// Creates an instance of an attribute clause.
        /// </summary>
        /// <param name="keyWord">The key word of the clause.</param>
        /// <param name="attribute">The attribute to use in the clause.</param>
        public AttributeClause(string keyWord, SqlAttribute attribute)
            : base(keyWord)
        {
            this.Attributes = new List<SqlAttribute>() { attribute };
        }

        /// <summary>
        /// Creates an instance of an attribute clause.
        /// </summary>
        /// <param name="keyWord">The key word of the clause.</param>
        /// <param name="attributes">The collection of attributes to use in the clause.</param>
        public AttributeClause(string keyWord, List<SqlAttribute> attributes)
            : base(keyWord)
        {
            this.Attributes = attributes;
        }

        /// <summary>
        /// Indicates whether or nor the current clause has attributes to use in the clause.
        /// </summary>
        /// <returns>True, if there are attributes to use in the clause.</returns>
        protected virtual bool HasAttributes()
        {
            List<SqlAttribute> attributes = this.Attributes;

            bool hasAttributes = (attributes != null && attributes.Count > 0);

            return hasAttributes;
        }

        /// <summary>
        /// Creates the string representation of the clause.
        /// </summary>
        /// <returns>The string representation of the clause.</returns>
        protected override string CreateString()
        {
            string keyWord = this.KeyWord;
            string separatorStr = this.GetSeparatorStr();
            string openDelimStr = this.GetOpenDelimiterStr();
            string closeDelimStr = this.GetCloseDelimiterStr();
            List<SqlAttribute> attributes = this.Attributes;

            StringBuilder sb = new StringBuilder(keyWord);
            sb.Append(" ");
            sb.Append(openDelimStr);

            foreach(SqlAttribute attribute in attributes)
            {
                sb.Append(attribute.GetFullName());
                sb.Append(separatorStr);
            }

            sb.Remove(sb.Length - separatorStr.Length, separatorStr.Length);
            sb.Append(closeDelimStr);

            return sb.ToString();
        }

        /// <summary>
        /// Gets the attribute separator character for the clause.
        /// </summary>
        /// <returns>The attribute separator character.</returns>
        protected abstract string GetSeparatorStr();

        /// <summary>
        /// Gets the opening delimiter string.
        /// </summary>
        /// <returns>The open delimiter.</returns>
        protected abstract string GetOpenDelimiterStr();

        /// <summary>
        /// Gets the closing delimiter string.
        /// </summary>
        /// <returns>The closing delimiter.</returns>
        protected abstract string GetCloseDelimiterStr();
    }
}
