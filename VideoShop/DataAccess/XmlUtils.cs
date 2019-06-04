using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Owasp.Data
{
    public class XmlUtils
    {
       public static string ReadXml(string markup, long maxChars)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.MaxCharactersFromEntities = maxChars;

            StringBuilder sb = new StringBuilder();

            try
            {
                XmlReader reader = XmlReader.Create(new StringReader(markup), settings);
                while (reader.Read()) {
                    //if (reader.NodeType == XmlNodeType.Element)
                    //{
                    //    sb.Append(reader.Name);
                    //}
                }

                return "success" + sb.ToString();
            }
            catch (XmlException ex)
            {
                return ex.Message;
            }
        }
    }
}
