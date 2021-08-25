using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomsAPI.Client;
using System;
using System.Threading.Tasks;
using Type = RoomsAPI.Models.Type;

namespace mvc.Controllers
{
    [Authorize]
    public class RoomTypeMVCController : Controller
    {
        public readonly TypesAPIClient apiClient;
        public RoomTypeMVCController(TypesAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllTypes();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(new Type());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Type type)
        {
            if (ModelState.IsValid)
            {
                await apiClient.CreateType(type);
                return RedirectToAction("Index");
            }
            return View(type);
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
            await apiClient.DeleteType(id);
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
        public async Task<IActionResult> Edit(Type type)
        {
            await apiClient.UpdateRoom(type);
            return RedirectToAction("Index");
        }
    }
}
