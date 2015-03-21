using System;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents a SQL delete clause.
    /// </summary>
    public class DeleteClause : Clause
    {
        /// <summary>
        /// Creates an instance of a delete clause.
        /// </summary>
        public DeleteClause()
            : base("DELETE")
        { }

        /// <summary>
        /// Creates and returns the string representation of the delete clause.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            string keyWord = this.KeyWord;

            return keyWord;
        }
    }
}
