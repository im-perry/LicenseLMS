using ActivitiesAPI.Models;
using System;
using System.Collections.Generic;

namespace activitiesapi.Repositories
{
    public interface IActivityRepository
    {
        Activity GetActivityById(string activityId);
        IEnumerable<Activity> GetAll();
        void Add(Activity activity);
        void Delete(string activityId);
        void Update(Activity activity);
        void Save();
    }
}
