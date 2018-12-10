using System;
using Microsoft.EntityFrameworkCore.Migrations;
using starwars_browser_server.Requests;
using starwars_browser_server.Models;

namespace starwarsbrowserserver.Migrations.Planet
{
    public partial class FetchPlanet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            PlanetRequest planetRequest = new PlanetRequest();
            PlanetItem planet;
            for (int i = 1; i <= 61; i++)
            {
                Console.WriteLine(i);
                planet = planetRequest.GetById(i).GetAwaiter().GetResult();
                migrationBuilder.InsertData(
                    table: "Planets",
                columns: new string[] { "id", "name", "climate", "rotation_period", "orbital_period", "diameter", "gravity", "terrain", "surface_water", "population" },
                values: new object[] { i, planet.name, planet.climate, planet.rotation_period, planet.orbital_period, planet.diameter, planet.gravity, planet.terrain, planet.surface_water, planet.population }
                );

            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
