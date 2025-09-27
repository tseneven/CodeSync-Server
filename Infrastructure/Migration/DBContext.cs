using API.Infrastructure.Entities;
using backend.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace Backend.Core.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Boards> Borders { get; set; }

        public DbSet<Likes> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Boards>()
                .HasOne(b => b.user)
                .WithMany(u => u.Boards)
                .HasForeignKey(b => b.UserID);

            modelBuilder.Entity<Likes>()
                .HasOne(l => l.user)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserID);

            modelBuilder.Entity<Likes>()
                .HasOne(l => l.Boards)
                .WithMany(b => b.Likes)
                .HasForeignKey(l => l.BoardID);

            base.OnModelCreating(modelBuilder);
        }
    }

}