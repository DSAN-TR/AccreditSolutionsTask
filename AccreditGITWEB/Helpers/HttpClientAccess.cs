using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AccreditGITWEB.Helpers
{
    public class HttpClientAccess : IHttpClientAccess
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public void SetDefaultRequestHeaders(string key, string value)
        {
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, value);
        }

        public async Task<string> GetAsync(string Url)
        {
            try
            {
                var Response = await httpClient.GetAsync(Url).ConfigureAwait(false);
                Response.EnsureSuccessStatusCode();
                return await Response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> PostAsnyc(string Url, HttpContent content)
        {
            try
            {
                var Response = await httpClient.PostAsync(Url, content).ConfigureAwait(false);
                Response.EnsureSuccessStatusCode();
                return await Response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}