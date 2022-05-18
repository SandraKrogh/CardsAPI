using BackendAPI.Models;
using BackendAPI.Data;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetsController : ControllerBase
    {
        private readonly ILogger<SetsController> _logger;
        private IMapper _mapper;

        private readonly SetService _setService;

        public SetsController(ILogger<SetsController> logger, SetService setService)
        {
            _setService = setService;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Set, SetDTO>();
            });
            _mapper = config.CreateMapper();

            _logger = logger;
        }
        

        [HttpGet("/sets")]
        public async Task<IList<SetDTO>> Get()
        {
            _logger.LogInformation("Requested GET at endpoint /sets");

            var sets = await _setService.GetAsync();

            var mappedSets = _mapper.Map<IList<Set>, IList<SetDTO>>(sets);
            return mappedSets;
        }
            
    }
}
