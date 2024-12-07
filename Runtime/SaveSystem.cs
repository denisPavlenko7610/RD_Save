using System.IO;
using UnityEngine;

namespace _Packages.RD_Save.Runtime
{
    public class SaveSystem
    {
        private readonly IDataSerializer _serializer;
            //private readonly SaveFormat _saveFormat;
        private readonly string _savePath;
        
        public SaveSystem(IDataSerializer serializer, SaveFormat saveFormat, string savePath)
        {
            _serializer = serializer;
            //_saveFormat = saveFormat;
            _savePath = Path.Combine(Application.persistentDataPath, savePath + SaveSystemFactory.GetFileExtension(saveFormat));
        }

        public void Save<T>(T data)
        {
            string directory = Path.GetDirectoryName(_savePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            using (var stream = File.Open(_savePath, FileMode.Create))
            {
                _serializer.Serialize(data, stream);
            }
        }

        public T Load<T>() 
        {
            if (!File.Exists(_savePath))
            {
                Debug.Log("File not found: " + _savePath);
                return default(T);
            }

            using (var stream = File.OpenRead(_savePath))
            {
                return _serializer.Deserialize<T>(stream);
            }
        }
    }
}