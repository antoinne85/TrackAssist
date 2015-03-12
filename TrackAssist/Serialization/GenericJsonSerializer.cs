using Newtonsoft.Json;

namespace TrackAssist.Serialization
{
    public interface IGenericJsonSerializer
    {
        string Serialize(object objectToSerialize);
        T Deserialize<T>(string json);
    }

    public class GenericJsonSerializer : IGenericJsonSerializer
    {
        public string Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
