using Microsoft.EntityFrameworkCore.Migrations;
using starwars_browser_server.Requests;
using starwars_browser_server.Models;
using System;
namespace starwarsbrowserserver.Migrations.Species
{
    public partial class FetchSpecies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 37; i++) AddSpecies(i, migrationBuilder, new GetRequest<SpeciesItem>("species"));
        }

        private void AddSpecies(int id, MigrationBuilder migrationBuilder, GetRequest<SpeciesItem> client)
        {
            Console.WriteLine(id);
            SpeciesItem species = client.GetById(id).GetAwaiter().GetResult();

            migrationBuilder.InsertData(
                table: "Species",
            columns: new string[] { "id", "name", "classification", "designation", "average_height", "hair_colors", "average_lifespan", "eye_colors", "skin_colors", "homeworld", "language" },
            values: new object[] { id, species.name, species.classification, species.designation, species.average_height, species.hair_colors, species.average_lifespan, species.eye_colors, species.skin_colors, species.homeworld, species.language }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 37; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Species",
                keyColumn: "id",
                keyValues: new object[] { i }
                );
            }
        }
    }
}
