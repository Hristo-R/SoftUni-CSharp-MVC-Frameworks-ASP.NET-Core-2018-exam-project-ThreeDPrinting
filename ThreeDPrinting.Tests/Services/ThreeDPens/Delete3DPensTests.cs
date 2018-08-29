namespace ThreeDPrinting.Tests.Services.ThreeDPens
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services.Implementations;
    using ThreeDPrinting.Tests.Mocks;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class Delete3DPensTests
    {

        private ThreeDPrintingDbContext dbContext;

        [TestMethod]

        public void Delete3DPen_ShouldReturnOK()
        {
            // Arrange
            this.dbContext.ThreeDPens.Add(new ThreeDPen() { Id = 1 });
            this.dbContext.SaveChanges();
            var service = new ThreeDPenService(this.dbContext);

            // Act 
            service.Delete3DPens(1);
            bool isDeleted = IsDeleted();

            // Assert
            Assert.AreEqual(true, isDeleted);
        }

        private bool IsDeleted()
        {
            var pens = this.dbContext.ThreeDPens;
            bool isDeleted = true;
            foreach (var pen in pens)
            {
                if (pen.Id == 1)
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
