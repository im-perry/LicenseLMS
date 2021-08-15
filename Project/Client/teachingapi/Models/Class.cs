using ActivitiesAPI.Models;
using GroupsAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
