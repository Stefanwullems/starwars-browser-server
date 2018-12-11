using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;


namespace starwars_browser_server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterContext _context;
        private readonly int _count = 87;
        public CharactersController(CharacterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<CharacterItem[]> GetAll()
        {
            CharacterItem[] characters = new CharacterItem[_count];
            for (int i = 1; i < _count; i++)
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