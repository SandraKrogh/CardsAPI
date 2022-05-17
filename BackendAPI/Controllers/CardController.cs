﻿using BackendAPI.Models;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardController(CardService cardService) =>
        _cardService = cardService;

        [HttpGet("{cards} {pagenumber}")]
        public async Task<List<Card>> Get() =>
            await _cardService.GetAsync();

        [HttpGet("{cards}, {pagenumber}, {artist}")]
        public async Task<IList<Card>> Get(int pagenumber, string artist)
        {
            var _artist = await _cardService.GetAsync(pagenumber, null, null, artist, null);

            if (_artist is null)
            {
                return (IList<Card>)NotFound();
            }

            return _artist;
        }

        [HttpGet("{cards}, {pagenumber}, {setid}")]
        public async Task<IList<Card>> Get(int pagenumber, int setid)
        {
            var _cards = await _cardService.GetAsync(pagenumber, null, null, null, setid);

            if (_cards is null)
            {
                return (IList<Card>)NotFound();
            }

            return _cards;
        }

        [HttpGet("{cards},{pagenumber}, {classid} , {dummy}")]
        public async Task<IList<Card>> Get(int pagenumber, int classId, int dummy)
        {
            var _cards = await _cardService.GetAsync(pagenumber, null, classId, null, null);

            if (_cards is null)
            {
                return (IList<Card>)NotFound();
            }

            return _cards;
        }


        [HttpGet("{cards}, {pagenumber}, {rarityId} , {dummy}")]
        public async Task<IList<Card>> Get(int pagenumber, int rarityId, string dummy)
        {
            var _cards = await _cardService.GetAsync(pagenumber, rarityId, null, null, null);

            if (_cards is null)
            {
                return (IList<Card>)NotFound();
            }

            return _cards;
        }


    }
}