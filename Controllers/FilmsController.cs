using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using Microsoft.EntityFrameworkCore;



namespace starwars_browser_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : GenericController
    {
        private readonly DbSet<FilmItem> _repository;

        public FilmsController(FilmContext context) : base(count: 61)
        {
            _repository = context.Films;
        }

        [HttpGet]
        public ActionResult<NameAndId[]> GetFilms()
        {
            return GetTitlesAndIds<FilmItem>(_repository);
        }

        [HttpGet("{id}")]
        public ActionResult<FilmItem> GetFilmById(int id)
        {
            return GetItemById<FilmItem>(id: id, repository: _repository);
        }
    }
}