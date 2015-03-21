using System;
using System.Text;
using System.Collections.Generic;

using WG.Database.Clauses;

namespace WG.Database.Statements
{
    /// <summary>
    /// An object that represents and SQL update statement.
    /// </summary>
    public class UpdateStatement : NonQueryStatement
    {
        /// <summary>
        /// The update cluase of the statement.
        /// </summary>
        private UpdateClause updateClause;

        /// <summary>
        /// The where clause of the statement.
        /// </summary>
        private WhereClause whereClause;

        /// <summary>
        /// Gets or sets the update clause of the statement.
        /// </summary>
        public virtual UpdateClause UpdateClause
        {
            get { return this.updateClause; }
            set { this.updateClause = value; }
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
        /// Creates an instance of an update statement.
        /// </summary>
        /// <param name="updateClause">The update clause of the statement.</param>
        public UpdateStatement(UpdateClause updateClause)
        {
            this.UpdateClause = updateClause;
        }

        /// <summary>
        /// Creates an instance of an update statement.
        /// </summary>
        /// <param name="updateClause">The update clause of the statement.</param>
        /// <param name="whereClause">The where clause of the statement.</param>
        public UpdateStatement(UpdateClause updateClause, WhereClause whereClause)
        {
            this.UpdateClause = updateClause;
            this.WhereClause = whereClause;
        }

        /// <summary>
        /// Indicates whether or not the update statement has a where clause.
        /// </summary>
        /// <returns>True, if the statement has a where clause.</returns>
        public virtual bool HasWhereClause()
        {
            WhereClause whereClause = this.WhereClause;

            bool hasWhere = (whereClause != null);

            return hasWhere;
        }

        /// <summary>
        /// Creates and returns a string representation of the update statement.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            UpdateClause updateClause = this.UpdateClause;

            StringBuilder sb = new StringBuilder(updateClause.ToString());

            if(this.HasWhereClause())
            {
                WhereClause whereClause = this.WhereClause;

                sb.Append(" ");
                sb.Append(whereClause.ToString());
            }

            return sb.ToString();
        }
    }
}
