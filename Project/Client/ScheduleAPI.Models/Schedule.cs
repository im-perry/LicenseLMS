using ActivitiesAPI.Models;
using GroupsAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace   ScheduleAPI.Models
{
    public class Schedule
    {
        [Key]
        public string ScheduleId { get; set; }
        public string ActivityName { get; set; }
        public Activity Activity { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Subgroup> Subgroups { get; set; }
        public string TeacherName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static Schedule Create(string activityName, string teacherName, DateTime start, DateTime end)
        {
            Schedule schedule = new Schedule
            {
                ScheduleId = Guid.NewGuid().ToString(),
                ActivityName = activityName,
                TeacherName = teacherName,
                Start = start,
                End = end
            };
            return schedule;
        }
    }
}
