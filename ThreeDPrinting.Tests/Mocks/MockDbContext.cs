namespace ThreeDPrinting.Tests.Mocks
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using ThreeDPrinting.Web.Data;

    public static class MockDbContext
    {
        public static ThreeDPrintingDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ThreeDPrintingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ThreeDPrintingDbContext(options);
        }
    }
}