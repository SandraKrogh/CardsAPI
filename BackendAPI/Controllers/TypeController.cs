using BackendAPI.Services;
using BackendAPI.Models;
using BackendAPI.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeController : ControllerBase
    {
        private readonly ILogger<TypeController> _logger;
        private IMapper _mapper;

        private readonly TypeService _typeService;

        public TypeController(ILogger<TypeController> logger, TypeService typeService)
        {
            _typeService = typeService;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CardType, CardTypeDTO>();
            });
            _mapper = config.CreateMapper();

            _logger = logger;
        }
        

        [HttpGet("/types")]
        public async Task<IList<CardTypeDTO>> Get()
        {
            _logger.LogInformation("Requested GET at endpoint /types");

            var types = await _typeService.GetAsync();

            var mappedTypes = _mapper.Map<IList<CardType>, IList<CardTypeDTO>>(types);
            
            return mappedTypes;
        }
            
    }
}
