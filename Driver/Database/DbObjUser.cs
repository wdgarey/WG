using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

using WG.Database;
using WG.Database.Attributes;

namespace Driver.Database
{
    /// <summary>
    /// A user database object.
    /// </summary>
    public class DbObjUser : DbObj
    {
        /// <summary>
        /// The user name.
        /// </summary>
        private string name;

        /// <summary>
        /// The user password.
        /// </summary>
        private string password;

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public virtual string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        public virtual string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        /// <summary>
        /// Creates an instance of a database user object.
        /// </summary>
        /// <param name="dci">The database connection information.</param>
        /// <param name="name">The user name.</param>
        public DbObjUser(DbConnectionInfo dci, string name)
            : base(dci)
        {
            this.Name = name;
            this.Password = null;
        }

        /// <summary>
        /// Gets and returns the name of the table that the database object is stored on.
        /// </summary>
        /// <returns>The name.</returns>
        protected override string GetTableName()
        {
            return "user";
        }

        /// <summary>
        /// Gets and returns the I.D. of the databause user object.
        /// </summary>
        /// <returns>The I.D.</returns>
        protected override SqlAttribute GetMyId()
        {
            string name = this.Name;
            string table = this.GetTableName();

            SqlAttribute myId = new SqlAttribute("Name", table, name);

            return myId;
        }

        /// <summary>
        /// Gets the attributes of the database user object.
        /// </summary>
        /// <returns>The attributes.</returns>
        protected override List<SqlAttribute> GetAttributes()
        {
            string name = this.Name;
            string password = this.Password;

            string table = this.GetTableName();
            SqlAttribute nameAttr = new SqlAttribute("Name", table, name);
            SqlAttribute passwordAttr = new SqlAttribute("Password", table, password);

            List<SqlAttribute> attributes = new List<SqlAttribute>() { nameAttr, passwordAttr };

            return attributes;
        }

        /// <summary>
        /// Sets the attributes of the database user object.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        protected override void SetAttributes(List<SqlAttribute> attributes)
        {
            string table = this.GetTableName();
            SqlAttribute name = new SqlAttribute("Name", table);
            SqlAttribute password = new SqlAttribute("Password", table);

            foreach(SqlAttribute attribute in attributes)
            {
                object attrValue = attribute.Value;

                if(attribute.IsEqual(name))
                {
                    this.Name = Convert.ToString(attrValue);
                }
                else if (attribute.IsEqual(password))
                {
                    this.Password = Convert.ToString(attrValue);
                }
            }
        }

        /// <summary>
        /// Encrypts the password using sha1 encryption.
        /// </summary>
        public virtual void EncryptPw()
        {
            string password = this.Password;

            byte[] byteArray = Encoding.ASCII.GetBytes(password);

            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] hashedPasswordBytes = sha.ComputeHash(byteArray);

            this.Password = BitConverter.ToString(hashedPasswordBytes).Replace("-", "").ToLower();
        }
    }
}
