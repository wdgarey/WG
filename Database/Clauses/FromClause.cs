using System;
using System.Text;
using System.Collections.Generic;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents the from clause of an SQL statement.
    /// </summary>
    public class FromClause : Clause
    {
        /// <summary>
        /// The name of the table.
        /// </summary>
        private string table;

        /// <summary>
        /// The collection of additional joins.
        /// </summary>
        private List<JoinClause> joins;

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        public virtual string Table
        {
            get { return this.table; }
            set { this.table = value; }
        }

        /// <summary>
        /// Gets or sets the collection of additional joins.
        /// </summary>
        public virtual List<JoinClause> Joins
        {
            get { return this.joins; }
            set { this.joins = value; }
        }

        /// <summary>
        /// Creates an instance of From Clause.
        /// </summary>
        /// <param name="table">The name of the table.</param>
        public FromClause(string table)
            : base("FROM")
        {
            this.Table = table;
            this.Joins = new List<JoinClause>();
        }

        /// <summary>
        /// Creates an instance of From Clause.
        /// </summary>
        /// <param name="table">The name of the table.</param>
        /// <param name="joins">The collection of additional joins</param>
        public FromClause(string table, List<JoinClause> joins)
            : base("FROM")
        {
            this.Table = table;
            this.Joins = joins;
        }

        /// <summary>
        /// Indicates whether or not there exists additional joins.
        /// </summary>
        /// <returns>True, if there are additional joins.</returns>
        public virtual bool HasJoins()
        {
            List<JoinClause> joins = this.Joins;
            bool hasJoins = (joins != null && joins.Count > 0);

            return hasJoins;
        }

        /// <summary>
        /// Indicates whether or not a table name has been specified.
        /// </summary>
        /// <returns>True, if a table name has been specified.</returns>
        public virtual bool HasTable()
        {
            string table = this.Table;
            bool hasTable = (table != null);

            return hasTable;
        }

        /// <summary>
        /// Adds an additional join.
        /// </summary>
        /// <param name="clause">The join clause.</param>
        public virtual void Join(JoinClause clause)
        {
            List<JoinClause> joins = this.Joins;

            joins.Add(clause);
        }

        /// <summary>
        /// Creates a string representation of the from clause. 
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            string table = this.Table;
            string keyWord = this.KeyWord;
            List<JoinClause> joins = this.Joins;
            
            StringBuilder sb = new StringBuilder(keyWord);
            sb.Append(" ");
            sb.Append(table);

            foreach(JoinClause join in joins)
            {
                sb.Append(" ");
                sb.Append(join.ToString());
            }

            return sb.ToString();
        }
    }
}
