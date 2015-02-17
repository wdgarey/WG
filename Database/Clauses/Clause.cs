using System;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents a clause in an SQL statement.
    /// </summary>
    public abstract class Clause
    {
        /// <summary>
        /// The key word of the clause.
        /// </summary>
        private string keyWord;

        /// <summary>
        /// Gets or sets the key word of the clause.
        /// </summary>
        public virtual string KeyWord
        {
            get { return this.keyWord; }
            set { this.keyWord = value; }
        }

        /// <summary>
        /// Creates an instance of a clause.
        /// </summary>
        /// <param name="keyWord">The key word of the clause.</param>
        public Clause(string keyWord)
        {
            this.KeyWord = keyWord;
        }

        /// <summary>
        /// Gets the string representation of the clause.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string representation = this.CreateString();

            return representation;
        }

        /// <summary>
        /// Creates the string representation of the clause.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected abstract string CreateString();
    }
}
