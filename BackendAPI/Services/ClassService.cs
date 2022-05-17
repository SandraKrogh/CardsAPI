using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackendAPI.Services
{
    public class ClassService
    {
        private readonly ILogger<ClassService> _logger;
        private readonly IMongoCollection<Class> _collection;

        public ClassService(ILogger<ClassService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("CardsAPI").GetCollection<Class>("Class");
            _logger = logger;

        }

        public async Task<List<Class>> GetAsync() =>
        await _collection.Find(x => true).ToListAsync();
    }

}
