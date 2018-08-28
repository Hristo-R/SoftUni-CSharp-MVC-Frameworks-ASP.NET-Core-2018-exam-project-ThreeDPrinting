namespace ThreeDPrinting.Tests.Services.ThreeDFilaments
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services.Implementations;
    using ThreeDPrinting.Tests.Mocks;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class All3DFilamentsTests
    {
        private ThreeDPrintingDbContext dbContext;

        [TestMethod]
        public void All3DFilaments_WithAFewFilaments_ShouldReturnAll()
        {
            // Arrange 
            this.dbContext.ThreeDFilaments.Add(new ThreeDFilament() { Id = 1, Color = "Red" });
            this.dbContext.ThreeDFilaments.Add(new ThreeDFilament() { Id = 2, Color = "Blue" });
            this.dbContext.ThreeDFilaments.Add(new ThreeDFilament() { Id = 3, Color = "Green" });

            this.dbContext.SaveChanges();

            var service = new ThreeDFilamentService(this.dbContext);

            /// Act 
            var filaments = service.All3DFilaments();

            // Assert
            Assert.IsNotNull(filaments);
            Assert.AreEqual(3, filaments.Count());
            CollectionAssert.AreNotEqual(new[] { 1, 2, 3 }, filaments.Select(f => f.Id).ToArray());
        }

        [TestMethod]
        public void All3DFilaments_WithNoFilaments_ShouldReturnNone()
        {
            // Arrange 
            this.dbContext.SaveChanges();

            var service = new ThreeDFilamentService(this.dbContext);

            // Act 
            var filaments = service.All3DFilaments();

            // Assert
            Assert.IsNotNull(filaments);
            Assert.AreEqual(0, filaments.Count());
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
        }
    }
}
