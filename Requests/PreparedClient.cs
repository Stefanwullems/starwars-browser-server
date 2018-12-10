using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace starwars_browser_server.Requests
{
    public static class PreparedClient
    {
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}