using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomsmanagementapi.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
