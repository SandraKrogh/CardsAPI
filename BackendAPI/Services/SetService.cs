using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackendAPI.Services
{
    public class SetService
    {
        private readonly ILogger<SetService> _logger;
        private readonly IMongoCollection<Set> _collection;

        public SetService(ILogger<SetService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("CardsAPI").GetCollection<Set>("Set");
            _logger = logger;

        }

        public async Task<List<Set>> GetAsync() =>
        await _collection.Find(x => true).ToListAsync();
    }
}
