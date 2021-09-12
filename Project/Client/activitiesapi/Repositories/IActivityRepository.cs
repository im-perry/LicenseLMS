using ActivitiesAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace activitiesapi.Repositories
{
    public interface IActivityRepository
    {
        Activity GetActivityById(Guid activityId);
        Activity GetActivityByName(string activityName);
        IEnumerable<Activity> GetAll();
        void Add(Activity activity);
        void Delete(Guid activityId);
        void Update(Activity activity);
        void Save();
    }
}
