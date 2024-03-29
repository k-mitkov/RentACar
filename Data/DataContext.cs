﻿using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    class DataContext : DbContext
    {
        #region Proparties
        public DbSet<Car> Cars { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Language> Languages { get; set; }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = RentACar; Trusted_Connection = true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany<Period>(c => c.Periods)
                .WithOne(p => p.Car)
                .HasForeignKey(p => p.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Period>()
                .HasOne<Car>(p => p.Car)
                .WithMany(c => c.Periods);
        }
        #endregion
    }
}
