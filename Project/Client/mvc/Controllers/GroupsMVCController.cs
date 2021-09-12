using GroupsAPI.Client;
using GroupsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    [Authorize]
    public class GroupsMVCController : Controller
    {
        public readonly GroupsAPIClient apiClient;
        public readonly SpecializationsAPIClient specializationClient;
        public GroupsMVCController(GroupsAPIClient apiClient, SubgroupsAPIClient subgroupClient, SpecializationsAPIClient specializationClient)
        {
            this.apiClient = apiClient;
            this.specializationClient = specializationClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllGroups();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            Group group = new Group();
            group.Specialisations = await specializationClient.GetAllSpecialisations();

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Group group)
        {
            if (ModelState.IsValid)
            {
                await apiClient.CreateGroup(group);
                return RedirectToAction("Index");
            }
            return View(group);
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
            await apiClient.DeleteGroup(id);
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
            data.Specialisations = await specializationClient.GetAllSpecialisations();

            return View(data);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Group group)
        {
            await apiClient.UpdateGroup(group);
            return RedirectToAction("Index");
        }
    }
}
