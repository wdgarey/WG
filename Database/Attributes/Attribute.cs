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
        /// Gets the value delimiter for an SQL attribute.
        /// </summary>
        /// <returns>The value deliter.</returns>
        protected virtual string GetValueDelimterStr()
        {
            return "'";
        }

        /// <summary>
        /// Indicates whether or not the name of the given attribute is the same as this one.
        /// </summary>
        /// <param name="attribute">The given attribute.</param>
        /// <returns>True, if the name is equal.</returns>
        protected virtual bool IsNameEqual(Attribute attribute)
        {
            string myName = this.Name;
            string theirName = attribute.Name;

            bool isEqual = myName.Equals(theirName);

            return isEqual;
        }

        /// <summary>
        /// Indicates whether or not the value of the given attribute is the same as this one.
        /// </summary>
        /// <param name="attribute">The given attribute.</param>
        /// <returns>True, if the value is equal.</returns>
        protected virtual bool IsValueEqual(Attribute attribute)
        {
            object myValue = this.Value;
            object theirValue = attribute.Value;

            bool isEqual = myValue.Equals(theirValue);

            return isEqual;
        }

        /// <summary>
        /// Gets the string representation of the value.
        /// </summary>
        /// <returns>The string representation.</returns>
        public virtual string GetValueStr()
        {
            object value = this.Value;
            string valueStr = value.ToString();
            string valueDelimStr = this.GetValueDelimterStr();

            if (value is ValueType || value is string)
            {
                valueStr = valueDelimStr + valueStr + valueDelimStr;
            }

            return valueStr;
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
        /// Indicates whether or not the given attribute is the same.
        /// </summary>
        /// <param name="attribute">The given attribute.</param>
        /// <returns>True, if the given attribute is the same.</returns>
        public virtual bool IsEqual(Attribute attribute)
        {
            bool isEqual = this.IsNameEqual(attribute);

            return isEqual;
        }

        /// <summary>
        /// Indicates whether or not the given attribute is exactly the same.
        /// </summary>
        /// <param name="attribute">The given attribute.</param>
        /// <returns>True, if the given attribute is exactly the same.</returns>
        public virtual bool IsExactEqual(Attribute attribute)
        {
            bool isExactEqual = (this.IsNameEqual(attribute) && this.IsValueEqual(attribute));

            return isExactEqual;
        }

        /// <summary>
        /// Clears the currently stored value.
        /// </summary>
        public virtual void ClearValue()
        {
            this.Value = null;
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
                string valueStr = this.GetValueStr();
                string separatorStr = this.GetNameValueSepStr();
                
                representation += separatorStr + valueStr;
            }

            return representation;
        }
    }
}
