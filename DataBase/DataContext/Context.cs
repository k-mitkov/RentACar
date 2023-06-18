using DataBase.Configurations;
using DataBase.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataBase.DataContext
{
    public class Context : IdentityDbContext<User>
    {
        #region Proparties
        public DbSet<Car> Cars { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = RentACarTest2; Trusted_Connection = true;");
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

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Email = "Admin@gmail.com",
            //    UserName = "admin",
            //    PasswordHash = "admin"
            //});

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
