using CarRentWebApi.Data;
using CarRentWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CarRentWebApi.Tests.IntegrationTests
{
    public class IntegrationTests : IDisposable
    {

        private readonly ApplicationDbContext _context;

        public IntegrationTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
              .Options;

            _context = new ApplicationDbContext(options);

            // Examples
            _context.Cars.Add(new Car(1, "Model S", 500.4m));
            _context.Cars.Add(new Car(2, "Model Z", 140.7m));

            _context.Locations.Add(new Location(1, "Palma Airport"));

            _context.SaveChanges();
        }

        [Fact]
        public void GetCars_ShouldReturnAllAvailableCars()
        {
            var cars = _context.Cars.ToList();

            Assert.NotNull(cars);
            Assert.Equal(2, cars.Count);
        }
        [Fact]
        public void GetLocations_ShouldReturnAllLocations()
        {
            var locations = _context.Locations.ToList();

            Assert.NotNull(locations);
            Assert.Single(locations);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
