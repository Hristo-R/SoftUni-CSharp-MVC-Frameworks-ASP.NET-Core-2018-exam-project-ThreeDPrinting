namespace ThreeDPrinting.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Web.Data;

    public class ThreeDFilamentService : IThreeDFilamentService
    {
        private readonly ThreeDPrintingDbContext db;

        public ThreeDFilamentService(ThreeDPrintingDbContext db)
        {
            this.db = db;
        }

        public void Create(
            string make,
            string color,
            decimal price,
            string imageUrl,
            string userId)
        {
            var threeDFilament = new ThreeDFilament
            {
                Make = make,
                Color = color,
                Price = price,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(threeDFilament);
            this.db.SaveChanges();
        }

        public IEnumerable<ThreeDFilamentListingModel> All3DFilaments()
        {
            return this.db
                .ThreeDFilaments
                .OrderByDescending(tdf => tdf.Id)
                .Select(tdf => new ThreeDFilamentListingModel
                {
                    Id = tdf.Id,
                    Make = tdf.Make,
                    Color = tdf.Color,
                    Price = tdf.Price,
                    ImageUrl = tdf.ImageUrl
                })
                .ToList();
        }

        public ThreeDFilament ById(int id)
        {
            return this.db
                .ThreeDFilaments
                .Where(tdf => tdf.Id == id)
                .Select(tdf => new ThreeDFilament
                {
                    Id = tdf.Id,
                    Make = tdf.Make,
                    Color = tdf.Color,
                    Price = tdf.Price,
                    ImageUrl = tdf.ImageUrl
                })
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.db.ThreeDFilaments.Any(tdf => tdf.Id == id);
        }

        public void EditFilaments(int id, string make, string color, decimal price, string imageUrl)
        {
            var existing3DFilament = this.db.ThreeDFilaments.Find(id);

            if (existing3DFilament == null)
            {
                return;
            }

            existing3DFilament.Make = make;
            existing3DFilament.Color = color;
            existing3DFilament.Price = price;
            existing3DFilament.ImageUrl = imageUrl;

            this.db.SaveChanges();
        }

        public void Delete3DFilaments(int id)
        {
            var filament = this.db.ThreeDFilaments.Find(id);

            if (filament == null)
            {
                return;
            }

            this.db.ThreeDFilaments.Remove(filament);
            this.db.SaveChanges();
        }
    }
}