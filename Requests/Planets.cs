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

        HttpClient client = new HttpClient();

        public async Task<Planet> GetById(int id)
        {
            HttpClient client = PrepareClient();
            Planet planet = null;
            HttpResponseMessage response = await client.GetAsync(baseUrl + id);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    planet = await response.Content.ReadAsAsync<Planet>();
                }
                return planet;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(Planet);
            }
        }

        public async Task<NameAndId[]> GetNamesAndIds()
        {
            HttpClient client = PrepareClient();
            NameAndId[] planets = new NameAndId[2];
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    HttpResponseMessage response = await client.GetAsync(baseUrl + (i + 1).ToString());
                    planets[i] = await response.Content.ReadAsAsync<NameAndId>();
                    planets[i].id = i + 1;

                }
                return planets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(NameAndId[]);
            }
        }

        private HttpClient PrepareClient()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;

        }
    }
}