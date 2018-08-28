namespace ThreeDPrinting.Tests.Services.ThreeDScanners
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services.Implementations;
    using ThreeDPrinting.Tests.Mocks;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class All3DScannersTests
    {

        private ThreeDPrintingDbContext dbContext;

        [TestMethod]
        public void All3DScanners_WithAFewScanners_ShouldReturnAll()
        {
            // Arrange 
            this.dbContext.ThreeDScanners.Add(new ThreeDScanner() { Id = 1, Make = "Scannect" });
            this.dbContext.ThreeDScanners.Add(new ThreeDScanner() { Id = 2, Make = "Sunruy" });
            this.dbContext.ThreeDScanners.Add(new ThreeDScanner() { Id = 3, Make = "Scannect" });

            this.dbContext.SaveChanges();

            var service = new ThreeDScannerService(this.dbContext);

            /// Act 
            var scanners = service.All3DScanners();

            // Assert
            Assert.IsNotNull(scanners);
            Assert.AreEqual(3, scanners.Count());
            CollectionAssert.AreNotEqual(new[] { 1, 2, 3 }, scanners.Select(s => s.Id).ToArray());
        }

        [TestMethod]
        public void All3DScanners_WithNoScanners_ShouldReturnNone()
        {
            // Arrange 
            this.dbContext.SaveChanges();

            var service = new ThreeDScannerService(this.dbContext);

            /// Act 
            var scanners = service.All3DScanners();

            // Assert
            Assert.IsNotNull(scanners);
            Assert.AreEqual(0, scanners.Count());
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
        }
    }
}