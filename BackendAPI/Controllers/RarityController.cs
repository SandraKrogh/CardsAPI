using BackendAPI.Services;
using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RarityController : ControllerBase
    {
        private readonly RarityService _rarityService;

        public RarityController(RarityService rarityService) =>
        _rarityService = rarityService;

        [HttpGet]
        public async Task<List<Rarity>> Get() =>
            await _rarityService.GetAsync();

    }
}
