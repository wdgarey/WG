using System;
using System.Text;

using WG.Database.Clauses;

namespace WG.Database.Statements
{
    /// <summary>
    /// An object that represents a SQL delete statement.
    /// </summary>
    public class DeleteStatement : NonQueryStatement
    {
        /// <summary>
        /// The delete clause of the statement.
        /// </summary>
        private DeleteClause deleteClause;

        /// <summary>
        /// The from clause of the statement.
        /// </summary>
        private FromClause fromClause;

        /// <summary>
        /// The where clause of the statement.
        /// </summary>
        private WhereClause whereClause;

        /// <summary>
        /// Gets or sets the delete clause of the statement.
        /// </summary>
        public virtual DeleteClause DeleteClause
        {
            get { return this.deleteClause; }
            set { this.deleteClause = value; }
        }

        /// <summary>
        /// Gets or sets the from clause of the statement.
        /// </summary>
        public virtual FromClause FromClause
        {
            get { return this.fromClause; }
            set { this.fromClause = value; }
        }

        /// <summary>
        /// Gets or sets the where clause of the statement.
        /// </summary>
        public virtual WhereClause WhereClause
        {
            get { return this.whereClause; }
            set { this.whereClause = value; }
        }

        /// <summary>
        /// Creates an instance of a delete statement.
        /// </summary>
        /// <param name="deleteClause">The delete clause of the statement.</param>
        /// <param name="fromClause">The from clause of the statement.</param>
        public DeleteStatement(DeleteClause deleteClause, FromClause fromClause)
        {
            this.DeleteClause = deleteClause;
            this.FromClause = fromClause;
            this.WhereClause = null;
        }

        /// <summary>
        /// Creates an instance of a delete statement.
        /// </summary>
        /// <param name="deleteClause">The delete clause of the statement.</param>
        /// <param name="fromClause">The from clause of the statement.</param>
        /// <param name="whereClause">The where clause of the statement.</param>
        public DeleteStatement(DeleteClause deleteClause, FromClause fromClause, WhereClause whereClause)
        {
            this.DeleteClause = deleteClause;
            this.FromClause = fromClause;
            this.WhereClause = whereClause;
        }

        /// <summary>
        /// Indicates whether or not the statement has a where clause.
        /// </summary>
        /// <returns>True, if the statement has a where clause.</returns>
        public virtual bool HasWhereClause()
        {
            WhereClause where = this.WhereClause;

            bool hasWhere = (where != null);

            return hasWhere;
        }

        /// <summary>
        /// Creates the string representation of the delete statement.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            DeleteClause deleteClause = this.DeleteClause;
            FromClause fromClause = this.FromClause;

            StringBuilder sb = new StringBuilder(deleteClause.ToString());
            sb.Append(" ");
            sb.Append(fromClause.ToString());

            if(this.HasWhereClause())
            {
                WhereClause whereClause = this.WhereClause;

                sb.Append(" ");
                sb.Append(whereClause);
            }

            return sb.ToString();
        }
    }
}
