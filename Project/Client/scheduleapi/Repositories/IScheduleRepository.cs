using scheduleapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scheduleapi.Repositories
{
    public interface IScheduleRepository
    {
        Schedule GetScheduleById(int scheduleId);
        IEnumerable<Schedule> GetAll();
        void Add(Schedule schedule);
        void Delete(int scheduleId);
        void Update(Schedule schedule);
        void Save();
    }
}
