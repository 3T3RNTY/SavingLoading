using System.Xml;
using System.Xml.Serialization;

void item<T>(T item, string fileName)
{
    if (item == null) { return; }

    try
    {
        XmlDocument xmlDocument = new XmlDocument();
        XmlSerializer serializer = new XmlSerializer(item.GetType());

        using (MemoryStream stream = new MemoryStream())
        {
            serializer.Serialize(stream, item);
            stream.Position = 0;
            xmlDocument.Load(stream);
            xmlDocument.Save(fileName);
            stream.Close();
        }
    }
    catch (Exception ex)
    {

    }
}