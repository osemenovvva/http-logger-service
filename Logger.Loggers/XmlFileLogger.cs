using System.Xml;
using System.Xml.Linq;

namespace Logger.Loggers
{
    public class XmlFileLogger : ILogger
    {
        public void ExecuteSaveLog(Guid id, DateTime date, string text)
        {
            string xmlLog = id + " " + date + " " + text;
            string xmlPath = @"..\logger.main\logs\log.xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            if (File.Exists(xmlPath))
            {
                XDocument xmlDoc = XDocument.Load(xmlPath);
                XElement root = new XElement("Log", 
                    new XAttribute("Id", id),
                    new XAttribute("Date", date),
                    new XAttribute("Text", text));
                xmlDoc.Root.Add(root);
                xmlDoc.Save(xmlPath);
            }
            else
            {
                using (XmlWriter writer = XmlWriter.Create(xmlPath, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Log");
                    writer.WriteAttributeString("Id", id.ToString());
                    writer.WriteAttributeString("Date", date.ToString());
                    writer.WriteAttributeString("Text", text);
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.WriteEndDocument();
                }
            }
        }
    }
}
