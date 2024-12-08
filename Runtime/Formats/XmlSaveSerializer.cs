using System.IO;
using System.Xml.Serialization;

namespace RD_Save.Runtime
{
    public class XmlSaveSerializer : IDataSerializer
    {
        public void Serialize<T>(T data, Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, data);
        }

        public T Deserialize<T>(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }
    }
}