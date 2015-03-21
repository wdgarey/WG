using System;
using System.Text;
using System.Collections.Generic;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents an update clause.
    /// </summary>
    public class UpdateClause : Clause
    {
        /// <summary>
        /// The name of the table to update.
        /// </summary>
        private string table;

        /// <summary>
        /// The set clause of the update.
        /// </summary>
        private SetClause setClause;

        /// <summary>
        /// Gets or sets the name of the table to update.
        /// </summary>
        public virtual string Table
        {
            get { return this.table; }
            set { this.table = value; }
        }

        /// <summary>
        /// Gets or sets the set clause of the update.
        /// </summary>
        public virtual SetClause SetClause
        {
            get { return this.setClause; }
            set { this.setClause = value; }
        }

        /// <summary>
        /// Creates an instance of an update clause.
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="setClause">The set clause of the update.</param>
        public UpdateClause(string table, SetClause setClause)
            : base("UPDATE")
        {
            this.Table = table;
            this.SetClause = setClause;
        }

        /// <summary>
        /// Creates and returns the string representation of the update clause.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            string table = this.Table;
            string keyWord = this.KeyWord;
            SetClause setClause = this.SetClause;

            StringBuilder sb = new StringBuilder(keyWord);
            sb.Append(" ");
            sb.Append(table);
            sb.Append(" ");
            sb.Append(setClause);

            return sb.ToString();
        }
    }
}
