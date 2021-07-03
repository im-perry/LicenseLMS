using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teachingapi.Models;

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
