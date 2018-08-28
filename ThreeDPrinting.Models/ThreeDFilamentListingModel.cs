namespace ThreeDPrinting.Models
{
    public class ThreeDFilamentListingModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public User Username { get; set; }
    }
}