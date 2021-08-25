using Microsoft.EntityFrameworkCore;
using TeachingAPI.Models;

namespace teachingapi
{
    public class TeachingContext : DbContext
    {
        public TeachingContext(DbContextOptions<TeachingContext> options) : base(options)
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassLesson> ClassLessons { get; set; }
    }
}
