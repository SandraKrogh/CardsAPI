using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendAPI.Models
{
    public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [JsonPropertyName("collectibleCount")]
        public int CardCount { get; set; }
    }
}
