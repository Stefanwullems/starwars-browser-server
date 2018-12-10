using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace starwarsbrowserserver.Migrations
{
    public partial class InitialPlanet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    climate = table.Column<string>(nullable: true),
                    rotation_period = table.Column<string>(nullable: true),
                    orbital_period = table.Column<string>(nullable: true),
                    diameter = table.Column<string>(nullable: true),
                    gravity = table.Column<string>(nullable: true),
                    terrain = table.Column<string>(nullable: true),
                    surface_water = table.Column<string>(nullable: true),
                    population = table.Column<string>(nullable: true),
                    residents = table.Column<string[]>(nullable: true),
                    films = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
