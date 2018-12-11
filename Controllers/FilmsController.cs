using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;

namespace starwars_browser_server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {

        private readonly FilmContext _context;
        private readonly int _count = 7;

        public FilmsController(FilmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<FilmItem[]> GetFilms()
        {
            FilmItem[] films = new FilmItem[_count];
            for (int i = 1; i < _count; i++)
            {
                films[i - 1] = _context.Films.Find(i);
            }
            return films;
        }

        [HttpGet("{id}")]
        public ActionResult<FilmItem> GetFilmById(int id)
        {
            FilmItem film = _context.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }
            return film;
        }


    }
}