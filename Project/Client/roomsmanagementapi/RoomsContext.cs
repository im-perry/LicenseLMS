using Microsoft.EntityFrameworkCore;
using RoomsAPI.Models;

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
