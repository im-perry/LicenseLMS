using System;

namespace GroupsAPI.Models
{
    public class Specialisation
    {
        public string SpecialisationId { get; set; }
        public string Name { get; set; }

        public static Specialisation Create(string name)
        {
            Specialisation specialisation = new Specialisation
            {
                SpecialisationId = Guid.NewGuid().ToString(),
                Name = name
            };
            return specialisation;
        }
    }
}
