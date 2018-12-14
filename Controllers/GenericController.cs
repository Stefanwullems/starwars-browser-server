using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Controllers
{
    public interface IDBT<T>
    {
        T Find(int id);
    }

    public class GenericController : ControllerBase
    {

        private readonly int _count;

        public GenericController(int count)
        {
            _count = count;
        }


        public NameAndId[] GetNamesAndIds<TEntity>(DbSet<TEntity> repository) where TEntity : NameAndId
        {
            try
            {
                NameAndId[] items = new NameAndId[_count];
                TEntity curr;
                for (int i = 1; i < _count + 1; i++)
                {
                    curr = repository.Find(i);
                    if (curr != null)
                    {
                        items[i - 1] = SetNameAndIdProperties(curr, new NameAndId());
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(NameAndId[]);
            }
        }

        public NameAndId[] GetTitlesAndIds<TEntity>(DbSet<TEntity> repository) where TEntity : TitleAndId
        {
            try
            {
                NameAndId[] items = new NameAndId[_count];
                TEntity curr;
                for (int i = 1; i < _count + 1; i++)
                {
                    curr = repository.Find(i);
                    if (curr != null)
                    {
                        items[i - 1] = SetNameAndIdPropertiesForTitleAndId(curr, new NameAndId());
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(NameAndId[]);
            }
        }

        private static NameAndId SetNameAndIdPropertiesForTitleAndId(TitleAndId curr, NameAndId item)
        {
            item.name = curr.title;
            item.id = curr.id;
            return item;
        }
        private static NameAndId SetNameAndIdProperties(NameAndId curr, NameAndId item)
        {
            item.name = curr.name;
            item.id = curr.id;
            return item;
        }

        public ActionResult<TEntity> GetItemById<TEntity>(int id, DbSet<TEntity> repository) where TEntity : class
        {
            try
            {
                TEntity item = repository.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


    }
}