using System;

namespace WG.Database.Attributes
{
    /// <summary>
    /// An object that represents a SQL attribute.
    /// </summary>
    public class SqlAttribute : Attribute
    {
        /// <summary>
        /// The name of the table.
        /// </summary>
        private string table;

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        public virtual string Table
        {
            get { return this.table; }
            set { this.table = value; }
        }

        /// <summary>
        /// Creates an instance of a SQL attribute.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        public SqlAttribute(string name)
            : base(name)
        {
            this.Name = null;
        }

        /// <summary>
        /// Creates an instance of a SQL attribute.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="table">The name of the table that the attribute belongs to.</param>
        public SqlAttribute(string name, string table)
            : base(name)
        {
            this.Table = table;
        }

        /// <summary>
        /// Creates an instance of a SQL attribute.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="table">The name of the table that the attribute belongs to.</param>
        /// <param name="value">The value of the attribute.</param>
        public SqlAttribute(string name, string table, object value)
            : base(name, value)
        {
            this.Table = table;
        }

        /// <summary>
        /// The separator string of a table and a column name.
        /// </summary>
        /// <returns>The separator string.</returns>
        protected virtual string GetTableNameSepStr()
        {
            return ".";
        }

        /// <summary>
        /// Adds the table name to the beginning of the given string.
        /// </summary>
        /// <param name="str">The given string.</param>
        /// <returns>The prepended string.</returns>
        protected virtual string PrependTableName(string str)
        {
            if (this.HasTable())
            {
                string table = this.Table;
                string separatorStr = this.GetTableNameSepStr();

                str = table + separatorStr + str;
            }

            return str;
        }

        /// <summary>
        /// Indicates whether or not the SQL attribute has a table.
        /// </summary>
        /// <returns>True, if the SQL attribute has a table.</returns>
        public virtual bool HasTable()
        {
            string table = this.Table;
            bool hasTable = (table != null);

            return hasTable;
        }

        /// <summary>
        /// Creates and returns the full name of the SQL attribute.
        /// </summary>
        /// <returns>The full name.</returns>
        public virtual string GetFullName()
        {
            string name = this.Name;

            string fullName = this.PrependTableName(name);

            return fullName;
        }

        /// <summary>
        /// Creates and returns the string representation of the SQL attribute.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string representation = base.ToString();

            this.PrependTableName(representation);

            return representation;
        }
    }
}
