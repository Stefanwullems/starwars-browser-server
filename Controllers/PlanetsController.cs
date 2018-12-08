using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using starwars_browser_server.Requests;

namespace starwars_browser_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private PlanetRequest _planetRequest;

        public PlanetsController()
        {
            _planetRequest = new PlanetRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<Planet> getPlanetById(int id)
        {
            return _planetRequest.GetById(id).GetAwaiter().GetResult();
        }

        [HttpGet]
        public ActionResult<string> Test()
        {
            return "hi";
        }
    }
}