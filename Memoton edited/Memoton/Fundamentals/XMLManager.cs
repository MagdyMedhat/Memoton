using System;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace Memoton.Fundamentals
{
    public class XMLManager
    {
        /// <summary>
        /// Writes the Object to the specified file in XNA format.
        /// Note that it only writes public data members unless with [ContentSerializer] tag.
        /// Editor Note: Remember the Microsoft.Xna.Framework.Content.Pipeline Reference.
        /// </summary>
        /// <param name="xObject">The object to be written.</param>
        /// <param name="FilePath">Location of file to be written.</param>
        public void WriteToXml(Object xObject, string FilePath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(FilePath, settings))
            { IntermediateSerializer.Serialize(writer, xObject, null); }
        }

        /// <summary>
        /// Reads an object from the specified file in XNA format.
        /// Remember to cast it to its original type using (Type) cast.
        /// </summary>
        /// <param name="FilePath">Location of file to read from.</param>
        /// <returns></returns>
        public Object ReadFromXml(string FilePath)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            using (XmlReader reader = XmlReader.Create(FilePath))
            { return IntermediateSerializer.Deserialize<Object>(reader, FilePath); }
        }
    }
}
