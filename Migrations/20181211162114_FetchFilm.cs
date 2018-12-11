using System;
using Microsoft.EntityFrameworkCore.Migrations;
using starwars_browser_server.Requests;
using starwars_browser_server.Models;
namespace starwarsbrowserserver.Migrations.Film
{
    public partial class FetchFilm : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            FilmRequest client = new FilmRequest();
            for (int i = 1; i <= 7; i++) AddFilm(i, migrationBuilder, client);
        }

        private void AddFilm(int id, MigrationBuilder migrationBuilder, FilmRequest client)
        {
            Console.Clear();
            Console.WriteLine("Progress:" + id.ToString() + "/7");

            FilmItem film = client.GetById(id).GetAwaiter().GetResult();

            migrationBuilder.InsertData(
                table: "Films",
            columns: new string[] { "id", "title", "opening_crawl", "director", "producer", "release_date", },
            values: new object[] { id, film.title, film.opening_crawl, film.director, film.producer, film.release_date }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 7; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Films",
                keyColumn: "id",
                keyValues: new object[] { i }
                );

            }
        }
    }
}
