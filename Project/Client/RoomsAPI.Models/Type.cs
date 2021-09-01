using System;

namespace RoomsAPI.Models
{
    public class Type
    {
        public string TypeId { get; set; }
        public string Name { get; set; }

        public static Type Create(string name)
        {
            Type type = new Type
            {
                TypeId = Guid.NewGuid().ToString(),
                Name = name
            };
            return type;
        }
    }
}
