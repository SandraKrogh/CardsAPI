using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace BackendAPI.Services
{
    public class CardService
    {
        private readonly IMongoCollection<Card> _collection;

        public CardService(IOptions<CardsDatabaseSettings> cardsDatabaseSettings, MongoService service)
        {
            //_collection = service.Client.GetDatabase("CardsAPI").GetCollection<Card>("Card");
            //_logger = logger;

            var mongoDatabase = service.Client.GetDatabase(cardsDatabaseSettings
                .Value
                .DatabaseName);

            _collection = mongoDatabase.GetCollection<Card>(
                                             cardsDatabaseSettings
                                             .Value
                                             .CollectionName[0]);

            /*
            var mongoClient = new MongoClient(
                                              cardsDatabaseSettings
                                              .Value
                                              .ConnectionString);
            var mongoDatabase = new MongoClient().GetDatabase(
                                                  cardsDatabaseSettings
                                                  .Value
                                                  .DatabaseName);
            _collection = mongoDatabase.GetCollection<Card>(
                                             cardsDatabaseSettings
                                             .Value
                                             .CollectionName[0]);
            */
        }


        public async Task<IList<Card>> GetAsync(int pagenumber, int? rarityId = null, int? classId = null, string? artist = null, int? setId = null)
        {
            //_logger.LogInformation("Requested GET cards");

            var builder = Builders<Card>.Filter;
            var filter = builder.Empty;

            if (rarityId > 0)
            {
                filter &= builder.Eq(x => x.RarityId, rarityId);
            }
            if (classId > 0)
            {
                filter &= builder.Eq(x => x.ClassId, classId);
            }
            if (artist?.Length > 0)
            {
                filter &= builder.Regex(x => x.artistName, new BsonRegularExpression($"/{artist}/i"));
            }

            if (setId > 0)
            {
                filter &= builder.Eq(x => x.cardSetId, setId);
            }

            return await _collection.Find(filter).Skip(pagenumber * 50).Limit(50).ToListAsync();
        }


        
    }
}

