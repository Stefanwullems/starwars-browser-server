using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using System.Data.Entity;

namespace starwars_browser_server.Controllers
{

    public interface INameAndId
    {
        string name { get; set; }
        string title { get; set; }
        int id { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<Model> : ControllerBase where Model : class
    {

        private readonly int _count;

        public GenericController(int count)
        {
            _count = count;
        }

        [HttpGet]
        public ActionResult<NameAndId[]> Getitems(DbSet<INameAndId> repository)
        {
            NameAndId[] items = new NameAndId[_count];
            NameAndId item;
            INameAndId curr;
            for (int i = 1; i < _count + 1; i++)
            {
                curr = repository.Find(i);
                item = new NameAndId();
                if (curr != null)
                {
                    if (curr.name == null) item.name = curr.title;
                    else item.name = curr.title;

                    item.id = curr.id;
                    items[i - 1] = item;
                }
            }
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<Model> GetItemById(int id, DbSet<Model> repository)
        {
            Model item = repository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }


    }
}