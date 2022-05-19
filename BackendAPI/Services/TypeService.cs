using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace BackendAPI.Services
{
    public class TypeService
    {
        //private readonly ILogger<TypeService> _logger;
        private readonly IMongoCollection<CardType> _collection;

        public TypeService(IOptions<CardsDatabaseSettings> cardsDatabaseSettings, MongoService service)
        {
            //_collection = service.Client.GetDatabase("CardsAPI").GetCollection<CardType>("CardType");
            //_logger = logger;

            var mongoDatabase = service.Client.GetDatabase(cardsDatabaseSettings
                .Value
                .DatabaseName);

            _collection = mongoDatabase.GetCollection<CardType>(
                                             cardsDatabaseSettings
                                             .Value
                                             .CollectionName[1]);

            /*
            var mongoClient = new MongoClient(
                                              cardsDatabaseSettings
                                              .Value
                                              .ConnectionString);
            var mongoDatabase = new MongoClient().GetDatabase(
                                                  cardsDatabaseSettings
                                                  .Value
                                                  .DatabaseName);
            _collection = mongoDatabase.GetCollection<CardType>(
                                             cardsDatabaseSettings
                                             .Value
                                             .CollectionName[1]);
            */
        }

        public async Task<List<CardType>> GetAsync() =>
            await _collection.Find(x => true).ToListAsync();

        public async Task<CardType> GetType(int id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }


            
    }
}