using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace starwarsbrowserserver.Migrations
{
    public partial class InitialFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    title = table.Column<string>(nullable: true),
                    opening_crawl = table.Column<string>(nullable: true),
                    director = table.Column<string>(nullable: true),
                    producer = table.Column<string>(nullable: true),
                    release_date = table.Column<string>(nullable: true),
                    species = table.Column<string[]>(nullable: true),
                    starships = table.Column<string[]>(nullable: true),
                    vehicles = table.Column<string[]>(nullable: true),
                    characters = table.Column<string[]>(nullable: true),
                    planets = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
