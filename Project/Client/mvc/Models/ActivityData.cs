using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class ActivityData
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
    }
}
