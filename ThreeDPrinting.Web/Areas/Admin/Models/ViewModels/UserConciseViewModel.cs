namespace ThreeDPrinting.Web.Areas.Admin.Models.ViewModels
{
    using System.Collections.Generic;

    public class UserConciseViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }

        public bool IsDealer { get; set; }
    }
}