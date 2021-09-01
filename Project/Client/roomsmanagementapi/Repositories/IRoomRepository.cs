using RoomsAPI.Models;
using System;
using System.Collections.Generic;

namespace roomsmanagementapi.Repositories
{
    public interface IRoomRepository
    {
        Room GetRoomById(string roomId);
        IEnumerable<Room> GetAll();
        void Add(Room room);
        void Delete(string roomId);
        void Update(Room room);
        void Save();
    }
}
