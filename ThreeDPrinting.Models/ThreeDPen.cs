namespace ThreeDPrinting.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ThreeDPen
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Make { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [MaxLength(6000)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
