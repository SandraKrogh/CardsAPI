using BackendAPI.Services;
using BackendAPI.Models;
using BackendAPI.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RarityController : ControllerBase
    {
        private readonly ILogger<RarityController> _logger;
        private IMapper _mapper;

        private readonly RarityService _rarityService;

        public RarityController(ILogger<RarityController> logger, RarityService rarityService)
        {
            _rarityService = rarityService;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rarity, RarityDTO>();
            });
            _mapper = config.CreateMapper();

            _logger = logger;
        }
        

        [HttpGet("/rarities")]
        public async Task<IList<RarityDTO>> Get()
        {
            _logger.LogInformation("Requested GET at endpoint /rarities");

            var rarities = await _rarityService.GetAsync();

            var mappedRarities = _mapper.Map<IList<Rarity>, IList<RarityDTO>>(rarities);
            return mappedRarities;
        }

    }
}
