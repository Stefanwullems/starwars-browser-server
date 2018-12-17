using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace starwarsbrowserserver.Migrations
{
    public partial class InitialVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    vehicle_class = table.Column<string>(nullable: true),
                    manufacturer = table.Column<string>(nullable: true),
                    length = table.Column<string>(nullable: true),
                    cost_in_credits = table.Column<string>(nullable: true),
                    crew = table.Column<string>(nullable: true),
                    passengers = table.Column<string>(nullable: true),
                    max_atmosphering_speed = table.Column<string>(nullable: true),
                    cargo_capacity = table.Column<string>(nullable: true),
                    consumables = table.Column<string>(nullable: true),
                    films = table.Column<string[]>(nullable: true),
                    pilots = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
