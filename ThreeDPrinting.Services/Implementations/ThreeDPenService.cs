namespace ThreeDPrinting.Services.Implementations
{

    using System.Collections.Generic;
    using System.Linq;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Web.Data;

    public class ThreeDPenService : IThreeDPenService
    {
        private readonly ThreeDPrintingDbContext db;

        public ThreeDPenService(ThreeDPrintingDbContext db)
        {
            this.db = db;
        }

        public void Create(
            string make,
            decimal price,
            string description,
            string imageUrl,
            string userId)
        {
            var threeDPen = new ThreeDPen
            {
                Make = make,
                Price = price,
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(threeDPen);
            this.db.SaveChanges();
        }

        public IEnumerable<ThreeDPenListingModel> All3DPens()
        {
            return this.db
                .ThreeDPens
                .OrderByDescending(tdp => tdp.Id)
                .Select(tdp => new ThreeDPenListingModel
                {
                    Id = tdp.Id,
                    Make = tdp.Make,
                    Price = tdp.Price,
                    Description = tdp.Description,
                    ImageUrl = tdp.ImageUrl
                })
                .ToList();
        }

        public ThreeDPen ById(int id)
        {
            return this.db
                .ThreeDPens
                .Where(tdp => tdp.Id == id)
                .Select(tdp => new ThreeDPen
                {
                    Id = tdp.Id,
                    Make = tdp.Make,
                    Price = tdp.Price,
                    Description = tdp.Description,
                    ImageUrl = tdp.ImageUrl
                })
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.db.ThreeDPens.Any(tdp => tdp.Id == id);
        }

        public void EditPen(int id, string make, decimal price, string description, string imageUrl)
        {
            var existing3DPen = this.db.ThreeDPens.Find(id);

            if (existing3DPen == null)
            {
                return;
            }

            existing3DPen.Make = make;
            existing3DPen.Price = price;
            existing3DPen.Description = description;
            existing3DPen.ImageUrl = imageUrl;

            this.db.SaveChanges();
        }

        public void Delete3DPens(int id)
        {
            var pen = this.db.ThreeDPens.Find(id);

            if (pen == null)
            {
                return;
            }

            this.db.ThreeDPens.Remove(pen);
            this.db.SaveChanges();
        }
    }
}
