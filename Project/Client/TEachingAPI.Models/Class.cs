using ActivitiesAPI.Models;
using GroupsAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachingAPI.Models
{
    public class Class
    {
        [Key]
        public Guid ClassId { get; set; }

        [Display(Name = "")]
        public string ActivityName { get; set; }
        public IEnumerable<Activity> Activities { get; set; }

        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ClassLesson> ClassLessons { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Subgroup> Subgroups { get; set; }

        public static Class Create(string activityName, string authorName, string name, string description)
        {
            Class classs = new Class
            {
                ClassId = Guid.NewGuid(),
                ActivityName = activityName,
                AuthorName = authorName,
                Name = name,
                Description = description
            };
            return classs;
        }
    }
}
