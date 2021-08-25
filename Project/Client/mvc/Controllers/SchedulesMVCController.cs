using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Client;
using ScheduleAPI.Models;
using System;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    [Authorize]
    public class SchedulesMVCController : Controller
    {
        public readonly ScheduleAPIClient apiClient;
        public SchedulesMVCController(ScheduleAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllSchedules();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(new Schedule());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                await apiClient.CreateSchedule(schedule);
                return RedirectToAction("Index");
            }
            return View(schedule);
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
            await apiClient.DeleteSchedule(id);
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
        public async Task<IActionResult> Edit(Schedule schedule)
        {
            await apiClient.UpdateSchedule(schedule);
            return RedirectToAction("Index");
        }
    }
}
