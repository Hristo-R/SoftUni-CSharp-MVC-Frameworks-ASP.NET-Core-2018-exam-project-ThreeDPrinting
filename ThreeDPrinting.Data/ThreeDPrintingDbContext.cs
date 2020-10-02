namespace ThreeDPrinting.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ThreeDPrinting.Models;

    public class ThreeDPrintingDbContext : IdentityDbContext<User>
    {
        public ThreeDPrintingDbContext(DbContextOptions<ThreeDPrintingDbContext> options)
            : base(options)
        {
        }

        public DbSet<ThreeDPrinter> ThreeDPrinters 
        {
            get; 
            set;
        }

        public DbSet<ThreeDScanner> ThreeDScanners 
        { 
            get; 
            set; 
        }

        public DbSet<ThreeDFilament> ThreeDFilaments 
        { 
            get;
            set; 
        }

        public DbSet<ThreeDPen> ThreeDPens 
        { 
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder           
.Entity<User>()
                .HasMany(u => u.ThreeDPrinters)
                .WithOne(tdp => tdp.User)
                .HasForeignKey(tdp => tdp.UserId);

            builder 
                .Entity<User>()
                .HasMany(u => u.ThreeDScanners)
                .WithOne(tds => tds.User)
                .HasForeignKey(tds => tds.UserId);

            builder
                .Entity<User>()
                .HasMany(u => u.ThreeDFilaments)
                .WithOne(tdf => tdf.User)
                .HasForeignKey(tdf => tdf.UserId);

            builder
                .Entity<User>()
                .HasMany(u => u.ThreeDPens)
                .WithOne(tdp => tdp.User)
                .HasForeignKey(tdp => tdp.UserId);

            base.OnModelCreating(builder);
        }
    }
}
