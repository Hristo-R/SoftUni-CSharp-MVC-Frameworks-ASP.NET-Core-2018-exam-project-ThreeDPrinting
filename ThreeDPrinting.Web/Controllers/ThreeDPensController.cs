namespace ThreeDPrinting.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Services;
    using ThreeDPrinting.Web.Models.ViewModels;

    public class ThreeDPensController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IThreeDPenService threeDPens;

        public ThreeDPensController(
            UserManager<User> userManager,
            IThreeDPenService threeDPens)
        {
            this.userManager = userManager;
            this.threeDPens = threeDPens;
        }

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Add3DPen() => this.View();

        [Authorize(Roles = "Administrator, Dealer")]
        [HttpPost]
        public IActionResult Add3DPen(ThreeDPenViewModel threeDPenModel)
        {
            if (!ModelState.IsValid)
            {
                return View(threeDPenModel);
            }

            this.threeDPens.Create(
                threeDPenModel.Make,
                threeDPenModel.Price,
                threeDPenModel.Description,
                threeDPenModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction("All3DPens");
        }

        public IActionResult All3DPens()
        {
            return View(this.threeDPens.All3DPens());
        }

        [Authorize(Roles = "Administrator, Dealer")]
        [Route("ThreeDPens/Edit3DPen/{id}")]
        public IActionResult Edit3DPen(int id)
        {
            var threeDPen = this.threeDPens.ById(id);

            if (threeDPen == null)
            {
                return NotFound();
            }

            var threeDFilamentExists = this.threeDPens.Exists(id);

            if (!threeDFilamentExists)
            {
                return NotFound();
            }

            return View(new ThreeDPenViewModel
            {
                Make = threeDPen.Make,
                Price = threeDPen.Price,
                Description = threeDPen.Description,
                ImageUrl = threeDPen.ImageUrl
            });
        }

        [Authorize(Roles = "Administrator, Dealer")]
        [HttpPost]
        [Route("ThreeDPens/Edit3DPen/{id}")]
        public IActionResult Edit3DPen(int id, ThreeDPenViewModel threeDPenModel)
        {
            if (!ModelState.IsValid)
            {
                return View(threeDPenModel);
            }

            var threeDPenExists = this.threeDPens.Exists(id);

            if (!threeDPenExists)
            {
                return NotFound();
            }

            this.threeDPens.EditPen(
                id,
                threeDPenModel.Make,
                threeDPenModel.Price,
                threeDPenModel.Description,
                threeDPenModel.ImageUrl);

            return RedirectToAction("All3DPens");
        }

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Delete3DPens(int id) => View(id);

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Delete3DPen(int id)
        {
            this.threeDPens.Delete3DPens(id);

            return RedirectToAction("All3DPens");
        }
    }
}