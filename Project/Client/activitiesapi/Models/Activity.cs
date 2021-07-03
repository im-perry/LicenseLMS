using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace activitiesapi.Models
{
    public class Activity
    {
        public enum LevelType
        {
            License,
            Master
        }

        public enum ActivityType
        {
            Course,
            Seminary,
            Labour
        }

        public Guid ActivityId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public LevelType Level { get; set; }
        public ActivityType Type { get; set; }

        public static Activity Create(string name, int duration, int year, LevelType level, ActivityType type)
        {
            Activity activity = new Activity
            {
                ActivityId = Guid.NewGuid(),
                Name = name,
                Duration = duration,
                Year = year,
                Level = level,
                Type = type
            };
            return activity;
        }
    }
}
