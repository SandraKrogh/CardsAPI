using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace BackendAPI.Services
{
    public class SetService
    {
        private readonly IMongoCollection<Set> _collection;


        public SetService(IOptions<CardsDatabaseSettings> cardsDatabaseSettings, MongoService service)
        {

            var mongoDatabase = service.Client.GetDatabase(cardsDatabaseSettings
                .Value
                .DatabaseName);

            _collection = mongoDatabase.GetCollection<Set>(
                                             cardsDatabaseSettings
                                             .Value
                                             .CollectionName[4]);
        }

        public async Task<List<Set>> GetAsync() =>
            await _collection.Find(x => true).ToListAsync();

        public async Task<Set> GetSet(int? id)
        {
            var _set = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _set;
        }
            
    }
}
