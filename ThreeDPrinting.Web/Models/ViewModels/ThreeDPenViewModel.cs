namespace ThreeDPrinting.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ThreeDPenViewModel
    {
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
    }
}
