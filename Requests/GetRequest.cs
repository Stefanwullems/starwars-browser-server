using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using starwars_browser_server.Models;

namespace starwars_browser_server.Requests
{
    public class GetRequest<TEntity>
    {
        private string _path;
        public GetRequest(string endpoint)
        {
            _path = "https://swapi.co/api/" + endpoint;
        }

        private HttpClient client = PreparedClient.GetClient();

        public async Task<TEntity> GetById(int id)
        {
            TEntity entity = default(TEntity);
            HttpResponseMessage res = await client.GetAsync(_path + id);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    entity = await res.Content.ReadAsAsync<TEntity>();
                    return entity;
                }
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(TEntity);
            }
        }

    }
}