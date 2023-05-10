using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite();
        //     base.OnConfiguring(optionsBuilder);
        // }
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
                new City("Varanasi") 
                {
                    Id= 1,
                    Description = "The Land of Lord Shiva"
                },
                new City("Patna")
                {
                    Id = 2,
                    Description = "Earlier known as Patliputra"
                },
                new City("Pune")
                {
                    Id = 3,
                    Description = "One of the IT hubs in India"
                }
                );
            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest("Shri Kashi Vishwanath Temple")
                {
                    Id = 1,
                    CityId= 1,
                    Description = "One of the 12 Jyotirlingas of Lord Shiva"
                },
                new PointOfInterest("Dasashwamedha Ghat")
                {
                    Id = 2,
                    CityId = 1,
                    Description = "One of the ghats on Holy Ganges"
                },
                new PointOfInterest("Shri Mahavir Temple")
                {
                    Id = 3,
                    CityId = 2,
                    Description = "Famous Temple of Lord Hanuman at Patna Junction"
                },
                new PointOfInterest("Gandhi Maidan")
                {
                    Id = 4,
                    CityId = 2,
                    Description = "Large ground for gatherings, festivals"
                },
                new PointOfInterest("Hinjewadi")
                {
                    Id = 5,
                    CityId = 3,
                    Description = "Full of offices of IT Companies"
                },
                new PointOfInterest("Koregaon Park")
                {
                    Id = 6,
                    CityId = 3,
                    Description = "The go to party and enjoyment place"
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}