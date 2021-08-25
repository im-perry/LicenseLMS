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
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ClassLesson> ClassLessons { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Subgroup> Subgroups { get; set; }

        public static Class Create(Guid activityId, Activity activity, int authorId, string name, string description)
        {
            Class classs = new Class
            {
                ClassId = Guid.NewGuid(),
                ActivityId = activityId,
                Activity = activity,
                AuthorId = authorId,
                Name = name,
                Description = description
            };
            return classs;
        }
    }
}
