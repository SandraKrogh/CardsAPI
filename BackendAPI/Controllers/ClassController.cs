using BackendAPI.Services;
using BackendAPI.Models;
using BackendAPI.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly ILogger<ClassController> _logger;
        private IMapper _mapper;

        private readonly ClassService _classService;

        public ClassController(ILogger<ClassController> logger, ClassService classService)
        {
            _classService = classService;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Class, ClassDTO>();
            });
            _mapper = config.CreateMapper();

            _logger = logger;
        }
        

        [HttpGet("/classes")]
        public async Task<IList<ClassDTO>> Get()
        {
            _logger.LogInformation("Requested GET at endpoint /classes");

            var classes = await _classService.GetAsync();

            var mappedClasses = _mapper.Map<IList<Class>, IList<ClassDTO>>(classes);

            return mappedClasses; 
        }
            

    }
}
/*
[HttpGet("/Cards")]
public async Task<IList<CardDTO>> Get(int pagenumber, int? rarityId = null, int? classId = null, string? artist = null, int? setId = null)
{
    _logger.LogInformation("Requested GET at endpoint /cards");

    var _cards = await _cardService.GetAsync(pagenumber, rarityId, classId, artist, setId);

    if (_cards == null || _cards.Count == 0)
    {
        var notFoundList = new List<CardDTO>();
        return notFoundList;
    }

    var mappedCards = _mapper.Map<IList<Card>, IList<CardDTO>>(_cards);
            */