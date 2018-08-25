namespace ThreeDPrinting.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Web.Data;

    public class ThreeDPrinterService : IThreeDPrinterService
    {
        private readonly ThreeDPrintingDbContext db;

        public ThreeDPrinterService(ThreeDPrintingDbContext db)
        {
            this.db = db;
        }

        public void Create(
            string make,
            string model,
            decimal price,
            string buildVolume,
            string description,
            string imageUrl,
            string userId)
        {
            var threeDPrinter = new ThreeDPrinter
            {
                Make = make,
                Model = model,
                Price = price,
                BuildVolume = buildVolume,
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(threeDPrinter);
            this.db.SaveChanges();
        }

        public IEnumerable<ThreeDPrinterListingModel> All3DPrinters()
        {
            return this.db
                .ThreeDPrinters
                .OrderByDescending(tdp => tdp.Id)
                .Select(tdp => new ThreeDPrinterListingModel
                {
                    Id = tdp.Id,
                    Make = tdp.Make,
                    Model = tdp.Model,
                    Price = tdp.Price,
                    BuildVolume = tdp.BuildVolume,
                    Description = tdp.Description,
                    ImageUrl = tdp.ImageUrl
                })
                .ToList();
        }

        public ThreeDPrinter ById(int id)
        {
            return this.db
                .ThreeDPrinters
                .Where(tdp => tdp.Id == id)
                .Select(tdp => new ThreeDPrinter
                {
                    Id = tdp.Id,
                    Make = tdp.Make,
                    Model = tdp.Model,
                    Price = tdp.Price,
                    BuildVolume = tdp.BuildVolume,
                    Description = tdp.Description,
                    ImageUrl = tdp.ImageUrl
                })
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.db.ThreeDPrinters.Any(tdp => tdp.Id == id);
        }

        public void EditPrinters(int id, string make, string model, decimal price, string buildVolume, string description, string imageUrl)
        {
            var existing3DPrinter = this.db.ThreeDPrinters.Find(id);

            if (existing3DPrinter == null)
            {
                return;
            }

            existing3DPrinter.Make = make;
            existing3DPrinter.Model = model;
            existing3DPrinter.Price = price;
            existing3DPrinter.BuildVolume = buildVolume;
            existing3DPrinter.Description = description;
            existing3DPrinter.ImageUrl = imageUrl;

            this.db.SaveChanges();
        }

        public void Delete3DPrinters(int id)
        {
            var printer = this.db.ThreeDPrinters.Find(id);

            if (printer == null)
            {
                return;
            }

            this.db.ThreeDPrinters.Remove(printer);
            this.db.SaveChanges();
        }
    }
}
