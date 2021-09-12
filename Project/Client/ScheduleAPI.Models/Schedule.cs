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

        [Display(Name = "Activity Name")]
        public string ActivityName { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Subgroup> Subgroups { get; set; }

        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        [Display(Name = "Day Of The Week")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd}")]
        public DateTime DayOfTheWeek { get; set; }

        [Display(Name = "Start Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime EndTime { get; set; }

        public static Schedule Create(string activityName, string teacherName, DateTime dayOfTheWeek, DateTime start, DateTime end)
        {
            Schedule schedule = new Schedule
            {
                ScheduleId = Guid.NewGuid(),
                ActivityName = activityName,
                TeacherName = teacherName,
                DayOfTheWeek = dayOfTheWeek,
                StartTime = start,
                EndTime = end
            };
            return schedule;
        }
    }
}
