using System;
using System.Collections.Generic;

namespace GroupsAPI.Models
{
    public class Group
    {
        public string GroupId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string TutorName { get; set; }
        public string SpecialisationName { get; set; }
        public Specialisation Specialisation { get; set; }
        public List<Subgroup> Subgroups { get; set; }

        public static Group Create(string name, int year, string tutorName, string specialisationName)
        {
            Group group = new Group
            {
                GroupId = Guid.NewGuid().ToString(),
                Name = name,
                Year = year,
                TutorName = tutorName,
                SpecialisationName = specialisationName
            };
            return group;
        }
    }
}
