namespace ThreeDPrinting.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Web.Models.ViewModels;

    public class ThreeDScannersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IThreeDScannerService threeDScanners;

        public ThreeDScannersController(
            UserManager<User> userManager,
            IThreeDScannerService threeDScanners)
        {
            this.userManager = userManager;
            this.threeDScanners = threeDScanners;
        }

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Add3DScanner() => this.View();

        [Authorize(Roles = "Administrator, Dealer")]
        [HttpPost]
        public IActionResult Add3DScanner(ThreeDScannerViewModel threeDScannerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(threeDScannerModel);
            }

            this.threeDScanners.Create(
                threeDScannerModel.Make,
                threeDScannerModel.Model,
                threeDScannerModel.Price,
                threeDScannerModel.WorkingRange,
                threeDScannerModel.DepthImageSize,
                threeDScannerModel.Description,
                threeDScannerModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction("All3DScanners");
        }

        public IActionResult All3DScanners()
        {
            return View(this.threeDScanners.All3DScanners());
        }

        [Authorize(Roles = "Administrator, Dealer")]
        [Route("ThreeDScanners/Edit3DScanners/{id}")]
        public IActionResult Edit3DScanners(int id)
        {
            var threeDScanner = this.threeDScanners.ById(id);

            if (threeDScanner == null)
            {
                return NotFound();
            }

            return View(new ThreeDScannerViewModel
            {
                Make = threeDScanner.Make,
                Model = threeDScanner.Model,
                Price = threeDScanner.Price,
                WorkingRange = threeDScanner.WorkingRange,
                DepthImageSize = threeDScanner.DepthImageSize,
                Description = threeDScanner.Description,
                ImageUrl = threeDScanner.ImageUrl
            });
        }

        [Authorize(Roles = "Administrator, Dealer")]
        [HttpPost]
        [Route("ThreeDScanners/Edit3DScanners/{id}")]
        public IActionResult Edit3DScanners(int id, ThreeDScannerViewModel threeDScannerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(threeDScannerModel);
            }

            var threeDScannerExists = this.threeDScanners.Exists(id);

            if (!threeDScannerExists)
            {
                return NotFound();
            }

            this.threeDScanners.EditScanners(
                id,
                threeDScannerModel.Make,
                threeDScannerModel.Model,
                threeDScannerModel.Price,
                threeDScannerModel.WorkingRange,
                threeDScannerModel.DepthImageSize,
                threeDScannerModel.Description,
                threeDScannerModel.ImageUrl);

            return RedirectToAction("All3DScanners");
        }

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Delete3DScanners(int id) => View(id);

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Delete3DScanner(int id)
        {
            this.threeDScanners.Delete3DScanners(id);

            return RedirectToAction("All3DScanners");
        }
    }
}