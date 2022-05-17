using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackendAPI.Services
{
    public class RarityService
    {
        private readonly ILogger<RarityService> _logger;
        private readonly IMongoCollection<Rarity> _collection;

        public RarityService(ILogger<RarityService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("CardsAPI").GetCollection<Rarity>("Rarity");
            _logger = logger;

        }

        public async Task<List<Rarity>> GetAsync() =>
        await _collection.Find(x => true).ToListAsync();
    }
}
