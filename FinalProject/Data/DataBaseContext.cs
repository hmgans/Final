using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bot> Bots { get; set; }
        public DbSet<HighScore> HighScores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Level>().ToTable("Level");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Bot>().ToTable("Bot");
            modelBuilder.Entity<HighScore>().ToTable("HighScore");

        }
    }
}
