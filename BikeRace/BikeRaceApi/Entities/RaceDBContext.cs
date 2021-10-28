using BikeRaceApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRaceApi.Models
{
    public class RaceDBContext : DbContext
    {
        private string _connectionString = (@"Server=DESKTOP-L2JMNQT;Database=BikeRaceApiDB;Trusted_Connection=True;");
        public DbSet<Race> Races {get; set;} 
        public DbSet<Participant> Participants {get; set;}
        public DbSet<Result> Results {get; set;}

        //required fields
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Race>()
                .Property(r => r.Location)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Participant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Participant>()
                .Property(r => r.Surname)
                .IsRequired()
                .HasMaxLength(30);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
