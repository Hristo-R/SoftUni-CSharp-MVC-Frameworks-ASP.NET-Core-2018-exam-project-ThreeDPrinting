namespace ThreeDPrinting.Services
{
    using System.Collections.Generic;
    using ThreeDPrinting.Models;

    public interface IThreeDScannerService
    {
        void Create(
            string make,
            string model,
            decimal price,
            string workingRange,
            string depthImageSize,
            string description,
            string imageUrl,
            string userId
        );

        IEnumerable<ThreeDScannerListingModel> All3DScanners();

        ThreeDScanner ById(int id);

        bool Exists(int id);

        void Delete3DScanners(int id);

        void EditScanners(int id, string make, string model, decimal price, string workingRange, string depthImageSize, string description, string imageUrl);
    }
}