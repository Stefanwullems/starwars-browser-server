using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace starwarsbrowserserver.Migrations
{
    public partial class InitialCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    birth_year = table.Column<string>(nullable: true),
                    eye_color = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    hair_color = table.Column<string>(nullable: true),
                    height = table.Column<string>(nullable: true),
                    mass = table.Column<string>(nullable: true),
                    skin_color = table.Column<string>(nullable: true),
                    homeworld = table.Column<string>(nullable: true),
                    films = table.Column<string[]>(nullable: true),
                    species = table.Column<string[]>(nullable: true),
                    starships = table.Column<string[]>(nullable: true),
                    vehicles = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
