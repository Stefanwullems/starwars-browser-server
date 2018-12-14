using System;
using Microsoft.EntityFrameworkCore.Migrations;
using starwars_browser_server.Requests;
using starwars_browser_server.Models;

namespace starwarsbrowserserver.Migrations
{
    public partial class FetchCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 87; i++) AddCharacter(i, migrationBuilder, new GetRequest<CharacterItem>("people"));
        }

        private void AddCharacter(int id, MigrationBuilder migrationBuilder, GetRequest<CharacterItem> client)
        {
            // 17 gives not found error
            CharacterItem character;
            if (id >= 17) character = client.GetById(id + 1).GetAwaiter().GetResult();
            else character = client.GetById(id).GetAwaiter().GetResult();

            migrationBuilder.InsertData(
                table: "Characters",
            columns: new string[] { "id", "name", "birth_year", "eye_color", "gender", "hair_color", "height", "mass", "skin_color", "homeworld" },
            values: new object[] { id, character.name, character.birth_year, character.eye_color, character.gender, character.hair_color, character.height, character.mass, character.skin_color, character.homeworld }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 86; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Characters",
                keyColumn: "id",
                keyValues: new object[] { i }
                );
            }
        }
    }
}
