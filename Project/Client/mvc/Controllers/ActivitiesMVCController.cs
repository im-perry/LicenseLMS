using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ActivitiesAPI.Client;
using System;
using ActivitiesAPI.Models;

namespace mvc.Controllers
{
    [Authorize]
    public class ActivitiesMVCController : Controller
    {
        public readonly ActivitiesAPIClient apiClient;
        public ActivitiesMVCController(ActivitiesAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllActivities();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(new Activity());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                await apiClient.CreateActivity(activity);
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await apiClient.GetDetails(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await apiClient.DeleteActivity(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var data = await apiClient.GetDetails(id);
            return View(data);
        }

        public async Task<IActionResult> DetailsByName(string name)
        {
            var data = await apiClient.GetActivityByName(name);
            return View(data);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await apiClient.GetDetails(id);
            return View(data);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Activity activity)
        {
            await apiClient.UpdateActivity(activity);
            return RedirectToAction("Index");
        }
    }
}
