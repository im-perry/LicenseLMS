using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace scheduleapi.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        protected readonly ScheduleContext _dbContext;

        public ScheduleRepository(ScheduleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Schedule GetScheduleById(string scheduleId)
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

        public void Delete(string scheduleId)
        {
            var schedule = _dbContext.Schedules.Find(scheduleId);
            _dbContext.Schedules.Remove(schedule);
            Save();
        }

        public void Update(Schedule schedule)
        {
            var update = _dbContext.Schedules
                            .Where(update => update.ScheduleId.Equals(schedule.ScheduleId))
                            .SingleOrDefault();

            if (update != default(Schedule))
            {
                update.ActivityName = schedule.ActivityName;
                update.Groups = schedule.Groups;
                update.Subgroups = schedule.Subgroups;
                update.TeacherName = schedule.TeacherName;
                update.Start = schedule.Start;
                update.End = schedule.End;
            }

            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
