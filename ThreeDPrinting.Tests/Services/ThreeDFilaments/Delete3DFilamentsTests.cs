namespace ThreeDPrinting.Tests.Services.ThreeDFilaments
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Net.Mail;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services;
    using ThreeDPrinting.Services.Implementations;
    using ThreeDPrinting.Tests.Mocks;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class Delete3DFilamentsTests
    {
        private ThreeDPrintingDbContext dbContext;

        [TestMethod]

        public void Delete3DFilament_ShouldReturnOK()
        {
            // Arrange
            this.dbContext.ThreeDFilaments.Add(new ThreeDFilament() { Id = 1 });
            this.dbContext.SaveChanges();
            var service = new ThreeDFilamentService(this.dbContext);

            // Act 
            service.Delete3DFilaments(1);
            bool isDeleted = IsDeleted();

            // Assert
            Assert.AreEqual(true, isDeleted);
        }

        private bool IsDeleted()
        {
            var filaments = this.dbContext.ThreeDFilaments;
            bool isDeleted = true;
            foreach (var filament in filaments)
            {
                if (filament.Id == 1)
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
