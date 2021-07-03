using activitiesapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstractions
{
    public interface IActivityRepository
    {
        Activity GetActivityById(Guid accountId);
        Activity Add(Activity itemToAdd);
        bool Delete(Activity itemToDelete);
        Activity Update(Activity itemToUpdate);
        IEnumerable<Activity> GetAll();
    }
}
