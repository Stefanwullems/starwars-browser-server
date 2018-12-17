using Microsoft.EntityFrameworkCore.Migrations;
using starwars_browser_server.Models;
using starwars_browser_server.Requests;

namespace starwarsbrowserserver.Migrations.Starship
{
    public partial class FetchStarship : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            GetRequest<StarshipItem> client = new GetRequest<StarshipItem>("starships");
            for (int i = 1; i <= 37; i++) AddStarship(i, migrationBuilder, client);
        }

        private void AddStarship(int id, MigrationBuilder migrationBuilder, GetRequest<StarshipItem> client)
        {
            StarshipItem starship = client.GetById(id).GetAwaiter().GetResult();

            migrationBuilder.InsertData(
                table: "Starships",
            columns: new string[] { "id", "name", "starship_class", "manufacturer", "length", "cost_in_credits", "crew", "passengers", "max_atmosphering_speed", "cargo_capacity", "consumables", "hyperdrive_rating", "MGLT" },
            values: new object[] { id, starship.name, starship.starship_class, starship.manufacturer, starship.length, starship.cost_in_credits, starship.crew, starship.passengers, starship.max_atmosphering_speed, starship.cargo_capacity, starship.consumables, starship.hyperdrive_rating, starship.MGLT }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 37; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Starships",
                keyColumn: "id",
                keyValues: new object[] { i }
                );
            }
        }
    }

}
