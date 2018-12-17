using Microsoft.EntityFrameworkCore.Migrations;
using starwars_browser_server.Requests;
using starwars_browser_server.Models;
using System;
namespace starwarsbrowserserver.Migrations.Vehicle
{
    public partial class FetchVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            GetRequest<VehicleItem> client = new GetRequest<VehicleItem>("vehicles");
            for (int i = 1; i <= 39; i++) AddVehicle(i, migrationBuilder, client);
        }

        private void AddVehicle(int id, MigrationBuilder migrationBuilder, GetRequest<VehicleItem> client)
        {
            Console.WriteLine(id);
            VehicleItem vehicle = client.GetById(id).GetAwaiter().GetResult();

            migrationBuilder.InsertData(
                table: "Vehicles",
            columns: new string[] { "id", "name", "vehicle_class", "manufacturer", "length", "cost_in_credits", "crew", "passengers", "max_atmosphering_speed", "cargo_capacity", "consumables" },
            values: new object[] { id, vehicle.name, vehicle.vehicle_class, vehicle.manufacturer, vehicle.length, vehicle.cost_in_credits, vehicle.crew, vehicle.passengers, vehicle.max_atmosphering_speed, vehicle.cargo_capacity, vehicle.consumables }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 39; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Vehicles",
                keyColumn: "id",
                keyValues: new object[] { i }
                );
            }
        }
    }
}
