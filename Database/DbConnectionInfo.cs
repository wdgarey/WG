using System.Text;

namespace WG.Database
{
    /// <summary>
    /// An object used for holding database connection information.
    /// </summary>
    public class DbConnectionInfo
    {
        /// <summary>
        /// The server of the database.
        /// </summary>
        private string server;

        /// <summary>
        /// The user's username.
        /// </summary>
        private string userName;

        /// <summary>
        /// The user's password.
        /// </summary>
        private string password;

        /// <summary>
        /// The name of the database.
        /// </summary>
        private string database;

        /// <summary>
        /// Gets or sets the server of the database.
        /// </summary>
        public string Server
        {
            get { return this.server; }
            set { this.server = value; }
        }

        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        public string Database
        {
            get { return this.database; }
            set { this.database = value; }
        }

        /// <summary>
        /// Gets the character used to separate the name value pairs of the connection string.
        /// </summary>
        /// <returns>The separator character.</returns>
        protected virtual char GetSeparatorChar()
        {
            return ';';
        }

        /// <summary>
        /// Gets the character used to assign a value to a paramter name in the connection string.
        /// </summary>
        /// <returns>The assignment character.</returns>
        protected virtual char GetAssignmentChar()
        {
            return '=';
        }

        /// <summary>
        /// Gets the name of the server variable.
        /// </summary>
        /// <returns>The name.</returns>
        protected virtual string GetServerVar()
        {
            return "server";
        }

        /// <summary>
        /// Gets the name of the username variable.
        /// </summary>
        /// <returns>The name.</returns>
        protected virtual string GetUserNameVar()
        {
            return "uid";
        }

        /// <summary>
        /// Gets the name of the password variable.
        /// </summary>
        /// <returns>The name.</returns>
        protected virtual string GetPasswordVar()
        {
            return "pwd";
        }

        /// <summary>
        /// Gets the name of the database variable.
        /// </summary>
        /// <returns>The name.</returns>
        protected virtual string GetDatabaseVar()
        {
            return "database";
        }

        /// <summary>
        /// Gets the name value pair.
        /// </summary>
        /// <param name="variable">The variable name.</param>
        /// <param name="value">The value.</param>
        /// <returns>The name value pair.</returns>
        protected virtual string GetNameValuePair(string variable, string value)
        {
            char separatorChar = this.GetSeparatorChar();
            char assignmentChar = this.GetAssignmentChar();

            string nameValPair = variable + assignmentChar + separatorChar + value + separatorChar;

            return nameValPair;
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>The connection string.</returns>
        public virtual string ToConnectionString()
        {
            string serverVal = this.Server;
            string userNameVal = this.UserName;
            string passwordVal = this.Password;
            string databaseVal = this.Database;
            string serverVar = this.GetServerVar();
            string userNameVar = this.GetUserNameVar();
            string passwordVar = this.GetPasswordVar();
            string databaseVar = this.GetDatabaseVar();

            string connStr = this.GetNameValuePair(serverVar, serverVal);
            connStr += this.GetNameValuePair(userNameVar, userNameVal);
            connStr += this.GetNameValuePair(passwordVar, passwordVal);
            connStr += this.GetNameValuePair(databaseVar, databaseVal);

            return connStr;
        }

        /// <summary>
        /// Gets the string representation of the database connection info object.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string representation = this.ToConnectionString();

            return representation;
        }
    }
}
