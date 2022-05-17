using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackendAPI.Services
{
    public class TypeService
    {
        private readonly ILogger<TypeService> _logger;
        private readonly IMongoCollection<CardType> _collection;

        public TypeService(ILogger<TypeService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("CardsAPI").GetCollection<CardType>("CardType");
            _logger = logger;

        }

        public async Task<List<CardType>> GetAsync() =>
        await _collection.Find(x => true).ToListAsync();
    }
}