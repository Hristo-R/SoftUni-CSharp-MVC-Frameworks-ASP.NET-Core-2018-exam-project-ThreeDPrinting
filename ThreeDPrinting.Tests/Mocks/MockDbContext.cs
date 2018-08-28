namespace ThreeDPrinting.Tests.Mocks
{
    using Microsoft.EntityFrameworkCore;
    using System;
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
