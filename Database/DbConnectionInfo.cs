using System.Text;
using System.Collections.Generic;

using WG.Database.Attributes;

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
        /// Creates an instance of Db Connection Info.
        /// </summary>
        /// <param name="server">The server that the database is on.</param>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="database">The name of the database.</param>
        public DbConnectionInfo(string server, string userName, string password, string database)
        {
            this.Server = server;
            this.UserName = userName;
            this.Password = password;
            this.Database = database;
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
        /// Gets the collection of connection attributes.
        /// </summary>
        /// <returns>The collection of connection attributes.</returns>
        protected virtual List<Attribute> GetAttributes()
        {
            string serverVal = this.Server;
            string userNameVal = this.UserName;
            string passwordVal = this.Password;
            string databaseVal = this.Database;
            string serverVar = this.GetServerVar();
            string userNameVar = this.GetUserNameVar();
            string passwordVar = this.GetPasswordVar();
            string databaseVar = this.GetDatabaseVar();
            List<Attribute> attributes = new List<Attribute>();

            attributes.Add(new Attribute(serverVal, serverVar));
            attributes.Add(new Attribute(userNameVal, userNameVar));
            attributes.Add(new Attribute(passwordVal, passwordVar));
            attributes.Add(new Attribute(databaseVal, databaseVar));

            return attributes;
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>The connection string.</returns>
        public virtual string ToConnectionString()
        {
            string connStr = "";
            char separatorChar = this.GetSeparatorChar();
            List<Attribute> attributes = this.GetAttributes();

            foreach (Attribute attribute in attributes)
            {
                connStr += attribute.ToString() + separatorChar;
            }

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
