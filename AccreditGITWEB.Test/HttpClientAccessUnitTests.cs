using NUnit.Framework;
using Moq;
using System.Net.Http;
using AccreditGITWEB.Helpers;
using AccreditGITWEB.Controllers;
using AccreditGITWEB.Models;
using AccreditGITWEB.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace AccreditGITWEB.Test
{
    public class HttpClientAccessUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("DSAN-TR", "Denis Shanov", "USA")]
        [TestCase("robconery", "Rob Conery", "Honolulu, HI")]
        public async Task IGitHubServices_GetUser_Return_True(string username, string name, string location)
        {
            string url = $"https://api.github.com/users/";

            var expectedTestCaseUser = new User() { name = name, location = location };

            string expectedResult = JsonConvert.SerializeObject(expectedTestCaseUser);

            var mockHttpClientWrapper = new Mock<IHttpClientAccess>();
            mockHttpClientWrapper.Setup(t => t.GetAsync(It.Is<string>(s => s.StartsWith(url)))).ReturnsAsync(expectedResult);

            IGitHubServices hubService = new GitHubServices(mockHttpClientWrapper.Object);
            var actualUserData = await hubService.GetUser(username);

            Assert.IsTrue(expectedTestCaseUser.name == actualUserData.name);
            Assert.IsTrue(expectedTestCaseUser.location == actualUserData.location);
        }





        [Test]
        public async Task IGitHubServices_GetRepos_Return_True()
        {
            string url = $"https://api.github.com/users/";

            var expectedTestCaseRepos = new List<Repo>() { new Repo() { name = "VSWEBPerformanceTest_AuthCookie", stargazers_count = 0 }, new Repo() { name = "JMeterAuto", stargazers_count = 0 } };

            string expectedResult = JsonConvert.SerializeObject(expectedTestCaseRepos);

            var mockHttpClientWrapper = new Mock<IHttpClientAccess>();
            mockHttpClientWrapper.Setup(t => t.GetAsync(It.Is<string>(s => s.StartsWith(url)))).ReturnsAsync(expectedResult);

            IGitHubServices hubService = new GitHubServices(mockHttpClientWrapper.Object);
            var actualRepoDatas = await hubService.GetRepos("https://api.github.com/users/dsan-tr/repos");


            Assert.IsTrue(expectedTestCaseRepos.Count == actualRepoDatas.Count);
            Assert.That(expectedTestCaseRepos.FirstOrDefault().name == actualRepoDatas.FirstOrDefault().name);
        }
    }
}