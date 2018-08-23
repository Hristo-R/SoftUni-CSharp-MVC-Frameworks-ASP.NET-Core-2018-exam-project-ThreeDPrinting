namespace ThreeDPrinting.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using ThreeDPrinting.Web.Data;

    public class UsersController : AdminController
    {
        private ThreeDPrintingDbContext context;

        public UsersController(ThreeDPrintingDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var users = this.context.Users.ToList();
            return View(users);
        }
    }
}