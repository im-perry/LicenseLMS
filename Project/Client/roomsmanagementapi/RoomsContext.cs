using Microsoft.EntityFrameworkCore;
using roomsmanagementapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomsmanagementapi
{
    public class RoomsContext : DbContext
    {
        public RoomsContext(DbContextOptions<RoomsContext> options) : base(options)
        {

        }
        public DbSet<Type> Types { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
