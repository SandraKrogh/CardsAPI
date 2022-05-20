using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace BackendAPI.Services
{
    public class ClassService
    {
        private readonly IMongoCollection<Class> _collection;

        public ClassService(IOptions<CardsDatabaseSettings> cardsDatabaseSettings, MongoService service)
        {
            var mongoDatabase = service.Client.GetDatabase(cardsDatabaseSettings
                .Value
                .DatabaseName);

            _collection = mongoDatabase.GetCollection<Class>(
                                             cardsDatabaseSettings
                                             .Value
                                             .CollectionName[2]);
        }

        public async Task<List<Class>> GetAsync() =>
            await _collection.Find(x => true).ToListAsync();

        public async Task<Class> GetClass(int id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

}
