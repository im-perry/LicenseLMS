using Microsoft.EntityFrameworkCore;
using scheduleapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scheduleapi.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        protected readonly ScheduleContext _dbContext;

        public ScheduleRepository(ScheduleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Schedule GetScheduleById(int scheduleId)
        {
            return _dbContext.Schedules.Find(scheduleId);
        }

        public IEnumerable<Schedule> GetAll()
        {
            return _dbContext.Schedules.ToList();
        }

        public void Add(Schedule schedule)
        {
            _dbContext.Add(schedule);
            Save();
        }

        public void Delete(int scheduleId)
        {
            var schedule = _dbContext.Schedules.Find(scheduleId);
            _dbContext.Schedules.Remove(schedule);
            Save();
        }

        public void Update(Schedule schedule)
        {
            _dbContext.Entry(schedule).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
