using AccreditGITWEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccreditGITWEB.Services
{
    public interface IGitHubServices
    {
        Task<List<Repo>> GetRepos(string repoUrl);
        Task<User> GetUser(string username);
    }
}