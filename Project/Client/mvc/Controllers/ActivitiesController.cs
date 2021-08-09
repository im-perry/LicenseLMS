using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ITokenService _tokenService;

        public ActivitiesController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

      //  [Authorize]
        public async Task<IActionResult> Index()
        {
            //var data = new List<ActivityData>();

            IEnumerable<ActivityData> data = null;

            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("activitiesapi.read");

                client
                    .SetBearerToken(tokenResponse.AccessToken);

                /*var result = client
                    .GetAsync("https://localhost:5445/activities")
                    .Result;*/
                
                client.BaseAddress = new Uri("https://localhost:5445/");

                var response = client.GetAsync("activities");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    /*var model = result.Content.ReadAsStringAsync().Result;

                    data = JsonConvert.DeserializeObject<List<ActivityData>>(model);

                    return View(data);*/

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
    }
}
