namespace ThreeDPrinting.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Web.Areas.Admin.Models.ViewModels;
    using ThreeDPrinting.Web.Data;

    public class UsersController : AdminController
    {
        private readonly ThreeDPrintingDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UsersController(
            ThreeDPrintingDbContext context, 
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            var users = this.context.Users
                .Where(u => u.Id != currentUser.Id)
                .ToList();
            var model = this.mapper.Map<IEnumerable<UserConciseViewModel>>(users);
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            if (id == currentUser.Id)
            {
                return Unauthorized();
            }

            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var roles = await this.userManager.GetRolesAsync(user);
            var model = this.mapper.Map<UserDetailsViewModel>(user);
            model.Roles = roles;
            return View(model);
        }
    }
}