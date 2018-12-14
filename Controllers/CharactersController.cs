using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Controllers
{
    public class CharactersController : GenericController
    {
        private readonly DbSet<CharacterItem> _repository;

        public CharactersController(CharacterContext context) : base(count: 87)
        {
            _repository = context.Characters;
        }

        [HttpGet]
        public ActionResult<NameAndId[]> GetCharacters()
        {
            return GetNamesAndIds<CharacterItem>(_repository);
        }

        [HttpGet("{id}")]
        public ActionResult<CharacterItem> GetCharacterById(int id)
        {
            return GetItemById<CharacterItem>(id: id, repository: _repository);
        }
    }
}