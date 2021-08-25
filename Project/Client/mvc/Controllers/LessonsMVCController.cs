using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TeachingAPI.Client;
using TeachingAPI.Models;

namespace mvc.Controllers
{
    [Authorize]
    public class LessonsMVCController : Controller
    {
        public readonly ClassLessonsAPIClient apiClient;
        public LessonsMVCController(ClassLessonsAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllLessons();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(new ClassLesson());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassLesson lesson)
        {
            if (ModelState.IsValid)
            {
                await apiClient.CreateLesson(lesson);
                return RedirectToAction("Index");
            }
            return View(lesson);
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
            await apiClient.DeleteLesson(id);
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
        public async Task<IActionResult> Edit(ClassLesson lesson)
        {
            await apiClient.UpdateLesson(lesson);
            return RedirectToAction("Index");
        }
    }
}
