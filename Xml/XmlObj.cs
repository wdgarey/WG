using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace LiftTracker
{
    /// <summary>
    /// An object that can be represented using XML.
    /// </summary>
    public abstract class XmlObj
    {
        /// <summary>
        /// Creates an instance of an XmlObj.
        /// </summary> 
        public XmlObj()
        { }

        /// <summary>
        /// Creates an XmlObj from the current position of the given reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public XmlObj(XmlTextReader reader)
        {
            this.FromXml(reader);
        }

        /// <summary>
        /// Gets the tag name of the XmlObj.
        /// </summary>
        /// <returns>The tag name.</returns>
        protected abstract string GetTagName();

        /// <summary>
        /// Reads any inner XmlObjs of the XmlObj.
        /// </summary>
        /// <param name="reader">The reader to use.</param>
        protected abstract void ReadInnerXmlObjs(XmlTextReader reader);

        /// <summary>
        /// Writes any inner XmlObjs of the XmlObj.
        /// </summary>
        /// <param name="writer">The writer to use.</param>
        protected abstract void WriteInnerXmlObjs(XmlTextWriter writer);

        /// <summary>
        /// Gets the attributes for the XmlObj.
        /// </summary>
        /// <returns>The collection of attributes.</returns>
        protected abstract List<XmlAttribute> GetAttributes();

        /// <summary>
        /// Sets the attributes of the XmlObj.
        /// </summary>
        /// <param name="attributes">The collection of attributes.</param>
        protected abstract void SetAttributes(List<XmlAttribute> attributes);

        /// <summary>
        /// Reads the xml string representation of the XmlObj from the current position of the given reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public virtual void FromXml(XmlTextReader reader)
        {
            string tagName = this.GetTagName();
            List<XmlAttribute> attributes = this.GetAttributes();

            reader.Read();
            reader.ReadStartElement(tagName);

            foreach (XmlAttribute attribute in attributes)
            {   
                string name = attribute.Name;

                string value = reader.ReadElementString(name);

                attribute.Value = value;
            }

            this.SetAttributes(attributes);

            this.ReadInnerXmlObjs(reader);

            reader.ReadEndElement();
        }

        /// <summary>
        /// Writes the XML string representation of the XmlObj to the current position of the given writer.
        /// </summary>
        /// <param name="writer">The given writer.</param>
        public virtual void ToXml(XmlTextWriter writer)
        {
            string tagName = this.GetTagName();
            List<XmlAttribute> attributes = this.GetAttributes();

            writer.WriteStartElement(tagName);

            foreach (XmlAttribute attribute in attributes)
            {
                string name = attribute.Name;
                string value = attribute.Value;

               writer.WriteElementString(name, value);
            }

            this.WriteInnerXmlObjs(writer);

            writer.WriteEndElement();
        }

        /// <summary>
        /// Returns a string that represents the XmlObj.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(sw);

            this.ToXml(writer);

            string representation = sw.ToString();
            
            sw.Close();
            sw.Dispose();

            return representation;
        }
    }
}
