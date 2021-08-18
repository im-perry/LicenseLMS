using System;

namespace RoomsAPI.Models
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Guid TypeId { get; set; }
        public Type Type { get; set; }

        public static Room Create(string name, int capacity, Guid typeId)
        {
            Room room = new Room
            {
                RoomId = Guid.NewGuid(),
                Name = name,
                Capacity = capacity,
                TypeId = typeId
            };
            return room;
        }
    }
}
