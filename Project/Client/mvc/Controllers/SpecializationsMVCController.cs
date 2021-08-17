using GroupsAPI.Client;
using GroupsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    [Authorize]
    public class SpecializationsMVCController : Controller
    {
        public readonly SpecializationsAPIClient apiClient;
        public SpecializationsMVCController(SpecializationsAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllSpecialisations();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(new Specialisation());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Specialisation specialisation)
        {
            if (ModelState.IsValid)
            {
                await apiClient.CreateSpecialisation(specialisation);
                return RedirectToAction("Index");
            }
            return View(specialisation);
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
            await apiClient.DeleteSpecialisation(id);
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
        public async Task<IActionResult> Edit(Specialisation specialisation)
        {
            await apiClient.UpdateSpecialisation(specialisation);
            return RedirectToAction("Index");
        }
    }
}
