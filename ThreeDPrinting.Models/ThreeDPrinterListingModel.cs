﻿namespace ThreeDPrinting.Models
{
    public class ThreeDPrinterListingModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string BuildVolume { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}