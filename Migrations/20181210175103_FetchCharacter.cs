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
            CharacterRequest characterRequest = new CharacterRequest();
            CharacterItem character;
            for (int i = 1; i <= 87; i++)
            {
                if (i != 17)
                {
                    Console.WriteLine(i);
                    character = characterRequest.getById(i).GetAwaiter().GetResult();
                    migrationBuilder.InsertData(
                        table: "Characters",
                    columns: new string[] { "id", "name", "birth_year", "eye_color", "gender", "hair_color", "height", "mass", "skin_color", "homeworld" },
                    values: new object[] { i, character.name, character.birth_year, character.eye_color, character.gender, character.hair_color, character.height, character.mass, character.skin_color, character.homeworld }
                    );
                }
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
