using System;

namespace LiftTracker
{
    /// <summary>
    /// An XML attribute name-value pair.
    /// </summary>
    public class XmlAttribute
    {
        /// <summary>
        /// The name of the attribute.
        /// </summary>
        private string name;

        /// <summary>
        /// The value of the attribute.
        /// </summary>
        private string value;

        /// <summary>
        /// Gets or sets the name of the attribute.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the value of the attribute.
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Creates an instance of an XmlAttribute.
        /// </summary>
        public XmlAttribute()
        {
            this.Name = "";
            this.Value = "";
        }

        /// <summary>
        /// Creates an instance of an XmlAttribute.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public XmlAttribute(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Creates an instance of an XmlAttribute.
        /// </summary>
        /// <param name="nameValPair">The string representation.</param>
        public XmlAttribute(string nameValPair)
        {
            this.FromString(nameValPair);
        }

        /// <summary>
        /// Gets the separator string of the name-value pair.
        /// </summary>
        /// <returns>The separator string.</returns>
        public virtual char GetSeparator()
        {
            return '-';
        }

        /// <summary>
        /// Sets the values of the of attribute given the string representation.
        /// </summary>
        /// <param name="nameValPair">The string representation.</param>
        public virtual void FromString(string nameValPair)
        {
            char separator = this.GetSeparator();

            string[] contents = nameValPair.Split(separator);

            if (contents.Length != 2)
            {
                throw new Exception("Invalid string representation given.");
            }

            string name = contents[0];
            string value = contents[1];

            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets the string representation of the XmlAttribute.
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            string name = this.Name;
            string value = this.Value;
            char separator = this.GetSeparator();

            string representation = name + separator + value;

            return representation;
        }
    }
}
