using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using Microsoft.EntityFrameworkCore;



namespace starwars_browser_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : GenericController
    {
        private readonly DbSet<PlanetItem> _repository;

        public PlanetsController(PlanetContext context) : base(count: 61)
        {
            _repository = context.Planets;
        }

        [HttpGet]
        public ActionResult<NameAndId[]> GetPlanets()
        {
            return GetNamesAndIds<PlanetItem>(_repository);
        }

        [HttpGet("{id}")]
        public ActionResult<PlanetItem> GetPlanetById(int id)
        {
            return GetItemById<PlanetItem>(id: id, repository: _repository);
        }
    }
}