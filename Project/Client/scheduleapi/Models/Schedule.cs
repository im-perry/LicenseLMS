using activitiesapi.Models;
using groupsapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scheduleapi.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Subgroup> Subgroups { get; set; }
        public int TeacherId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
