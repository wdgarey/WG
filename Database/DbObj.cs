using System;
using System.Data;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

using WG.Database.Clauses;
using WG.Database.Attributes;
using WG.Database.Statements;
using WG.Database.Attributes.Conditions;

namespace WG.Database
{
    /// <summary>
    /// An object that can be stored to a database.
    /// </summary>
    public abstract class DbObj
    {
        /// <summary>
        /// The owner of the current object.
        /// </summary>
        private DbObj owner;

        /// <summary>
        /// The database connection information to use.
        /// </summary>
        private DbConnectionInfo dci;

        /// <summary>
        /// Gets or sets the owner of the current object.
        /// </summary>
        public virtual DbObj Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        /// <summary>
        /// Gets or sets the database connection information to use.
        /// </summary>
        public virtual DbConnectionInfo Dci
        {
            get { return this.dci; }
            set { this.dci = value; }
        }

        /// <summary>
        /// Creates an instance of a database object.
        /// </summary>
        /// <param name="dci">The database connection information to use.</param>
        public DbObj(DbConnectionInfo dci)
            : this(dci, null)
        {
            this.Dci = dci;
        }

        /// <summary>
        /// Creates an instance of a database object.
        /// </summary>
        /// <param name="dci">The database connection information to use.</param>
        /// <param name="owner">The owner of the current object.</param>
        public DbObj(DbConnectionInfo dci, DbObj owner)
        {
            this.Owner = owner;
            this.Dci = dci;
        }

        /// <summary>
        /// Gets the connection object used to modify the database.
        /// </summary>
        /// <returns>The connection.</returns>
        protected virtual MySqlConnection GetConnection()
        {
            DbConnectionInfo dci = this.Dci;
            string connectionString = dci.ToConnectionString();

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }

        /// <summary>
        /// Get the collection of attributes that are used as the object's unique I.D.
        /// </summary>
        /// <returns>The collection of attributes.</returns>
        protected List<SqlAttribute> GetOwnerIds()
        {
            List<SqlAttribute> ids = new List<SqlAttribute>();

            for(DbObj owner = this.Owner; owner != null; owner = owner.Owner)
            {
                SqlAttribute id = owner.GetMyId();

                ids.Add(id);
            }

            return ids;
        }
        /// <summary>
        /// Creates and returns the select clause for the database object.
        /// </summary>
        /// <returns>The select clause.</returns>
        protected virtual SelectClause CreateSelectClause()
        {
            List<SqlAttribute> attributes = this.GetAttributes();

            SelectClause clause = new SelectClause(attributes);

            return clause;
        }

        /// <summary>
        /// Creates and returns a from clause for the database object.
        /// </summary>
        /// <returns>The from clause.</returns>
        protected virtual FromClause CreateFromClause()
        {
            string table = this.GetTableName();

            FromClause clause = new FromClause(table);

            return clause;
        }

        /// <summary>
        /// Creates and returns a where clause for the database object.
        /// </summary>
        /// <returns>The where clause.</returns>
        protected virtual WhereClause CreateWhereClause()
        {
            SqlAttribute myId = this.GetMyId();            
            WhereClause clause = new WhereClause(myId);
            List<SqlAttribute> ownerIds = this.GetOwnerIds();

            foreach(SqlAttribute id in ownerIds)
            {
                AndCondition condition = new AndCondition(id);

                clause.Add(condition);
            }

            return clause;
        }

        /// <summary>
        /// Creates an returns the select statement for the object.
        /// </summary>
        /// <returns>The select statement.</returns>
        protected virtual SelectStatement CreateSelectStatement()
        {
            SelectClause select = this.CreateSelectClause();
            FromClause from = this.CreateFromClause();
            WhereClause where = this.CreateWhereClause();

            SelectStatement statement = new SelectStatement(select, from, where);

            return statement;
        }

        /// <summary>
        /// Indicates whether or not the current database object has an owner.
        /// </summary>
        /// <returns>True, if the current database object has an owner.</returns>
        public virtual bool HasOwner()
        {
            DbObj owner = this.Owner;

            bool hasOwner = (owner != null);

            return hasOwner;
        }

        /// <summary>
        /// Loads the database object from the database using it's I.D..
        /// </summary>
        /// <returns>True, on success.</returns>
        public virtual bool Select()
        {
            DbConnectionInfo dci = this.Dci;
            string table = this.GetTableName();
            SelectStatement statement = this.CreateSelectStatement();
            List<SqlAttribute> attributes = new List<SqlAttribute>();

            DataTable dt = statement.Execute(dci);
            DataRow dr = dt.Rows[0];
            
            foreach(DataColumn dc in dt.Columns)
            {
                object value = dr[dc];

                SqlAttribute attribute = new SqlAttribute(dc.ColumnName, table, value);

                attributes.Add(attribute);
            }

            this.SetAttributes(attributes);

            return true;
        }

        /// <summary>
        /// Inserts the database object to the database using it's I.D..
        /// </summary>
        /// <returns>True, on success.</returns>
        public virtual bool Insert()
        {
            return true;
        }

        /// <summary>
        /// Updates the database object on the database using it's I.D..
        /// </summary>
        /// <returns>True, on success.</returns>
        public virtual bool Update()
        {
            return true;
        }

        /// <summary>
        /// Deletes the database object from the database using it's I.D..
        /// </summary>
        /// <returns>True, on success.</returns>
        public virtual bool Delete()
        {
            return true;
        }

        /// <summary>
        /// Gets the name of the table that the object is stored on.
        /// </summary>
        /// <returns>The table name.</returns>
        protected abstract string GetTableName();

        /// <summary>
        /// Gets the local (or immediate) I.D. of the database object.
        /// </summary>
        /// <returns>The local I.D.</returns>
        protected abstract SqlAttribute GetMyId();

        /// <summary>
        /// Gets the collection of attributes that should be stored for the object.
        /// </summary>
        /// <returns>The collection of attributes.</returns>
        protected abstract List<SqlAttribute> GetAttributes();

        /// <summary>
        /// Sets the data members of the object given the collection of attributes.
        /// </summary>
        /// <param name="attributes">The collection of attributes.</param>
        protected abstract void SetAttributes(List<SqlAttribute> attributes);
    }
}
