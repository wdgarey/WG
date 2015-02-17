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
        /// The name of the table.
        /// </summary>
        private string table;

        /// <summary>
        /// The first attribute in the "on" condition.
        /// </summary>
        private SqlAttribute attribute1;

        /// <summary>
        /// The second attribute in the "on" condition.
        /// </summary>
        private SqlAttribute attribute2;

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
        /// Gets or sets the first attribute in the "on" condition.
        /// </summary>
        public virtual SqlAttribute Attribute1
        {
            get { return this.attribute1; }
            set { this.attribute1 = value; }
        }

        /// <summary>
        /// Gets or sets the second attribute in the "on" condition.
        /// </summary>
        public virtual SqlAttribute Attribute2
        {
            get { return this.attribute2; }
            set { this.attribute2 = value; }
        }

        /// <summary>
        /// Creates an instance of a join clause.
        /// </summary>
        /// <param name="type">The type of join.</param>
        public JoinClause(string type, string table, SqlAttribute attribute1, SqlAttribute attribute2)
            : base("JOIN")
        {
            this.Type = type;
            this.Table = table;
            this.Attribute1 = attribute1;
            this.Attribute2 = attribute2;
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
        /// Gets and returns the attribute separator string.
        /// </summary>
        /// <returns>The separator string.</returns>
        protected virtual string GetAttributeSepStr()
        {
            return "=";
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
            string attrSepStr = this.GetAttributeSepStr();
            SqlAttribute attribute1 = this.Attribute1;
            SqlAttribute attribute2 = this.Attribute2;
            StringBuilder sb = new StringBuilder("");

            sb.Append(type);
            sb.Append(" ");
            sb.Append(keyWord);
            sb.Append(" ");
            sb.Append(table);
            sb.Append(" ");
            sb.Append(onKeyWord);
            sb.Append(" ");
            sb.Append(attribute1.Name);
            sb.Append(" ");
            sb.Append(attrSepStr);
            sb.Append(" ");
            sb.Append(Attribute2.Name);

            return sb.ToString();
        }
    }
}
