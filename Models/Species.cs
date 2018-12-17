using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Models
{
    public class SpeciesItem : NameAndId
    {
        public string classification { get; set; }
        public string designation { get; set; }
        public string average_height { get; set; }
        public string hair_colors { get; set; }
        public string average_lifespan { get; set; }
        public string eye_colors { get; set; }
        public string skin_colors { get; set; }
        public string homeworld { get; set; }
        public string language { get; set; }
        public string[] people { get; set; }
        public string[] films { get; set; }
    }

    public class SpeciesContext : DbContext
    {
        public SpeciesContext(DbContextOptions<SpeciesContext> options) : base(options) { }
        public DbSet<SpeciesItem> Species { get; set; }
    }
}