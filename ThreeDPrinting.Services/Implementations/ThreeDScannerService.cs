namespace ThreeDPrinting.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Web.Data;

    public class ThreeDScannerService : IThreeDScannerService
    {
        private readonly ThreeDPrintingDbContext db;

        public ThreeDScannerService(ThreeDPrintingDbContext db)
        {
            this.db = db;
        }

        public void Create(
            string make,
            string model,
            decimal price,
            string workingRange,
            string depthImageSize,
            string description,
            string imageUrl,
            string userId)
        {
            var threeDScanner = new ThreeDScanner
            {
                Make = make,
                Model = model,
                Price = price,
                WorkingRange = workingRange,
                DepthImageSize = depthImageSize,
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(threeDScanner);
            this.db.SaveChanges();
        }

        public IEnumerable<ThreeDScannerListingModel> All3DScanners()
        {
            return this.db
                .ThreeDScanners
                .OrderByDescending(tds => tds.Id)
                .Select(tds => new ThreeDScannerListingModel
                {
                    Id = tds.Id,
                    Make = tds.Make,
                    Model = tds.Model,
                    Price = tds.Price,
                    WorkingRange = tds.WorkingRange,
                    DepthImageSize = tds.DepthImageSize,
                    Description = tds.Description,
                    ImageUrl = tds.ImageUrl
                })
                .ToList();
        }

        public ThreeDScanner ById(int id)
        {
            return this.db
                .ThreeDScanners
                .Where(tds => tds.Id == id)
                .Select(tds => new ThreeDScanner
                {
                    Id = tds.Id,
                    Make = tds.Make,
                    Model = tds.Model,
                    Price = tds.Price,
                    WorkingRange = tds.WorkingRange,
                    DepthImageSize = tds.DepthImageSize,
                    Description = tds.Description,
                    ImageUrl = tds.ImageUrl
                })
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.db.ThreeDScanners.Any(tds => tds.Id == id);
        }

        public void EditScanners(int id, string make, string model, decimal price, string workingRange, string depthImageSize, string description, string imageUrl)
        {
            var existing3DScanner = this.db.ThreeDScanners.Find(id);

            if (existing3DScanner == null)
            {
                return;
            }

            existing3DScanner.Make = make;
            existing3DScanner.Model = model;
            existing3DScanner.Price = price;
            existing3DScanner.WorkingRange = workingRange;
            existing3DScanner.DepthImageSize = depthImageSize;
            existing3DScanner.Description = description;
            existing3DScanner.ImageUrl = imageUrl;

            this.db.SaveChanges();
        }

        public void Delete3DScanners(int id)
        {
            var scanner = this.db.ThreeDScanners.Find(id);

            if (scanner == null)
            {
                return;
            }

            this.db.ThreeDScanners.Remove(scanner);
            this.db.SaveChanges();
        }
    }
}
