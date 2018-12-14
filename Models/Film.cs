using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Models
{
    public class FilmItem : TitleAndId
    {
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public string[] species { get; set; }
        public string[] starships { get; set; }
        public string[] vehicles { get; set; }
        public string[] characters { get; set; }
        public string[] planets { get; set; }


    }

    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }
        public DbSet<FilmItem> Films { get; set; }
    }
}