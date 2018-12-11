using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;


namespace starwars_browser_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {

        private readonly PlanetContext _context;
        private readonly int _count = 61;
        public PlanetsController(PlanetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<PlanetItem[]> GetAll()
        {
            PlanetItem[] planets = new PlanetItem[_count];
            for (int i = 1; i < _count; i++)
            {
                planets[i - 1] = _context.Planets.Find(i);
            }
            return planets;
        }

        [HttpGet("{id}")]
        public ActionResult<PlanetItem> getPlanetById(int id)
        {
            PlanetItem planet = _context.Planets.Find(id);
            if (planet == null)
            {
                return NotFound();
            }
            return planet;
        }


    }
}