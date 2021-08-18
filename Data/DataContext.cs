using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class DataContext : DbContext
    {
        #region Proparties
        public DbSet<Car> Cars { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = RentACar; User = sa; Password = Micr0!nvest; Trusted_Connection = true; Integrated Security=False");
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
