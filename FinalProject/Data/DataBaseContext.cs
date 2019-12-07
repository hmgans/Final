/**
 * Author:    Jonathon Smith and Giovanni Varuloa and Hank Gansert
 * Partner:   None
 * Date:      12/4/19
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Jonathon Smith - This work may not be copied for use in Academic Coursework.
 *
 * I, Jonathon Smith and Giovanni Varuloa and Hank Gansert, certify that I wrote this code from scratch and did not copy it in part or whole from 
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *    Database Context
 */

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
