using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Peiton.Serialization;

public static class XmlSerializationExtensions
{
    public static XDocument? ToXDocument(this object? obj)
    {
        if (obj == null) return null;
        string? xml = null;
        var serializer = new XmlSerializer(obj.GetType());

        using (MemoryStream ms = new MemoryStream())
        {
            serializer.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            using (StreamReader reader = new StreamReader(ms, Encoding.UTF8))
            {
                xml = reader.ReadToEnd();
            }
        }

        return XDocument.Parse(xml);
    }

    public static T? Deserialize<T>(this string? obj) where T : class
    {
        if (obj == null) return null;

        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (var sr = new StringReader(obj))
        {
            using (var reader = XmlReader.Create(sr))
            {
                return serializer.Deserialize(reader) as T;
            }
        }
    }
}