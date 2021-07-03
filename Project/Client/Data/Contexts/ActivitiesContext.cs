using activitiesapi.Models;
using Microsoft.EntityFrameworkCore;

namespace activitiesapi
{
    public class ActivitiesContext : DbContext
    {
        public ActivitiesContext(DbContextOptions<ActivitiesContext> options) : base(options)
        {

        }
        //public DbSet<Type> Types { get; set; }
        //public DbSet<Level> Levels { get; set; }
        public DbSet<Activity> Activities { get; set; }

    }
}
