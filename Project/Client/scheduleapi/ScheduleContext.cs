using Microsoft.EntityFrameworkCore;
using scheduleapi.Models;

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
