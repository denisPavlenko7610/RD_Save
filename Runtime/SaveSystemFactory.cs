using System;

namespace RD_Save.Runtime
{
    public class SaveSystemFactory
    {
        public static IDataSerializer GetSerializer(SaveFormat type)
        {
            return type switch
            {
                SaveFormat.JSON => new JsonSerializer(),
                SaveFormat.Binary => new BinarySaveSerializer(),
                SaveFormat.XML => new XmlSaveSerializer(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public static string GetFileExtension(SaveFormat type)
        {
            return type switch
            {
                SaveFormat.JSON => ".json",
                SaveFormat.Binary => ".bin",
                SaveFormat.XML => ".xml",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}