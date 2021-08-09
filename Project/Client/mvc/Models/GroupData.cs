using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class GroupData
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int TutorId { get; set; }
        public int SpecialisationId { get; set; }
        public SpecialisationData Specialisation { get; set; }
        public List<SubgroupData> Subgroups { get; set; }
    }
}
