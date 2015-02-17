using System;

using WG.Database.Clauses;

namespace WG.Database.Statements
{
    /// <summary>
    /// An objec that represents an SQL select statement.
    /// </summary>
    public class SelectStatement : Statement
    {
        /// <summary>
        /// The select clause.
        /// </summary>
        private SelectClause select;

        /// <summary>
        /// The from clause.
        /// </summary>
        private FromClause from;

        /// <summary>
        /// The where clause.
        /// </summary>
        private WhereClause where;

        /// <summary>
        /// Gets or sets the select clause.
        /// </summary>
        public virtual SelectClause Select
        {
            get { return this.select; }
            set { this.select = value; }
        }

        /// <summary>
        /// Gets or sets the from clause.
        /// </summary>
        public virtual FromClause From
        {
            get { return this.from; }
            set { this.from = value; }
        }

        /// <summary>
        /// Gets or sets the where clause.
        /// </summary>
        public virtual WhereClause Where
        {
            get { return this.where; }
            set { this.where = value; }
        }

        /// <summary>
        /// Creates an instance of a select statement.
        /// </summary>
        /// <param name="select">The select clause.</param>
        /// <param name="from">The from clause.</param>
        public SelectStatement(SelectClause select, FromClause from)
        {
            this.Select = select;
            this.From = from;
            this.Where = null;
        }

        /// <summary>
        /// Indicates whether or not there exists a select clause.
        /// </summary>
        /// <returns>True, if the clause exists.</returns>
        public virtual bool HasSelectClause()
        {
            SelectClause select = this.Select;

            bool hasSelectClause = (select != null);

            return hasSelectClause;
        }

        /// <summary>
        /// Indicates whether or not there exists a from clause.
        /// </summary>
        /// <returns>True, if the clause exists.</returns>
        public virtual bool HasFromClause()
        {
            FromClause from = this.From;

            bool hasFromClause = (from != null);

            return hasFromClause;
        }

        /// <summary>
        /// Indiciates whether or not there exists a where clause.
        /// </summary>
        /// <returns>True, if the clause exists.</returns>
        public virtual bool HasWhereClause()
        {
            WhereClause where = this.Where;

            bool hasWhereClause = (where != null);

            return hasWhereClause;
        }

        protected override string CreateString()
        {
            throw new NotImplementedException();
        }
    }
}
