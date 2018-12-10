using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using starwars_browser_server.Models;
namespace starwars_browser_server.Requests
{

    class PlanetRequest
    {

        private static string baseUrl = "https://swapi.co/api/planets/";
        private HttpClient client = PreparedClient.GetClient();
        public async Task<PlanetItem> GetById(int id)
        {

            PlanetItem planet = null;
            HttpResponseMessage response = await client.GetAsync(baseUrl + id);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    planet = await response.Content.ReadAsAsync<PlanetItem>();
                }
                return planet;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}