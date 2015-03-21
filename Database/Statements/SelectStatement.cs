using System;
using System.Text;

using WG.Database.Clauses;

namespace WG.Database.Statements
{
    /// <summary>
    /// An objec that represents an SQL select statement.
    /// </summary>
    public class SelectStatement : QueryStatement
    {
        /// <summary>
        /// The select clause.
        /// </summary>
        private SelectClause selectClause;

        /// <summary>
        /// The from clause.
        /// </summary>
        private FromClause fromClause;

        /// <summary>
        /// The where clause.
        /// </summary>
        private WhereClause whereClause;

        /// <summary>
        /// Gets or sets the select clause.
        /// </summary>
        public virtual SelectClause SelectClause
        {
            get { return this.selectClause; }
            set { this.selectClause = value; }
        }

        /// <summary>
        /// Gets or sets the from clause.
        /// </summary>
        public virtual FromClause FromClause
        {
            get { return this.fromClause; }
            set { this.fromClause = value; }
        }

        /// <summary>
        /// Gets or sets the where clause.
        /// </summary>
        public virtual WhereClause WhereClause
        {
            get { return this.whereClause; }
            set { this.whereClause = value; }
        }

        /// <summary>
        /// Creates an instance of a select statement.
        /// </summary>
        /// <param name="selectClause">The select clause.</param>
        /// <param name="fromClause">The from clause.</param>
        public SelectStatement(SelectClause selectClause, FromClause fromClause)
        {
            this.SelectClause = selectClause;
            this.FromClause = fromClause;
            this.WhereClause = null;
        }

        /// <summary>
        /// Creates an instance of a select statement.
        /// </summary>
        /// <param name="selectClause">The select clause.</param>
        /// <param name="fromClause">The from clause.</param>
        /// <param name="whereClause">The where clause.</param>
        public SelectStatement(SelectClause selectClause, FromClause fromClause, WhereClause whereClause)
        {
            this.SelectClause = selectClause;
            this.FromClause = fromClause;
            this.WhereClause = whereClause;
        }

        /// <summary>
        /// Indicates whether or not there exists a select clause.
        /// </summary>
        /// <returns>True, if the clause exists.</returns>
        public virtual bool HasSelectClause()
        {
            SelectClause select = this.SelectClause;

            bool hasSelectClause = (select != null);

            return hasSelectClause;
        }

        /// <summary>
        /// Indicates whether or not there exists a from clause.
        /// </summary>
        /// <returns>True, if the clause exists.</returns>
        public virtual bool HasFromClause()
        {
            FromClause from = this.FromClause;

            bool hasFromClause = (from != null);

            return hasFromClause;
        }

        /// <summary>
        /// Indiciates whether or not there exists a where clause.
        /// </summary>
        /// <returns>True, if the clause exists.</returns>
        public virtual bool HasWhereClause()
        {
            WhereClause where = this.WhereClause;

            bool hasWhereClause = (where != null);

            return hasWhereClause;
        }

        /// <summary>
        /// Creates and returns the string representation of the select statement.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            SelectClause select = this.SelectClause;
            FromClause from = this.FromClause;
            
            StringBuilder sb = new StringBuilder();
            sb.Append(select.ToString());
            sb.Append(" ");
            sb.Append(from.ToString());

            if(this.HasWhereClause())
            {
                WhereClause where = this.WhereClause;

                sb.Append(" ");
                sb.Append(where.ToString());
            }

            return sb.ToString();
        }
    }
}
