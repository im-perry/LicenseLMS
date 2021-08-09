using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ActivitiesAPI.Client;

namespace mvc.Controllers
{
    public class ActivitiesMVCController : Controller
    {
        public ActivitiesAPIClient _apiClient;
        public ActivitiesMVCController(ActivitiesAPIClient apiClient)
        {
            _apiClient = apiClient;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var data = await _apiClient.GetAllActivities();
            return View(data);
        }
    }
}
