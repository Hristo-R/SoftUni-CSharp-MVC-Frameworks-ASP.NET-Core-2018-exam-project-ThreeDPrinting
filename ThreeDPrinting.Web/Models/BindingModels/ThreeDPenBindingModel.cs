namespace ThreeDPrinting.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ThreeDPenBindingModel
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
