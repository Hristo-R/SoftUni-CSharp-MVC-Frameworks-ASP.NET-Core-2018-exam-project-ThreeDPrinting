namespace ThreeDPrinting.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Web.Models.ViewModels;

    public class ThreeDPrintersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IThreeDPrinterService threeDPrinters;

        public ThreeDPrintersController(
            UserManager<User> userManager,
            IThreeDPrinterService threeDPrinters)
        {
            this.userManager = userManager;
            this.threeDPrinters = threeDPrinters;
        }

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Add3DPrinter() => this.View();

        [Authorize(Roles = "Administrator, Dealer")]
        [HttpPost]
        public IActionResult Add3DPrinter(ThreeDPrinterViewModel threeDPrinterModel)
        {
            if (!ModelState.IsValid)
            {
                return View(threeDPrinterModel);
            }

            this.threeDPrinters.Create(
                threeDPrinterModel.Make,
                threeDPrinterModel.Model,
                threeDPrinterModel.Price,
                threeDPrinterModel.BuildVolume,
                threeDPrinterModel.Description,
                threeDPrinterModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction("All3DPrinters");
        }

        public IActionResult All3DPrinters()
        {
            return View(this.threeDPrinters.All3DPrinters());
        }

        [Authorize(Roles = "Administrator, Dealer")]
        [Route("ThreeDPrinters/Edit3DPrinters/{id}")]
        public IActionResult Edit3DPrinters(int id)
        {
            var threeDPrinter = this.threeDPrinters.ById(id);

            if (threeDPrinter == null)
            {
                return NotFound();
            }

            return View(new ThreeDPrinterViewModel
            {
                Make = threeDPrinter.Make,
                Model = threeDPrinter.Model,
                Price = threeDPrinter.Price,
                BuildVolume = threeDPrinter.BuildVolume,
                Description = threeDPrinter.Description,
                ImageUrl = threeDPrinter.ImageUrl
            });
        }

        [Authorize(Roles = "Administrator, Dealer")]
        [HttpPost]
        [Route("ThreeDPrinters/Edit3DPrinters/{id}")]
        public IActionResult Edit3DPrinters(int id, ThreeDPrinterViewModel threeDPrinterModel)
        {
            if (!ModelState.IsValid)
            {
                return View(threeDPrinterModel);
            }

            var threeDPrinterExists = this.threeDPrinters.Exists(id);

            if (!threeDPrinterExists)
            {
                return NotFound();
            }

            this.threeDPrinters.EditPrinters(
                id,
                threeDPrinterModel.Make,
                threeDPrinterModel.Model,
                threeDPrinterModel.Price,
                threeDPrinterModel.BuildVolume,
                threeDPrinterModel.Description,
                threeDPrinterModel.ImageUrl);

            return RedirectToAction("All3DPrinters");
        }

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Delete3DPrinters(int id) => View(id);

        [Authorize(Roles = "Administrator, Dealer")]
        public IActionResult Delete3DPrinter(int id)
        {
            this.threeDPrinters.Delete3DPrinters(id);

            return RedirectToAction("All3DPrinters");
        }
    }
}