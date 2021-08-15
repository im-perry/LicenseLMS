using System;
using System.Collections.Generic;

namespace GroupsAPI.Models
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int TutorId { get; set; }
        public int SpecialisationId { get; set; }
        public Specialisation Specialisation { get; set; }
        public List<Subgroup> Subgroups { get; set; }

        public static Group Create(string name, int year, int tutorId , int specialisationId)
        {
            Group group = new Group
            {
                GroupId = Guid.NewGuid(),
                Name = name,
                Year = year,
                TutorId = tutorId,
                SpecialisationId = specialisationId
            };
            return group;
        }
    }
}
