using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Models
{
    public class StarshipItem : NameAndId
    {
        public string model { get; set; }
        public string starship_class { get; set; }
        public string manufacturer { get; set; }
        public string length { get; set; }
        public string cost_in_credits { get; set; }
        public string crew { get; set; }
        public string passengers { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string hyperdrive_rating { get; set; }
        public string MGLT { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public string[] films { get; set; }
        public string[] pilots { get; set; }
    }

    public class StarshipContext : DbContext
    {
        public StarshipContext(DbContextOptions<StarshipContext> options) : base(options) { }
        public DbSet<StarshipItem> Starships { get; set; }
    }
}