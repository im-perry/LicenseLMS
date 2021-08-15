using GroupsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace groupsapi
{
    public class GroupsContext : DbContext
    {
        public GroupsContext(DbContextOptions<GroupsContext> options) : base(options)
        {

        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subgroup> Subgroups { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subgroup>()
                .HasOne(p => p.Group)
                .WithMany(b => b.Subgroups);
        }
    }
}
