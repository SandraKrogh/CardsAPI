using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendAPI.Models
{
    public class Rarity
    {

        public int Id { get; set; }
        public String Name { get; set; }
    }
}
