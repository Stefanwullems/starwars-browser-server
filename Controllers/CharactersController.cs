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

        private CharacterRequest _characterRequest = new CharacterRequest();

        [HttpGet("{id}")]
        public ActionResult<Character> GetCharacterById(int id)
        {
            return _characterRequest.getById(id).GetAwaiter().GetResult();
        }
    }
}