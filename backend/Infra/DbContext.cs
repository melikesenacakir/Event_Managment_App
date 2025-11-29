using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database
{
    public class ApplicationDB(DbContextOptions options) : DbContext(options) //tablolara ulaşabilmemizi sağlar. Bu sayfayı yazdıktan sonra program.cs ye eklememiz gerekiyormuş
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<User_Events> User_Events { get; set; }
        public DbSet<Feedbacks> Feedbacks { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Events>()
                .HasOne(e => e.Users)
                .WithMany()
                .HasForeignKey(e => e.Created_by)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.Events)
                .WithMany()
                .HasForeignKey(f => f.Event_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedbacks>()
                .HasOne(f => f.Users)
                .WithMany()
                .HasForeignKey(f => f.User_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}