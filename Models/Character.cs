using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Models
{
    public class CharacterItem : NameAndId
    {
        public string birth_year { get; set; }
        public string eye_color { get; set; }
        public string gender { get; set; }
        public string hair_color { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string skin_color { get; set; }
        public string homeworld { get; set; }
        public string[] films { get; set; }
        public string[] species { get; set; }
        public string[] starships { get; set; }
        public string[] vehicles { get; set; }
        public string title { get; set; }
    }

    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options) { }
        public DbSet<CharacterItem> Characters { get; set; }
    }
}