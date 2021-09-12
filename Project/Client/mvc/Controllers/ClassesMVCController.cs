using ActivitiesAPI.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TeachingAPI.Client;
using TeachingAPI.Models;

namespace mvc.Controllers
{
    [Authorize]
    public class ClassesMVCController : Controller
    {
        public readonly ClassesAPIClient apiClient;
        public readonly ActivitiesAPIClient activitiesClient;

        public ClassesMVCController(ClassesAPIClient apiClient, ActivitiesAPIClient activitiesClient)
        {
            this.apiClient = apiClient;
            this.activitiesClient = activitiesClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllClasses();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            Class classs = new Class();
            classs.Activities = await activitiesClient.GetAllActivities();

            return View(classs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Class classs)
        {
            if (ModelState.IsValid)
            {
                classs.AuthorName = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await apiClient.CreateClass(classs);
                return RedirectToAction("Index");
            }

            return View(classs);
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
            await apiClient.DeleteClass(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var data = await apiClient.GetDetails(id);
            return View(data);
        }

        public async Task<IActionResult> Activity(string name)
        {
            var data = await activitiesClient.GetActivityByName(name);
            return View(data);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await apiClient.GetDetails(id);
            data.Activities = await activitiesClient.GetAllActivities();

            return View(data);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Class classs)
        {
            await apiClient.UpdateClass(classs);
            return RedirectToAction("Index");
        }
    }
}
