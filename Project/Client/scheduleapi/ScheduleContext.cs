using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Models;

namespace scheduleapi
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {

        }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
