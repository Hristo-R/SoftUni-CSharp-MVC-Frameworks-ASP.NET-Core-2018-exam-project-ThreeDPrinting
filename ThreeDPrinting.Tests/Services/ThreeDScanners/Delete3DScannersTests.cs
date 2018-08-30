namespace ThreeDPrinting.Tests.Services.ThreeDScanners
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services.Implementations;
    using ThreeDPrinting.Tests.Mocks;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class Delete3DScannersTests
    {
        private ThreeDPrintingDbContext dbContext;

        [TestMethod]
        public void Delete3DScanner_ShouldReturnOK()
        {
            // Arrange
            this.dbContext.ThreeDScanners.Add(new ThreeDScanner() { Id = 1 });
            this.dbContext.SaveChanges();
            var service = new ThreeDScannerService(this.dbContext);

            // Act 
            service.Delete3DScanners(1);
            bool isDeleted = this.IsDeleted();

            // Assert
            Assert.AreEqual(true, isDeleted);
        }

        private bool IsDeleted()
        {
            var scanners = this.dbContext.ThreeDScanners;
            bool isDeleted = true;
            foreach (var scanner in scanners)
            {
                if (scanner.Id == 1)
                {
                    isDeleted = false;
                }
            }

            return isDeleted;
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
        }
    }
}