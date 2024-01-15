using lista10.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace lista10.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Class> Class { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<lista10.Models.Lesson> Lesson { get; set; }

    }
}
