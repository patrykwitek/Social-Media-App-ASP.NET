using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<LikeForComment> LikesForComment { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Comment>()
            .HasOne(x => x.Post)
            .WithMany(a => a.Comments)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
            .Entity<Like>()
            .HasOne(x => x.Post)
            .WithMany(a => a.Likes)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
            .Entity<LikeForComment>()
            .HasOne(x => x.Comment)
            .WithMany(a => a.Likes)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}