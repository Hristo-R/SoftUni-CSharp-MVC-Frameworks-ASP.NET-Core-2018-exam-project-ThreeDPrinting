namespace ThreeDPrinting.Tests.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services.Implementations;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class ThreeDFilamentServiceTests
    {
        [TestMethod]
        public void All3DFilaments_ShouldReturnAll()
        {
            // Arrange 
            var options = new DbContextOptionsBuilder<ThreeDPrintingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var dbContext = new ThreeDPrintingDbContext(options);
            dbContext.ThreeDFilaments.Add(new ThreeDFilament() { Id = 1, Color = "Red" });
            dbContext.ThreeDFilaments.Add(new ThreeDFilament() { Id = 2, Color = "Blue" });
            dbContext.ThreeDFilaments.Add(new ThreeDFilament() { Id = 3, Color = "Green" });

            dbContext.SaveChanges();

            var service = new ThreeDFilamentService(dbContext);

            /// Act 
            var filaments = service.All3DFilaments();

            // Assert
            Assert.IsNotNull(filaments);
            Assert.AreEqual(3, filaments.Count());
            CollectionAssert.AreNotEqual(new[] { 1, 2, 3 }, filaments.Select(f => f.Id).ToArray());
        }
    }
}
