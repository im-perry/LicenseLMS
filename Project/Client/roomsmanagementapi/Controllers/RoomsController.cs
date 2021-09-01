using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomsAPI.Models;
using roomsmanagementapi.Repositories;
using System;
using System.Transactions;

namespace roomsmanagementapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // GET: Rooms
        [HttpGet]
        public IActionResult GetRooms()
        {
            var rooms = _roomRepository.GetAll();
            return new OkObjectResult(rooms);
        }

        // GET: Rooms/5
        [HttpGet("{id}")]
        public IActionResult GetRoom([FromRoute] string id)
        {
            var room = _roomRepository.GetRoomById(id);
            return new OkObjectResult(room);
        }

        // PUT: Rooms
        [HttpPut("{room}")]
        public IActionResult PutRoom([FromBody] Room room)
        {
            if (room != null)
            {
                using (var scope = new TransactionScope())
                {
                    _roomRepository.Update(room);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // POST: Rooms
        [HttpPost]
        public IActionResult PostRoom([FromBody] Room room)
        {
            using (var scope = new TransactionScope())
            {
                _roomRepository.Add(room);
                scope.Complete();
                return CreatedAtAction(nameof(GetRoom), new { id = room.RoomId }, room);
            }
        }

        // DELETE: Rooms/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom([FromRoute] string id)
        {
            _roomRepository.Delete(id);
            return new OkResult();
        }
    }
}
