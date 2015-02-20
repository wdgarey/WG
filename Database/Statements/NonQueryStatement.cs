using System;
using System.Data;

using MySql.Data.MySqlClient;

namespace WG.Database.Statements
{
    /// <summary>
    /// An object that represents a SQL non-query statement.
    /// </summary>
    public abstract class NonQueryStatement : Statement
    {
        /// <summary>
        /// Creates an instance of a non-query statement.
        /// </summary>
        public NonQueryStatement()
            : base()
        { }

        /// <summary>
        /// Executes the query statement.
        /// </summary>
        /// <param name="dci">The database connection information.</param>
        /// <returns>The number of rows effected by the query.</returns>
        public virtual int Execute(DbConnectionInfo dci)
        {
            MySqlCommand command = this.CreateCommand(dci);

            int rowsAffected = command.ExecuteNonQuery();
            
            return rowsAffected;
        }
    }
}
