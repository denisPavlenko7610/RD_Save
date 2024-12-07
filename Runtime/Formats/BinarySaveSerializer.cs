using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Packages.RD_Save.Runtime
{
    public class BinarySaveSerializer : IDataSerializer
    {
        public void Serialize<T>(T data, Stream stream)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }

        public T Deserialize<T>(Stream stream)
        {
            var formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(stream);
        }
    }
}