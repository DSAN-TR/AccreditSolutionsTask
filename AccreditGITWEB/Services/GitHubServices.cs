using AccreditGITWEB.Helpers;
using AccreditGITWEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AccreditGITWEB.Services
{
    public class GitHubServices : IGitHubServices
    {
        private readonly IHttpClientAccess httpClientAccess;

        public GitHubServices(IHttpClientAccess _httpClientAccess)
        {
            httpClientAccess = _httpClientAccess;

            httpClientAccess.SetDefaultRequestHeaders("Accept", "application/json; charset=utf-8");
            httpClientAccess.SetDefaultRequestHeaders("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
        }

        public async Task<List<Repo>> GetRepos(string repoUrl)
        {
            try
            {
                var responseText = await httpClientAccess.GetAsync($"{repoUrl}").ConfigureAwait(false);

                var UserRepos = JsonConvert.DeserializeObject<List<Repo>>(responseText);

                return UserRepos;
            }
            catch { return null; }
        }

        public async Task<User> GetUser(string username)
        {
            try
            {
                var responseText = await httpClientAccess.GetAsync($"https://api.github.com/users/{username}").ConfigureAwait(false);
                var UserProfile = JsonConvert.DeserializeObject<User>(responseText);

                return UserProfile;
            }
            catch { return null; }
        }
    }
}