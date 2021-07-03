using activitiesapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace activitiesapi.Repositories
{
    public interface IActivityRepository
    {
        Activity GetActivityById(Guid accountId);
        IEnumerable<Activity> GetAll();
        void Add(Activity activity);
        void Delete(Guid activityId);
        void Update(Activity activity);
        void Save();
    }
}
