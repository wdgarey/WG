using System;

namespace WG.Database.Attributes
{
    /// <summary>
    /// An object used to represent an attribute.
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// The name of the attribute.
        /// </summary>
        private string name;

        /// <summary>
        /// The value of the attribute.
        /// </summary>
        private object value;

        /// <summary>
        /// Gets or sets the name of the attribute.
        /// </summary>
        public virtual string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the value of the attribute.
        /// </summary>
        public virtual object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Creates an instance of an attribute.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        public Attribute(string name)
        {
            this.Name = name;
            this.Value = null;
        }

        /// <summary>
        /// Creates an instance of an attribute.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public Attribute(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets the name value separator string.
        /// </summary>
        /// <returns>The separator string.</returns>
        protected virtual string GetNameValueSepStr()
        {
            return " = ";
        }

        /// <summary>
        /// Indicates whether or not the attribute has a value.
        /// </summary>
        /// <returns>True, if the attribute has a value.</returns>
        public virtual bool HasValue()
        {
            object value = this.Value;
            bool hasValue = (value != null);

            return hasValue;
        }

        /// <summary>
        /// Gets the string representation of the attribute.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string representation = this.Name;

            if (this.HasValue())
            {
                object value = this.Value;
                string separatorStr = this.GetNameValueSepStr();

                representation += separatorStr + value;
            }

            return representation;
        }
    }
}
