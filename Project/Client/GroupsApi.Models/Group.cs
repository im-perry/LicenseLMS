using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroupsAPI.Models
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        [Display(Name = "Tutor Name")]
        public string TutorName { get; set; }

        [Display(Name = "Specialisation Name")]
        public string SpecialisationName { get; set; }
        public IEnumerable<Specialisation> Specialisations { get; set; }

        public static Group Create(string name, int year, string tutorName, string specialisationName)
        {
            Group group = new Group
            {
                GroupId = Guid.NewGuid(),
                Name = name,
                Year = year,
                TutorName = tutorName,
                SpecialisationName = specialisationName
            };
            return group;
        }
    }
}
