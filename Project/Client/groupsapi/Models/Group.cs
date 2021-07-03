using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace groupsapi.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int TutorId { get; set; }
        public int SpecialisationId { get; set; }
        public Specialisation Specialisation { get; set; }
        public List<Subgroup> Subgroups { get; set; }
    }
}
