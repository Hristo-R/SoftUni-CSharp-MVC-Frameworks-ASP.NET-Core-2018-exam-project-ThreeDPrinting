namespace ThreeDPrinting.Tests.Controllers.Admin.HomeController
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Tests.Mocks;
    using ThreeDPrinting.Web.Areas.Admin.Controllers;
    using ThreeDPrinting.Web.Data;

    [TestClass]
    public class IndexTests
    {
        private ThreeDPrintingDbContext dbContext;
        private IMapper mapper;
        private UserManager<User> userManager;

        [TestMethod]
        public void Index_ReturnsTheProperView()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
            this.mapper = MockAutoMapper.GetMapper();
        }
    }
}