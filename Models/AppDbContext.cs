using Microsoft.EntityFrameworkCore;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
    }
}