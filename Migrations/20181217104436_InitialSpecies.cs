using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace starwarsbrowserserver.Migrations
{
    public partial class InitialSpecies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    classification = table.Column<string>(nullable: true),
                    designation = table.Column<string>(nullable: true),
                    average_height = table.Column<string>(nullable: true),
                    hair_colors = table.Column<string>(nullable: true),
                    average_lifespan = table.Column<string>(nullable: true),
                    eye_colors = table.Column<string>(nullable: true),
                    skin_colors = table.Column<string>(nullable: true),
                    homeworld = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true),
                    people = table.Column<string[]>(nullable: true),
                    films = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
