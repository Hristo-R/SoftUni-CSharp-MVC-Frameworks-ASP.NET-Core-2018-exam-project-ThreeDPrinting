namespace ThreeDPrinting.Models
{
    public class ThreeDScannerListingModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string WorkingRange { get; set; }

        public string DepthImageSize { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
