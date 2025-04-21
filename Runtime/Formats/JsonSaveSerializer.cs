using System.Globalization;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace RD_Save.Runtime
{
    public class JsonSerializer : IDataSerializer
    {
        private readonly JsonSerializerSettings _settings = new()
        {
            Culture = CultureInfo.InvariantCulture
        };

        public void Serialize<T>(T data, Stream stream)
        {
            using var writer = new StreamWriter(stream);
            string json = JsonConvert.SerializeObject(data, _settings);
            writer.Write(json);
        }

        public T Deserialize<T>(Stream stream)
        {
            using StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();
            if (string.IsNullOrWhiteSpace(json))
            {
                Debug.LogError("Deserialization failed");
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(json, _settings);
        }
    }
}