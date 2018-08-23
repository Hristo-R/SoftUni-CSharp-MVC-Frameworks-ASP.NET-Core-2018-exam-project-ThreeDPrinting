namespace ThreeDPrinting.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using ThreeDPrinting.Web.Areas.Admin.Models.ViewModels;
    using ThreeDPrinting.Web.Data;

    public class UsersController : AdminController
    {
        private readonly ThreeDPrintingDbContext context;
        private readonly IMapper mapper;

        public UsersController(ThreeDPrintingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var users = this.mapper.Map<IEnumerable<UserConciseViewModel>>(this.context.Users.ToList());
            return View(users);
        }

        public IActionResult Details(string id)
        {
            var user = this.context.Users.Find(id);
            var model = this.mapper.Map<UserConciseViewModel>(user);
            return View(model);
        }
    }
}