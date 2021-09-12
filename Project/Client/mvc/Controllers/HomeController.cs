using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using TokensService;
using static IdentityModel.OidcConstants;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITokenService tokenService, ILogger<HomeController> logger, HttpClient httpClient)
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

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Groups()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            return View();
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync("cookie");
            await HttpContext.SignOutAsync("oidc");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
