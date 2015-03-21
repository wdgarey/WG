using System;
using System.Text;
using System.Collections.Generic;

using WG.Database.Attributes;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents a values clause.
    /// </summary>
    public class ValuesClause : Clause
    {
        /// <summary>
        /// The collection of values.
        /// </summary>
        private List<Values> values;

        /// <summary>
        /// Gets or sets the collection of values.
        /// </summary>
        public virtual List<Values> Values
        {
            get { return this.values; }
            set { this.values = value; }
        }

        /// <summary>
        /// Creates an instance of a value clause.
        /// </summary>
        /// <param name="attributes">The attributes of the clause.</param>
        public ValuesClause(List<SqlAttribute> attributes)
            : base("VALUES")
        {
            this.Values = new List<Values>() { new Values(attributes) };
        }

        /// <summary>
        /// Gets the value seperator string.
        /// </summary>
        /// <returns>The separator string.</returns>
        protected virtual string GetSeparatorStr()
        {
            return ",";
        }

        /// <summary>
        /// Gets the opening delimiter string.
        /// </summary>
        /// <returns>The open delimiter.</returns>
        protected virtual string GetOpenDelimiterStr()
        {
            return "";
        }

        /// <summary>
        /// Gets the closing delimiter string.
        /// </summary>
        /// <returns>The closing delimiter.</returns>
        protected virtual string GetCloseDelimiterStr()
        {
            return "";
        }

        /// <summary>
        /// Creates a string representation of the values clause.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            string keyWord = this.KeyWord;
            List<Values> values = this.Values;
            string separatorStr = this.GetSeparatorStr();

            StringBuilder sb = new StringBuilder(keyWord);
            sb.Append(" ");

            foreach(Values value in values)
            {
                sb.Append(value);
                sb.Append(separatorStr);
            }

            sb.Remove(sb.Length - separatorStr.Length, separatorStr.Length);

            return sb.ToString();
        }

        /// <summary>
        /// Adds the values to the collection.
        /// </summary>
        /// <param name="values">The values to add.</param>
        public virtual void AddValues(Values values)
        {
            List<Values> myValues = this.Values;

            myValues.Add(values);
        }

        /// <summary>
        /// Removes the values from the collection.
        /// </summary>
        /// <param name="values">The values to remove.</param>
        /// <returns>True, if the values were found and removed.</returns>
        public virtual bool RemoveValues(Values values)
        {
            List<Values> myValues = this.Values;

            bool success = myValues.Remove(values);

            return success;
        }
    }
}
