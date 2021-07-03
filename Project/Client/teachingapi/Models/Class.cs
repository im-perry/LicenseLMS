using activitiesapi.Models;
using groupsapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teachingapi.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ClassLesson> ClassLessons { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Subgroup> Subgroups { get; set; }

    }
}
