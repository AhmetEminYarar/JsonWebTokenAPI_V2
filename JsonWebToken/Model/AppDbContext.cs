using Microsoft.EntityFrameworkCore;

namespace JsonWebToken.Model
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Role> Roles{ get; set; }
    }
}
