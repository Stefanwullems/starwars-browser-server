using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using starwars_browser_server.Requests;

namespace starwars_browser_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {

        private readonly PlanetContext _context;
        public PlanetsController(PlanetContext context)
        {
            _context = context;
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