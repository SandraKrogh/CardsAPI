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
                var collectionCard = db.GetCollection<Card>("Card");
                foreach (var path in new[] { "cards.json"})
                {
                    using (var file = new StreamReader(path))
                    {
                        var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        collectionCard.InsertMany(cards);
                    }
                }

                var collectionSet = db.GetCollection<Set>("Set");
                foreach (var path in new[] { "sets.json" })
                {
                    using (var file = new StreamReader(path))
                    {
                        var sets = JsonSerializer.Deserialize<List<Set>>(file.ReadToEnd(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        collectionSet.InsertMany(sets);
                    }
                }

                var collectionRarity = db.GetCollection<Rarity>("Rarity");
                foreach (var path in new[] { "rarities.json" })
                {
                    using (var file = new StreamReader(path))
                    {
                        var rarities = JsonSerializer.Deserialize<List<Rarity>>(file.ReadToEnd(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        collectionRarity.InsertMany(rarities);
                    }
                }

                var collectionTypes = db.GetCollection<CardType>("Cardtype");
                foreach (var path in new[] { "types.json" })
                {
                    using (var file = new StreamReader(path))
                    {
                        var types = JsonSerializer.Deserialize<List<CardType>>(file.ReadToEnd(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        collectionTypes.InsertMany(types);
                    }
                }

                var collectionClass = db.GetCollection<Class>("Class");
                foreach (var path in new[] { "classes.json" })
                {
                    using (var file = new StreamReader(path))
                    {
                        var classes = JsonSerializer.Deserialize<List<Class>>(file.ReadToEnd(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        collectionClass.InsertMany(classes);
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
