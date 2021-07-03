using activitiesapi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace activitiesapi.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        protected readonly ActivitiesContext _dbContext;

        public ActivityRepository(ActivitiesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Activity GetActivityById(Guid activityId)
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

        public void Delete(Guid activityId)
        {
            var activity = _dbContext.Activities.Find(activityId);
            _dbContext.Activities.Remove(activity);
            Save();
        }

        public void Update(Activity activity)
        {
            _dbContext.Entry(activity).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
