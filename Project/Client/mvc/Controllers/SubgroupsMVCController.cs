using GroupsAPI.Client;
using GroupsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    [Authorize]
    public class SubgroupsMVCController : Controller
    {
        public readonly SubgroupsAPIClient apiClient;
        public SubgroupsMVCController(SubgroupsAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllSubgroups();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(new Subgroup());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subgroup subgroup)
        {
            if (ModelState.IsValid)
            {
                await apiClient.CreateSubgroup(subgroup);
                return RedirectToAction("Index");
            }
            return View(subgroup);
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
            await apiClient.DeleteSubgroup(id);
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
        public async Task<IActionResult> Edit(Subgroup subgroup)
        {
            await apiClient.UpdateSubgroup(subgroup);
            return RedirectToAction("Index");
        }
    }
}
