using System.IO;

namespace RD_Save.Runtime
{
    public interface IDataSerializer
    {
        void Serialize<T>(T data, Stream stream);
        T Deserialize<T>(Stream stream);
    }
}