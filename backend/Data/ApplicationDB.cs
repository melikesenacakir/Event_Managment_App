using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class ApplicationDB(DbContextOptions options) : DbContext(options) //tablolara ulaşabilmemizi sağlar. Bu sayfayı yazdıktan sonra program.cs ye eklememiz lazım
    {
        public DbSet<Models.Users> Users { get; set; }
        public DbSet<Models.Events> Events { get; set; }
        public DbSet<Models.User_Events> User_Events { get; set; }
        public DbSet<Models.Feedbacks> Feedbacks { get; set; }
        public DbSet<Models.Messages> Messages { get; set; }
        public DbSet<Models.Questions> Questions { get; set; }
        public DbSet<Models.Answers> Answers { get; set; }

    }
}