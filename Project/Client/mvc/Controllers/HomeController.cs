using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TokensService;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITokenService tokenService, ILogger<HomeController> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        public async Task Logout()
        {
            await HttpContext.SignOutAsync("cookie");
            await HttpContext.SignOutAsync("oidc");
        }


        /*[Authorize]
        public async Task<IActionResult> Activities()
        {
            var data = new List<Activity>();

            //IEnumerable<ActivityData> data = null;

            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("activitiesapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                var result = client
                    .GetAsync("https://localhost:5445/activities")
                    .Result;

                client.BaseAddress = new Uri("https://localhost:5445/");

                var response = client.GetAsync("activities");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsStringAsync().Result;

                    data = JsonConvert.DeserializeObject<List<Activity>>(model);

                    return View(data);

                    var readTask = result.Content.ReadAsAsync<IList<ActivityData>>();
                    readTask.Wait();

                    data = readTask.Result;
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
            return View(data);
        }

        [Authorize]
        public async Task<IActionResult> Groups()
        {
            var data = new List<ActivityData>();

            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("groupsapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                var result = client
                    .GetAsync("https://localhost:5446/groups")
                    .Result;

                if (result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsStringAsync().Result;

                    data = JsonConvert.DeserializeObject<List<ActivityData>>(model);

                    return View(data);
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        [Authorize]
        public async Task<IActionResult> RoomsManagement()
        {
            var data = new List<ActivityData>();

            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("roomsmanagementapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                var result = client
                    .GetAsync("https://localhost:5447/rooms")
                    .Result;

                if (result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsStringAsync().Result;

                    data = JsonConvert.DeserializeObject<List<ActivityData>>(model);

                    return View(data);
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        [Authorize]
        public async Task<IActionResult> Schedule()
        {
            var data = new List<ActivityData>();

            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("scheduleapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                var result = client
                    .GetAsync("https://localhost:5448/schedule")
                    .Result;

                if (result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsStringAsync().Result;

                    data = JsonConvert.DeserializeObject<List<ActivityData>>(model);

                    return View(data);
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }

        [Authorize]
        public async Task<IActionResult> Teaching()
        {
            var data = new List<ActivityData>();

            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("teachingapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                var result = client
                    .GetAsync("https://localhost:5449/teaching")
                    .Result;

                if (result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsStringAsync().Result;

                    data = JsonConvert.DeserializeObject<List<ActivityData>>(model);

                    return View(data);
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
