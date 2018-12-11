using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using starwars_browser_server.Models;
namespace starwars_browser_server.Requests
{

    class FilmRequest
    {

        private static string baseUrl = "https://swapi.co/api/films/";
        private HttpClient client = PreparedClient.GetClient();
        public async Task<FilmItem> GetById(int id)
        {

            FilmItem film = null;
            HttpResponseMessage response = await client.GetAsync(baseUrl + id);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    film = await response.Content.ReadAsAsync<FilmItem>();
                }
                return film;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}