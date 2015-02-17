using System;
using System.Text;
using System.Collections.Generic;

using WG.Database.Attributes;
using WG.Database.Attributes.Conditions;

namespace WG.Database.Clauses
{
    /// <summary>
    /// An object that represents the WHERE clause of an SQL statement.
    /// </summary>
    public class WhereClause : AttributeClause
    {
        /// <summary>
        /// The collection of additional conditions to use in the WHERE clause.
        /// </summary>
        private List<Condition> additionalConditions;

        /// <summary>
        /// Gets or sets the collection of additional conditions to use in the WHERE clause.
        /// </summary>
        public virtual List<Condition> AdditionalConditions
        {
            get { return this.additionalConditions; }
            set { this.additionalConditions = value; }
        }

        /// <summary>
        /// Creates an instance of a WHERE clause.
        /// </summary>
        /// <param name="attribute">The first attribute in the WHERE clause.</param>
        public WhereClause(SqlAttribute attribute)
            : base("WHERE", attribute)
        {
            this.AdditionalConditions = new List<Condition>();
        }

        /// <summary>
        /// Indiciates whether or no there are additional conditions in the WHERE clause.
        /// </summary>
        /// <returns>True, if there are additional conditions in the WHERE clause.</returns>
        protected virtual bool HasAdditionalConditions()
        {
            List<Condition> additionalConditions = this.AdditionalConditions;
            bool hasAdditionalConditions = (additionalConditions != null && additionalConditions.Count > 0);

            return hasAdditionalConditions;
        }

        /// <summary>
        /// Gets and returns the separator string of a condition.
        /// </summary>
        /// <returns>THe separator string.</returns>
        protected override string GetSeparatorStr()
        {
            return "";
        }

        /// <summary>
        /// Creates a string representation of the WHERE clause.
        /// </summary>
        /// <returns>The string representation.</returns>
        protected override string CreateString()
        {
            string representation = base.CreateString();

            if (this.HasAdditionalConditions())
            {
                List<Condition> conditions = this.AdditionalConditions;
                StringBuilder sb = new StringBuilder(representation);
                
                foreach(Condition condition in conditions)
                {
                    sb.Append(" ");
                    sb.Append(condition.ToString());
                }

                representation = sb.ToString();
            }

            return representation;
        }

        /// <summary>
        /// Adds an additional condition to the WHERE clause.
        /// </summary>
        /// <param name="condition">The additional condition.</param>
        public void Add(Condition condition)
        {
            List<Condition> conditions = this.AdditionalConditions;

            conditions.Add(condition);
        }

        /// <summary>
        /// Removes an additional condition from the WHERE clause.
        /// </summary>
        /// <param name="condition">The additional condition to remove.</param>
        /// <returns>True, if the condition was found and removed.</returns>
        public bool Remove(Condition condition)
        {
            List<Condition> conditions = this.AdditionalConditions;

            bool success = conditions.Remove(condition);

            return success;
        }
    }
}
