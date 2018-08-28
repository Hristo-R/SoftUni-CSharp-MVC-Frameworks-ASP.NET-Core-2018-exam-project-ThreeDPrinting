namespace ThreeDPrinting.Tests.Services.ThreeDPens
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services.Implementations;
    using ThreeDPrinting.Tests.Mocks;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class All3DPensTests
    {
        private ThreeDPrintingDbContext dbContext;

        [TestMethod]
        public void All3DPens_WithAFewPens_ShouldReturnAll()
        {
            // Arrange 
            this.dbContext.ThreeDPens.Add(new ThreeDPen() { Id = 1 });
            this.dbContext.ThreeDPens.Add(new ThreeDPen() { Id = 2 });
            this.dbContext.ThreeDPens.Add(new ThreeDPen() { Id = 3 });

            this.dbContext.SaveChanges();

            var service = new ThreeDPenService(this.dbContext);

            // Act 
            var pen = service.All3DPens();

            // Assert
            Assert.IsNotNull(pen);
            Assert.AreEqual(3, pen.Count());
            CollectionAssert.AreNotEqual(new[] { 1, 2, 3 }, pen.Select(p => p.Id).ToArray());
        }

        [TestMethod]
        public void All3DPens_WithNoPens_ShouldReturnNone()
        {
            // Arrange 
            this.dbContext.SaveChanges();

            var service = new ThreeDPenService(this.dbContext);

            /// Act 
            var pens = service.All3DPens();

            // Assert
            Assert.IsNotNull(pens);
            Assert.AreEqual(0, pens.Count());
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
        }
    }
}
