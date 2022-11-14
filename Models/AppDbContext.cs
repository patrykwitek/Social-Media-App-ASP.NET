using Microsoft.EntityFrameworkCore;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Photos { get; set; }
        public string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "photos.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder
       options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
