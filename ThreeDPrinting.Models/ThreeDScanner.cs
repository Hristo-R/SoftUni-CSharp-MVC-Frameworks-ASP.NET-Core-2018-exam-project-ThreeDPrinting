namespace ThreeDPrinting.Models
{
    using System.ComponentModel.DataAnnotations;
    using ThreeDPrinting.Web.Models;

    public class ThreeDScanner
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string WorkingRange { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepthImageSize { get; set; }

        [Required]
        [MaxLength(6000)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
