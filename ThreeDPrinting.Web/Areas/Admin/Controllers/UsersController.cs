namespace ThreeDPrinting.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
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
            // var model = this.mapper.Map<IEnumerable<UserConciseViewModel>>(users);

            var model = this.mapper.Map<IEnumerable<UserConciseViewModel>>(users);

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);
                if (roles.Contains("Dealer"))
                {
                    model             .Where(u => u.Id == user.Id)
                    .Select(ucvm => new UserConciseViewModel
                    {
                        Id = ucvm.Id,
                        Email = ucvm.Email,
                        Username = ucvm.Username,
                        IsDealer = true
                    });
                }
            }

            return View(model);
            //return View(model);
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

        [Area("Admin")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> MakeDealer(string id)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await userManager.AddToRoleAsync(user, "Dealer");
            var model = this.mapper.Map<UserDetailsViewModel>(user);

            var currentUser = await this.userManager.GetUserAsync(this.User);
            var currentUserId = currentUser.Id;
            return RedirectToAction("Index");
        }
    }
}