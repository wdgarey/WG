using System;

using WG.Database;

using MySql.Data.MySqlClient;

namespace WG.Database.Statements
{
    /// <summary>
    /// An object that represents an SQL statement.
    /// </summary>
    public abstract class Statement
    {
        /// <summary>
        /// Creates an instance of a statement.
        /// </summary>
        public Statement()
        { }

        /// <summary>
        /// Gets the statements ending string.
        /// </summary>
        /// <returns>The ending string.</returns>
        protected virtual string GetEndingStr()
        {
            return ";";
        }

        /// <summary>
        /// Creates the SQL command for the statement.
        /// </summary>
        /// <param name="dci">The database connection information.</param>
        /// <returns>The new SQL command.</returns>
        protected MySqlCommand CreateCommand(DbConnectionInfo dci)
        {
            string cmdStr = this.ToString();
            string connStr = dci.ToConnectionString();

            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();

            MySqlCommand command = new MySqlCommand(cmdStr, connection);

            return command;
        }

        /// <summary>
        /// Creates and returns a string representation of the statement.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string endingStr = this.GetEndingStr();
            string representation = this.CreateString();

            representation += endingStr;

            return representation;
        }

        /// <summary>
        /// Creates and returns the string representation of the statement.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected abstract string CreateString();
    }
}
