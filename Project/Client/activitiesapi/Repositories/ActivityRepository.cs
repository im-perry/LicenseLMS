using ActivitiesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace activitiesapi.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ActivitiesContext _dbContext;

        public ActivityRepository(ActivitiesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Activity GetActivityById(string activityId)
        {
            return _dbContext.Activities.Find(activityId);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _dbContext.Activities.ToList();
        }

        public void Add(Activity activity)
        {
            _dbContext.Add(activity);
            Save();
        }

        public void Delete(string activityId)
        {
            var activity = _dbContext.Activities.Find(activityId);
            _dbContext.Activities.Remove(activity);
            Save();
        }

        public void Update(Activity activity)
        {
            var update = _dbContext.Activities
                            .Where(update => update.ActivityId.Equals(activity.ActivityId))
                            .SingleOrDefault();

            if(update != default(Activity))
            {
                update.Name = activity.Name;
                update.Duration = activity.Duration;
                update.Year = activity.Year;
                update.Level = activity.Level;
                update.Type = activity.Type;
            }
            
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
