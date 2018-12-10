using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Models
{
    public class Planet
    {
        public int id { get; set; }
        public string name { get; set; }
        public string climate { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
        public string[] residents { get; set; }
        public string[] films { get; set; }
    }

    public class PlanetContext : DbContext
    {
        public PlanetContext(DbContextOptions<PlanetContext> options) : base(options)
        {
        }
        public DbSet<Planet> Planets { get; set; }
    }



}