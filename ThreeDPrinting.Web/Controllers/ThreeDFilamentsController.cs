namespace ThreeDPrinting.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services;
    using ThreeDPrinting.Web.Models.ViewModels;

    public class ThreeDFilamentsController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IThreeDFilamentService threeDFilaments;

        public ThreeDFilamentsController(
            UserManager<User> userManager,
            IThreeDFilamentService threeDFilaments)
        {
            this.userManager = userManager;
            this.threeDFilaments = threeDFilaments;
        }

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Add3DFilament() => this.View();

        [Authorize(Roles = "Administrator, Dealer")]
        [HttpPost]
        public IActionResult Add3DFilament(ThreeDFilamentViewModel threeDFilamentModel)
        {
            if (!ModelState.IsValid)
            {
                return View(threeDFilamentModel);
            }

            this.threeDFilaments.Create(
                threeDFilamentModel.Make,
                threeDFilamentModel.Color,
                threeDFilamentModel.Price,
                threeDFilamentModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction("All3DFilaments");
        }

        public IActionResult All3DFilaments()
        {
            return View(this.threeDFilaments.All3DFilaments());
        }

        [Authorize(Roles = "Administrator, Dealer")]
        [Route("ThreeDFilaments/Edit3DFilaments/{id}")]
        public IActionResult Edit3DFilaments(int id)
        {
            var threeDFilament = this.threeDFilaments.ById(id);

            if (threeDFilament == null)
            {
                return NotFound();
            }

            return View(new ThreeDFilamentViewModel
            {
                Make = threeDFilament.Make,
                Color = threeDFilament.Color,
                Price = threeDFilament.Price,
                ImageUrl = threeDFilament.ImageUrl
            });
        }

        [Authorize(Roles = "Administrator, Dealer")]
        [HttpPost]
        [Route("ThreeDFilaments/Edit3DFilaments/{id}")]
        public IActionResult Edit3DFilaments(int id, ThreeDFilamentViewModel threeDFilamentModel)
        {
            if (!ModelState.IsValid)
            {
                return View(threeDFilamentModel);
            }

            var threeDFilamentExists = this.threeDFilaments.Exists(id);

            if (!threeDFilamentExists)
            {
                return NotFound();
            }

            this.threeDFilaments.EditFilaments(
                id,
                threeDFilamentModel.Make,
                threeDFilamentModel.Color,
                threeDFilamentModel.Price,
                threeDFilamentModel.ImageUrl);

            return RedirectToAction("All3DFilaments");
        }

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Delete3DFilaments(int id) => View(id);

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Delete3DFilament(int id)
        {
            this.threeDFilaments.Delete3DFilaments(id);

            return RedirectToAction("All3DFilaments");
        }
    }
}