namespace ThreeDPrinting.Services
{
    using System.Collections.Generic;
    using ThreeDPrinting.Models;

    public interface IThreeDFilamentService
    {
        void Create(
            string make,
            string color,
            decimal price,
            string imageUrl,
            string userId
        );

        IEnumerable<ThreeDFilamentListingModel> All3DFilaments();

        ThreeDFilament ById(int id);

        bool Exists(int id);

        void EditFilaments(int id, string make, string color, decimal price, string imageUrl);

        void Delete3DFilaments(int id);
    }
}
