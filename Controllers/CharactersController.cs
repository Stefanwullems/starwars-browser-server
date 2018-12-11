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
        private readonly int _count = 86;
        public CharactersController(CharacterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<NameAndId[]> GetAll()
        {
            NameAndId[] characters = new NameAndId[_count];
            NameAndId character;
            CharacterItem curr;
            for (int i = 1; i < _count; i++)
            {
                curr = _context.Characters.Find(i);
                character = new NameAndId();
                if (curr != null)
                {

                    character.name = curr.name;
                    character.id = curr.id;
                    characters[i - 1] = character;
                }
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