using BackendAPI.Models;
using MongoDB.Driver;
using System.Text.Json;

namespace BackendAPI.Services
{
    public class MongoService
    {
        private readonly MongoClient _client;
        public MongoService()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            var db = _client.GetDatabase("CardsAPI");
            if (_client.GetDatabase("CardsAPI").ListCollections().ToList().Count == 0)
            {
                var collection = db.GetCollection<Card>("cards");
                foreach (var path in new[] { "metadata.json", "cards.json"})
                {
                    using (var file = new StreamReader(path))
                    {
                        var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        collection.InsertMany(cards);
                    }
                }
            }
        }
        public MongoClient Client
        {
            get
            {
                return _client;

            }
        }
    }
}
