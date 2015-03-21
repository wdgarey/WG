using System;
using System.Text;
using System.Collections.Generic;

using WG.Database.Attributes;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents an insert clause.
    /// </summary>
    public class InsertClause : AttributeClause
    {
        /// <summary>
        /// The name of the insert table.
        /// </summary>
        private string table;

        /// <summary>
        /// The values clause of the insert table.
        /// </summary>
        private ValuesClause valuesClause;

        /// <summary>
        /// Gets or sets the name of the insert table.
        /// </summary>
        public virtual string Table
        {
            get { return this.table; }
            set { this.table = value; }
        }

        /// <summary>
        /// Gets or sets the values clause of the insert table.
        /// </summary>
        public virtual ValuesClause ValuesClause
        {
            get { return this.valuesClause; }
            set { this.valuesClause = value; }
        }

        /// <summary>
        /// Creates an instance of an insert clause.
        /// </summary>
        /// <param name="table">The name of the insert table.</param>
        /// <param name="attributes">The attributes being inserted.</param>
        public InsertClause(string table, List<SqlAttribute> attributes)
            : base("INSERT INTO", attributes)
        {
            this.Table = table;
            this.ValuesClause = new ValuesClause(attributes);
        }

        /// <summary>
        /// Gets the separator string for the insert clause.
        /// </summary>
        /// <returns>The separator string.</returns>
        protected override string GetSeparatorStr()
        {
            return ",";
        }

        /// <summary>
        /// Gets the opening delimiter string.
        /// </summary>
        /// <returns>The open delimiter.</returns>
        protected override string GetOpenDelimiterStr()
        {
            return "(";
        }

        /// <summary>
        /// Gets the closing delimiter string.
        /// </summary>
        /// <returns>The closing delimiter.</returns>
        protected override string GetCloseDelimiterStr()
        {
            return ")";
        }

        /// <summary>
        /// Creates a the string representation of the insert clause.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            string table = this.Table;
            string keyWord = this.KeyWord;            
            string sepStr = this.GetSeparatorStr();
            ValuesClause valuesClause = this.ValuesClause;
            string openDelim = this.GetOpenDelimiterStr();
            string closeDelim = this.GetCloseDelimiterStr();            
            List<SqlAttribute> attributes = this.Attributes;
            
            StringBuilder sb = new StringBuilder(keyWord);
            sb.Append(" ");
            sb.Append(table);
            sb.Append(openDelim);

            foreach(SqlAttribute attribute in attributes)
            {
                sb.Append(attribute.Name);
                sb.Append(sepStr);
            }

            sb.Remove(sb.Length - sepStr.Length, sepStr.Length);

            sb.Append(closeDelim);

            sb.Append(" ");

            sb.Append(valuesClause);

            return sb.ToString();
        }

        /// <summary>
        /// Adds values to the clause.
        /// </summary>
        /// <param name="values">The values to add.</param>
        public virtual void AddValues(Values values)
        {
            ValuesClause valuesClause = this.ValuesClause;

            valuesClause.AddValues(values);
        }

        /// <summary>
        /// Removes values from the clause.
        /// </summary>
        /// <param name="values">The values to remove.</param>
        /// <returns>True, if the values were found and removed.</returns>
        public virtual bool RemoveValues(Values values)
        {
            ValuesClause valuesClause = this.ValuesClause;

            bool success = valuesClause.RemoveValues(values);

            return success;
        }
    }
}
