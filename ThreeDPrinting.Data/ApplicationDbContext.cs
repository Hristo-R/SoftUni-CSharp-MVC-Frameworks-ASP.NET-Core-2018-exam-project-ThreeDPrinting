namespace ThreeDPrinting.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ThreeDPrinting.Web.Models;

    public class ThreeDPrintingDbContext : IdentityDbContext<User>
    {
        public ThreeDPrintingDbContext(DbContextOptions<ThreeDPrintingDbContext> options)
            : base(options)
        {
        }
    }
}