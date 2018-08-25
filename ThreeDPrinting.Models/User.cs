namespace ThreeDPrinting.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public List<ThreeDPrinter> ThreeDPrinters { get; set; } = new List<ThreeDPrinter>();

        public List<ThreeDScanner> ThreeDScanners { get; set; } = new List<ThreeDScanner>();

        public List<ThreeDFilament> ThreeDFilaments { get; set; } = new List<ThreeDFilament>();

        public List<ThreeDPen> ThreeDPens { get; set; } = new List<ThreeDPen>();
    }
}