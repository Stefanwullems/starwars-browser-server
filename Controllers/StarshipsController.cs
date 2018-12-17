using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Controllers
{
    public class StarshipsController : GenericController
    {
        private readonly DbSet<StarshipItem> _repository;

        public StarshipsController(StarshipContext context) : base(count: 37)
        {
            _repository = context.Starships;
        }

        [HttpGet]
        public ActionResult<NameAndId[]> GetStarships()
        {
            return GetNamesAndIds<StarshipItem>(_repository);
        }

        [HttpGet("{id}")]
        public ActionResult<StarshipItem> GetStarshipById(int id)
        {
            return GetItemById<StarshipItem>(id: id, repository: _repository);
        }
    }
}