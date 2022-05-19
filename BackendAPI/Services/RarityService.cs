﻿using BackendAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace BackendAPI.Services
{
    public class RarityService
    {
        //private readonly ILogger<RarityService> _logger;
        private readonly IMongoCollection<Rarity> _collection;


        public RarityService(IOptions<CardsDatabaseSettings> cardsDatabaseSettings, MongoService service)
        {
            //_collection = service.Client.GetDatabase("CardsAPI").GetCollection<Rarity>("Rarity");
            //_logger = logger;

            var mongoDatabase = service.Client.GetDatabase(cardsDatabaseSettings
                .Value
                .DatabaseName);

            _collection = mongoDatabase.GetCollection<Rarity>(
                                             cardsDatabaseSettings
                                             .Value
                                             .CollectionName[3]);

            /*
            var mongoClient = new MongoClient(
                                              cardsDatabaseSettings
                                              .Value
                                              .ConnectionString);
            var mongoDatabase = new MongoClient().GetDatabase(
                                                  cardsDatabaseSettings
                                                  .Value
                                                  .DatabaseName);
            _collection = mongoDatabase.GetCollection<Rarity>(
                                             cardsDatabaseSettings
                                             .Value
                                             .CollectionName[3]);
            */
        }

        public async Task<List<Rarity>> GetAsync() =>
            await _collection.Find(x => true).ToListAsync();

        public async Task<Rarity> GetRarity(int id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}
