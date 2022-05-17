using BackendAPI.Models;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetsController : ControllerBase
    {
        private readonly SetService _setService;

        public SetsController(SetService setService) =>
        _setService = setService;

        [HttpGet("{sets}")]
        public async Task<List<Set>> Get() =>
            await _setService.GetAsync();

    }
}
