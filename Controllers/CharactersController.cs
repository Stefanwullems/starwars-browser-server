using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using starwars_browser_server.Requests;

namespace starwars_browser_server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterContext _context;
        public CharactersController(CharacterContext context)
        {
            _context = context;
        }
        private CharacterRequest _characterRequest = new CharacterRequest();

        [HttpGet]
        public ActionResult<CharacterItem[]> GetAll()
        {
            CharacterItem[] characters = new CharacterItem[86];
            for (int i = 1; i < 87; i++)
            {
                characters[i - 1] = _context.Characters.Find(i);
            }
            return characters;
        }

        [HttpGet("{id}")]
        public ActionResult<CharacterItem> GetCharacterById(int id)
        {
            CharacterItem character = _context.Characters.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            return character;
        }
    }
}