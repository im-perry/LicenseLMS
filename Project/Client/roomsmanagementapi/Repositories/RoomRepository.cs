using Microsoft.EntityFrameworkCore;
using RoomsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace roomsmanagementapi.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly RoomsContext _dbContext;

        public RoomRepository(RoomsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Room GetRoomById(Guid roomId)
        {
            return _dbContext.Rooms.Find(roomId);
        }

        public IEnumerable<Room> GetAll()
        {
            return _dbContext.Rooms.ToList();
        }

        public void Add(Room room)
        {
            _dbContext.Add(room);
            Save();
        }

        public void Delete(Guid roomId)
        {
            var room = _dbContext.Rooms.Find(roomId);
            _dbContext.Rooms.Remove(room);
            Save();
        }

        public void Update(Room room)
        {
            var update = _dbContext.Rooms
                            .Where(update => update.RoomId.Equals(room.RoomId))
                            .SingleOrDefault();

            if (update != default(Room))
            {
                update.Name = room.Name;
                update.Capacity = room.Capacity;
                update.TypeName = room.TypeName;
            }

            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
