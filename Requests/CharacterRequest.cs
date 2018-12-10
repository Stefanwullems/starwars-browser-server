using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using starwars_browser_server.Models;

namespace starwars_browser_server.Requests
{
    public class CharacterRequest
    {

        string baseUrl = "https://swapi.co/api/people/";
        private HttpClient client = PreparedClient.GetClient();

        public async Task<Character> getById(int id)
        {
            Character character = null;
            HttpResponseMessage res = await client.GetAsync(baseUrl + id);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    character = await res.Content.ReadAsAsync<Character>();
                    return character;
                }
                return character;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


    }
}