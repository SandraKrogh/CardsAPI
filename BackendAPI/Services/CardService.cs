using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackendAPI.Services
{
    public class CardService
    {
        private readonly ILogger<CardService> _logger;
        private readonly IMongoCollection<Card> _collection;

        public CardService(ILogger<CardService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("CardsAPI").GetCollection<Card>("Card");
            _logger = logger;

        }

        //Get all available cards 
        public async Task<List<Card>> GetAsync(int pagenumber) =>
            await _collection.Find(x => true).Skip(pagenumber * 50).Limit(50).ToListAsync();


        public async Task<IList<Card>> GetAsync(int pagenumber, int? rarityId = null, int? classId = null, string? artist = null, int? setId = null)
        {
            var builder = Builders<Card>.Filter;
            var filter = builder.Empty;

            if (rarityId > 0)
            {
                filter &= builder.Regex(x => x.RarityId, new BsonRegularExpression($"/{rarityId}/i"));
            }

            if (classId > 0)
            {
                filter &= builder.Regex(x => x.ClassId, new BsonRegularExpression($"/{classId}/i"));
            }

            if (artist?.Length > 0)
            {
                filter &= builder.Regex(x => x.artistName, new BsonRegularExpression($"/{artist}/i"));
            }

            if (setId > 0)
            {
                filter &= builder.Eq(x => x.SetId, setId);
            }

            return await _collection.Find(filter).Skip(pagenumber * 50).Limit(50).ToListAsync();
        }
    }
}

