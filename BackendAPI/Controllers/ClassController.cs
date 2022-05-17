using BackendAPI.Services;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly ClassService _classService;

        public ClassController(ClassService classService) =>
        _classService = classService;

        [HttpGet("{classes}")]
        public async Task<List<Class>> Get() =>
            await _classService.GetAsync();

    }
}
