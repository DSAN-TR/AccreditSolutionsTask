using AccreditGITWEB.Helpers;
using AccreditGITWEB.Models;
using AccreditGITWEB.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AccreditGITWEB.Controllers
{
    public class HomeController : Controller
    {
        private IGitHubServices hubServices;

        public HomeController(IGitHubServices _hubServices)
        {
            hubServices = _hubServices;
        }


        public HomeController()
        {
            hubServices = new GitHubServices(new HttpClientAccess());
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<PartialViewResult> GetRepos(string repoUrl)
        {
            try
            {
                var UserRepos = await hubServices.GetRepos(repoUrl);

                //Business Requirement: Top 5 hightest stargazers_count repos.
                var HighestTopFiveRepos = UserRepos.OrderByDescending(o => o.stargazers_count).Take(5).ToList();

                return PartialView("_PartialRepos", HighestTopFiveRepos);
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Can be GET Method. I just want to arrange a POST version.
        [HttpPost]
        public async Task<ActionResult> PostUser(UserViewModel uservm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return null;
                }
                
                var UserProfile = await hubServices.GetUser(uservm.username);

                return PartialView("_PartialUser", UserProfile);
            }
            catch (Exception)
            {
                return null;
            }
        }





    }
}