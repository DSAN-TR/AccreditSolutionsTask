using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AccreditGITWEB.Helpers
{
    public interface IHttpClientAccess
    {
        void SetDefaultRequestHeaders(string key, string value);
        Task<string> GetAsync(string Url);

        Task<string> PostAsnyc(string Url, HttpContent content);
    }
}
