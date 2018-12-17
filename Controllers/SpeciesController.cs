using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Controllers
{
    public class SpeciesController : GenericController
    {
        private readonly DbSet<SpeciesItem> _repository;

        public SpeciesController(SpeciesContext context) : base(count: 37)
        {
            _repository = context.Species;
        }

        [HttpGet]
        public ActionResult<NameAndId[]> GetSpecies()
        {
            return GetNamesAndIds<SpeciesItem>(_repository);
        }

        [HttpGet("{id}")]
        public ActionResult<SpeciesItem> GetSpeciesById(int id)
        {
            return GetItemById<SpeciesItem>(id: id, repository: _repository);
        }
    }
}