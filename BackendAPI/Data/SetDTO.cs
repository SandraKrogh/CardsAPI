using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BackendAPI.Data
{
    public class SetDTO
    {
        public String Name { get; set; }
        public String Type { get; set; }

        [JsonPropertyName("collectibleCount")]
        public int CardCount { get; set; }
    }
}
