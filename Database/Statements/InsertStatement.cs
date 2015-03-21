using System;

using WG.Database.Clauses;

namespace WG.Database.Statements
{
    /// <summary>
    /// An object that represents an SQL insert statement.
    /// </summary>
    public class InsertStatement : NonQueryStatement
    {
        /// <summary>
        /// The insert clause.
        /// </summary>
        private InsertClause insertClause;

        /// <summary>
        /// Gets or sets the insert clause.
        /// </summary>
        public virtual InsertClause InsertClause
        {
            get { return this.insertClause; }
            set { this.insertClause = value; }
        }

        /// <summary>
        /// Creates an instance of an insert statement.
        /// </summary>
        /// <param name="insertClause">The insert clause.</param>
        public InsertStatement(InsertClause insertClause)
        {
            this.InsertClause = insertClause;
        }

        /// <summary>
        /// Creates a string representation of the insert statement.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            InsertClause insertClause = this.InsertClause;
            string representation = insertClause.ToString();

            return representation;
        }
    }
}
