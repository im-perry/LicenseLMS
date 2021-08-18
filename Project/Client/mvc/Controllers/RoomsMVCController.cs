using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomsAPI.Client;
using RoomsAPI.Models;
using System;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    [Authorize]
    public class RoomsMVCController : Controller
    {
        public readonly RoomsAPIClient apiClient;
        public RoomsMVCController(RoomsAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await apiClient.GetAllRooms();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(new Room());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            if (ModelState.IsValid)
            {
                await apiClient.CreateRoom(room);
                return RedirectToAction("Index");
            }
            return View(room);
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
            await apiClient.DeleteRoom(id);
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
        public async Task<IActionResult> Edit(Room room)
        {
            await apiClient.UpdateRoom(room);
            return RedirectToAction("Index");
        }
    }
}
