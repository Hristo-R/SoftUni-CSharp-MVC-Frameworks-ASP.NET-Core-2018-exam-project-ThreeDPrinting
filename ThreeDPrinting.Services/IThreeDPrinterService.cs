namespace ThreeDPrinting.Services
{
    using System.Collections.Generic;
    using ThreeDPrinting.Models;

    public interface IThreeDPrinterService
    {
        void Create(
            string make,
            string model,
            decimal price,
            string buildVolume,
            string description,
            string imageUrl,
            string userId
            );

        IEnumerable<ThreeDPrinterListingModel> All3DPrinters();

        ThreeDPrinter ById(int id);

        bool Exists(int id);

        void EditPrinters(int id, string make, string model, decimal price, string buildVolume, string description, string imageUrl);

        void Delete3DPrinters(int id);
    }
}
