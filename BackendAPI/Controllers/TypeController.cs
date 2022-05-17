using BackendAPI.Services;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeController : ControllerBase
    {
        private readonly TypeService _typeService;

        public TypeController(TypeService typeService) =>
        _typeService = typeService;

        [HttpGet("{types}")]
        public async Task<List<CardType>> Get() =>
            await _typeService.GetAsync();

    }
}
