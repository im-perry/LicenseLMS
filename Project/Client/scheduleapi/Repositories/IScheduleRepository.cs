using ScheduleAPI.Models;
using System;
using System.Collections.Generic;

namespace scheduleapi.Repositories
{
    public interface IScheduleRepository
    {
        Schedule GetScheduleById(string scheduleId);
        IEnumerable<Schedule> GetAll();
        void Add(Schedule schedule);
        void Delete(string scheduleId);
        void Update(Schedule schedule);
        void Save();
    }
}
