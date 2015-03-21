using System;
using System.Data;

using WG.Database;

using MySql.Data.MySqlClient;

namespace WG.Database.Statements
{
    /// <summary>
    /// An object that represents an SQL query statement.
    /// </summary>
    public abstract class QueryStatement : Statement
    {
        /// <summary>
        /// Creates an instance of a query statement.
        /// </summary>
        public QueryStatement()
            : base()
        { }

        /// <summary>
        /// Executes the query statement and returns the data.
        /// </summary>
        /// <param name="dci">The database connection information.</param>
        /// <returns>The table of data.</returns>
        public virtual DataTable Execute(DbConnectionInfo dci)
        {
            MySqlCommand command = this.CreateCommand(dci);
            MySqlConnection connection = command.Connection;

            MySqlDataReader dReader = command.ExecuteReader();
            
            DataTable table = new DataTable();
            table.Load(dReader);

            dReader.Close();
            dReader.Dispose();

            connection.Close();

            return table;
        }
    }
}
