namespace ThreeDPrinting.Web.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using ThreeDPrinting.Models;

    public class User : IdentityUser
    {
        public List<ThreeDPrinter> ThreeDPrinters { get; set; } = new List<ThreeDPrinter>();

        public List<ThreeDScanner> ThreeDScanners { get; set; } = new List<ThreeDScanner>();

        public List<ThreeDFilament> ThreeDFilaments { get; set; } = new List<ThreeDFilament>();
    }
}