namespace ThreeDPrinting.Tests.Services.ThreeDPrinters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services.Implementations;
    using ThreeDPrinting.Tests.Mocks;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class All3DPrintersTests
    {

        private ThreeDPrintingDbContext dbContext;

        [TestMethod]
        public void All3DPriners_WithAFewPriners_ShouldReturnAll()
        {
            // Arrange 
            this.dbContext.ThreeDPrinters.Add(new ThreeDPrinter() { Id = 1, Make = "Sunruy" });
            this.dbContext.ThreeDPrinters.Add(new ThreeDPrinter() { Id = 2, Make = "Sunruy" });
            this.dbContext.ThreeDPrinters.Add(new ThreeDPrinter() { Id = 3, Make = "Anka" });

            this.dbContext.SaveChanges();

            var service = new ThreeDPrinterService(this.dbContext);

            // Act 
            var printers = service.All3DPrinters();

            // Assert
            Assert.IsNotNull(printers);
            Assert.AreEqual(3, printers.Count());
            CollectionAssert.AreNotEqual(new[] { 1, 2, 3 }, printers.Select(p => p.Id).ToArray());
        }

        [TestMethod]
        public void All3DPrinters_WithNoPrinterss_ShouldReturnNone()
        {
            // Arrange 
            this.dbContext.SaveChanges();

            var service = new ThreeDPrinterService(this.dbContext);

            /// Act 
            var printers = service.All3DPrinters();

            // Assert
            Assert.IsNotNull(printers);
            Assert.AreEqual(0, printers.Count());
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
        }
    }
}
