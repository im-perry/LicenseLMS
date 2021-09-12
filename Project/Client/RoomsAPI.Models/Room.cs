using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RoomsAPI.Models
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        [Display(Name = "Type Name")]
        public string TypeName { get; set; }
        public IEnumerable<Type> Types { get; set; }

        public static Room Create(string name, int capacity, string typeName)
        {
            Room room = new Room
            {
                RoomId = Guid.NewGuid(),
                Name = name,
                Capacity = capacity,
                TypeName = typeName
            };
            return room;
        }
    }
}
