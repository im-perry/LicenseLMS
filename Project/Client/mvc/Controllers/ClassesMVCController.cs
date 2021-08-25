using GroupsAPI.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TeachingAPI.Client;
using TeachingAPI.Models;

namespace mvc.Controllers
{
    [Authorize]
    public class ClassesMVCController : Controller
    {
        public readonly ClassesAPIClient apiClient;
        public ClassesMVCController(ClassesAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllClasses();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(new Class());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Class classs)
        {
            if (ModelState.IsValid)
            {
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

        public async Task<IActionResult> Edit(Guid id)
        {
            var data = await apiClient.GetDetails(id);
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
