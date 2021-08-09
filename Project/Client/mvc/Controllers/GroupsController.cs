using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class GroupsController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<GroupsController> _logger;

        public GroupsController(ITokenService tokenService, ILogger<GroupsController> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var data = new List<GroupData>();

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

                    data = JsonConvert.DeserializeObject<List<GroupData>>(model);

                    return View(data);
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }
    }
}
