namespace ThreeDPrinting.Services
{
    using System.Collections.Generic;
    using ThreeDPrinting.Models;

    public interface IThreeDPenService
    {
        void Create(
            string make,
            decimal price,
            string description,
            string imageUrl,
            string userId
        );

        IEnumerable<ThreeDPenListingModel> All3DPens();

        ThreeDPen ById(int id);

        bool Exists(int id);

        void EditPen(int id, string make, decimal price, string description, string imageUrl);

        void Delete3DPens(int id);
    }
}