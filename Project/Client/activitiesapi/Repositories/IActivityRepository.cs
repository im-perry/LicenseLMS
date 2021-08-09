using ActivitiesAPI.Models;
using System;
using System.Collections.Generic;

namespace activitiesapi.Repositories
{
    public interface IActivityRepository
    {
        Activity GetActivityById(Guid activityId);
        IEnumerable<Activity> GetAll();
        void Add(Activity activity);
        void Delete(Guid activityId);
        void Update(Activity activity);
        void Save();
    }
}
