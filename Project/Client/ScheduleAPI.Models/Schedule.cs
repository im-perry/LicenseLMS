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
        public Guid ScheduleId { get; set; }
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Subgroup> Subgroups { get; set; }
        public int TeacherId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static Schedule Create(Guid activityId, int teacherId, DateTime start, DateTime end)
        {
            Schedule schedule = new Schedule
            {
                ScheduleId = Guid.NewGuid(),
                ActivityId = activityId,
                TeacherId = teacherId,
                Start = start,
                End = end
            };
            return schedule;
        }
    }
}
