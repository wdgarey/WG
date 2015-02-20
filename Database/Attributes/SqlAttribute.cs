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
        /// Gets or sets the name of the attribute.
        /// </summary>
        public override string Name
        {
            get
            {
                string name = base.Name;

                if(this.HasTable())
                {
                    string table = this.Table;
                    string separatorStr = this.GetTableNameSepStr();

                    name = table + separatorStr + name;
                }
                    return name;
            }
            set { base.Name = value; }
        }

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
        /// Indicates whether or not the SQL attribute has a table.
        /// </summary>
        /// <returns>True, if the SQL attribute has a table.</returns>
        public virtual bool HasTable()
        {
            string table = this.Table;
            bool hasTable = (table != null);

            return hasTable;
        }
    }
}
