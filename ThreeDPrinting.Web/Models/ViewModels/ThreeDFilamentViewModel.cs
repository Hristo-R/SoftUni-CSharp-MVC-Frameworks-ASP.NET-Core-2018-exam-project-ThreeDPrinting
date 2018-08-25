﻿namespace ThreeDPrinting.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ThreeDFilamentViewModel
    {
        [Required]
        [StringLength(100)]
        public string Make { get; set; }

        [Required]
        [StringLength(100)]
        public string Color { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageUrl { get; set; }
    }
}
