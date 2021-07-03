using activitiesapi.Models;
using Microsoft.EntityFrameworkCore;

namespace activitiesapi
{
    public class ActivitiesContext : DbContext
    {
        public ActivitiesContext(DbContextOptions<ActivitiesContext> options) : base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; }

    }
}
