using System;

namespace RoomsAPI.Models
{
    public class Room
    {
        public string RoomId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string TypeName { get; set; }
        public Type Type { get; set; }

        public static Room Create(string name, int capacity, string typeName)
        {
            Room room = new Room
            {
                RoomId = Guid.NewGuid().ToString(),
                Name = name,
                Capacity = capacity,
                TypeName = typeName
            };
            return room;
        }
    }
}
