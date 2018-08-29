namespace ThreeDPrinting.Tests.Services.ThreeDPrinters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services.Implementations;
    using ThreeDPrinting.Tests.Mocks;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class Delete3DPrintersTests
    {

        private ThreeDPrintingDbContext dbContext;

        [TestMethod]

        public void Delete3DPrinter_ShouldReturnOK()
        {
            // Arrange
            this.dbContext.ThreeDPrinters.Add(new ThreeDPrinter() { Id = 1 });
            this.dbContext.SaveChanges();
            var service = new ThreeDPrinterService(this.dbContext);

            // Act 
            service.Delete3DPrinters(1);
            bool isDeleted = IsDeleted();

            // Assert
            Assert.AreEqual(true, isDeleted);
        }

        private bool IsDeleted()
        {
            var printers = this.dbContext.ThreeDPrinters;
            bool isDeleted = true;
            foreach (var printer in printers)
            {
                if (printer.Id == 1)
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
