using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MyXMLData;

namespace Dania_Defence_Project
{
    public static class MadeXml
    {
        public static void MadeNewXml<T>(string name, T type)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(name + ".xml", settings))
            {
                IntermediateSerializer.Serialize(writer, type, null);
            }
        }
}
}
