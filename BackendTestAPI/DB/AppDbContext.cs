using BackendTestAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BackendTestAPI.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
       


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Products>()
                .Property(p => p.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Feedback>().HasKey(p => p.ID);
            modelBuilder.Entity<Feedback>()
             .Property(p => p.ReceivedDate)
             .HasDefaultValueSql("GETDATE()");

        }

    }
}