using System;
using System.Text;

using WG.Database.Attributes;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents a jon clause.
    /// </summary>
    public class JoinClause : Clause
    {
        /// <summary>
        /// The type of join.
        /// </summary>
        private string type;

        /// <summary>
        /// The name of the table to join.
        /// </summary>
        private string table;

        /// <summary>
        /// The attribute of the "on" condition.
        /// </summary>
        private SqlAttribute attribute;

        /// <summary>
        /// Gets or sets the type of join.
        /// </summary>
        public virtual string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        public virtual string Table
        {
            get { return this.table; }
            set { this.table = value; }
        }

        /// <summary>
        /// Gets or sets the attribute of the "on" condition.
        /// </summary>
        public virtual SqlAttribute Attribute
        {
            get { return this.attribute; }
            set { this.attribute = value; }
        }

        /// <summary>
        /// Creates an instance of a join clause.
        /// </summary>
        /// <param name="type">The type of join.</param>
        public JoinClause(string type, string table, SqlAttribute attribute)
            : base("JOIN")
        {
            this.Type = type;
            this.Table = table;
            this.Attribute = attribute;
        }

        /// <summary>
        /// Gets and return the "on" key word.
        /// </summary>
        /// <returns>The "on" key word.</returns>
        protected virtual string GetOnKeyWord()
        {
            return "ON";
        }

        /// <summary>
        /// Creates the string representation of the join clause.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            string type = this.Type;
            string table = this.Table;
            string keyWord = this.KeyWord;
            string onKeyWord = this.GetOnKeyWord();
            SqlAttribute attribute = this.Attribute;
            StringBuilder sb = new StringBuilder("");

            sb.Append(type);
            sb.Append(" ");
            sb.Append(keyWord);
            sb.Append(" ");
            sb.Append(table);
            sb.Append(" ");
            sb.Append(onKeyWord);
            sb.Append(" ");
            sb.Append(attribute.ToString());

            return sb.ToString();
        }
    }
}
