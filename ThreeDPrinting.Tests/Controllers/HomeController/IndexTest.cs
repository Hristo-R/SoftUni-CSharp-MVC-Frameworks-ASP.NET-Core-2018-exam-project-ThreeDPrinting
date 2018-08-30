namespace ThreeDPrinting.Tests.Controllers.HomeController
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ThreeDPrinting.Web.Controllers;

    [TestClass]
    public class IndexTest
    {
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
    }
}
