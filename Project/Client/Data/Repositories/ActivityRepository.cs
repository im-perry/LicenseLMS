using activitiesapi;
using activitiesapi.Models;
using Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        protected readonly ActivitiesContext dbContext;

        public Activity GetActivityById(Guid activityId)
        {
            var activity = dbContext.Activities
                         .Where(c => c.ActivityId == activityId)
                         .SingleOrDefault();
            return activity;
        }

        public Activity Add(Activity itemToAdd)
        {
            var entity = dbContext.Add<Activity>(itemToAdd);
            dbContext.SaveChanges();
            return entity.Entity;
        }

        public bool Delete(Activity itemToDelete)
        {
            dbContext.Remove<Activity>(itemToDelete);
            dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<Activity> GetAll()
        {
            return dbContext.Set<Activity>()
                            .AsEnumerable();
        }

        public Activity Update(Activity itemToUpdate)
        {
            var entity = dbContext.Update<Activity>(itemToUpdate);
            dbContext.SaveChanges();
            return entity.Entity;
        }

    }
}
