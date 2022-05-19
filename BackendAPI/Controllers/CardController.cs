using BackendAPI.Models;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BackendAPI.Data;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;

        private readonly CardService _cardService;
        private readonly ClassService _classService;
        private readonly RarityService _rarityService;
        private readonly SetService _setService;
        private readonly TypeService _typeService;

        private IMapper _mapper;

        public CardController(ILogger<CardController> logger, CardService cardService, SetService setService, ClassService classService, RarityService rarityService, TypeService typeService)
        {
            _logger = logger;

            _cardService = cardService;
            _setService = setService;
            _classService = classService;
            _rarityService = rarityService;
            _typeService = typeService;


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Card, CardDTO>();
            });
            _mapper = config.CreateMapper();
        }
        
        
        [HttpGet("/cards")]
        public async Task<IList<CardDTO>> Get(int pagenumber, int? rarityId = null, int? classId = null, string? artist = null, int? setId = null)
        {
            _logger.LogInformation("Requested GET at endpoint /cards");

            var cards = await _cardService.GetAsync(pagenumber, rarityId, classId, artist, setId);

            if (cards == null || cards.Count == 0)
            {
                var notFoundList = new List<CardDTO>();
                return notFoundList;
            }
            
            var mappedCards = _mapper.Map<IList<Card>, IList<CardDTO>>(cards);
            
            for (int i = 0; i < mappedCards.Count; i++)
            {
                var classTemp = await _classService.GetClass(cards[i].ClassId);
                if (classTemp == null)
                    mappedCards[i].Class = null;
                else
                    mappedCards[i].Class = classTemp.Name;

                var rarityTemp = await _rarityService.GetRarity(cards[i].RarityId);
                if (rarityTemp == null)
                    mappedCards[i].Rarity = null;
                else
                    mappedCards[i].Rarity = rarityTemp.Name;

                var setTemp = await _setService.GetSet(cards[i].cardSetId);
                if (setTemp == null)
                    mappedCards[i].Set = null;
                else
                    mappedCards[i].Set = setTemp.Name;

                var typeTemp = await _typeService.GetType(cards[i].cardTypeId);
                if (typeTemp == null)
                    mappedCards[i].Type = null;
                else
                    mappedCards[i].Type = typeTemp.Name;
            }

            
            return mappedCards;
        }

    }
}
