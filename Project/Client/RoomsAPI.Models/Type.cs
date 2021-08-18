using System;

namespace RoomsAPI.Models
{
    public class Type
    {
        public Guid TypeId { get; set; }
        public string Name { get; set; }

        public static Type Create(string name)
        {
            Type type = new Type
            {
                TypeId = Guid.NewGuid(),
                Name = name
            };
            return type;
        }
    }
}
