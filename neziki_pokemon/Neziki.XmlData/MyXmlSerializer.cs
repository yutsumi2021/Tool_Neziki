using System.IO;
using System.Xml.Serialization;

namespace Neziki.XmlData
{
    public static class MyXmlSerializer
    {
        public static T DeserializeFromString<T>(string text)
        {
            using(FileStream file = new FileStream(text, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(file);
            }
        }
    }
}
