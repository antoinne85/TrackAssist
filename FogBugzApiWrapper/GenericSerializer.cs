using System.IO;
using System.Xml.Serialization;

namespace FogBugzApiWrapper
{
    public class GenericSerializer : IGenericSerializer   
    {
        public string Serialize<T>(T objectToSerialize)
        {
            using(var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                var serializer = GetSerializer<T>();
                serializer.Serialize(streamWriter, objectToSerialize);
                memoryStream.Position = 0;
                using (var streamReader = new StreamReader(memoryStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public T Deserialize<T>(Stream streamToDeserialize) where T : class
        {
            var serializer = GetSerializer<T>();
            var result = serializer.Deserialize(streamToDeserialize);
            return result as T;
        }

        private XmlSerializer GetSerializer<T>()
        {
            return new XmlSerializer(typeof(T));
        }
    }

    internal interface IGenericSerializer
    {
        string Serialize<T>(T objectToSerialize);
        T Deserialize<T>(Stream streamToDeserialize) where T : class;
    }
}
