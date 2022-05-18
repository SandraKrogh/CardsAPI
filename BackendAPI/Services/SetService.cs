using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace BackendAPI.Services
{
    public class SetService
    {
        //private readonly ILogger<SetService> _logger;
        private readonly IMongoCollection<Set> _collection;


        public SetService(MongoService service, IOptions<CardsDatabaseSettings> cardsDatabaseSettings)
        {
            //_collection = service.Client.GetDatabase("CardsAPI").GetCollection<Set>("Set");
            //_logger = logger;

            var mongoClient = new MongoClient(
                                              cardsDatabaseSettings
                                              .Value
                                              .ConnectionString);
            var mongoDatabase = new MongoClient().GetDatabase(
                                                  cardsDatabaseSettings
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
            /*
            if(_set == null)
            {
                return new Set();
            }
            */
            return _set;
        }
            
    }
}
