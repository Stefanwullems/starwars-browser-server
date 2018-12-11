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
        public ActionResult<NameAndId[]> GetAll()
        {
            NameAndId[] planets = new NameAndId[_count];
            NameAndId planet;
            PlanetItem curr;
            for (int i = 1; i < _count + 1; i++)
            {
                curr = _context.Planets.Find(i);
                planet = new NameAndId();
                if (curr != null)
                {

                    planet.name = curr.name;
                    planet.id = curr.id;
                    planets[i - 1] = planet;
                }
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