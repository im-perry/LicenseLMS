using ScheduleAPI.Models;
using System;
using System.Collections.Generic;

namespace scheduleapi.Repositories
{
    public interface IScheduleRepository
    {
        Schedule GetScheduleById(Guid scheduleId);
        IEnumerable<Schedule> GetAll();
        void Add(Schedule schedule);
        void Delete(Guid scheduleId);
        void Update(Schedule schedule);
        void Save();
    }
}
