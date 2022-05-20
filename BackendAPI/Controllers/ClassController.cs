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

          