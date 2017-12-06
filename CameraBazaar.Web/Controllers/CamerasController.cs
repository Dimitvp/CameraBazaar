namespace CameraBazaar.Web.Controllers
{
    using Data.Models;
    using Services;
    using Models.Cameras;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CamerasController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICameraService cameras;

        public CamerasController(ICameraService cameras, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.cameras = cameras;
        }

        [Authorize]
        public IActionResult Add() => this.View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(CameraFormModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(cameraModel);
            }
            this.cameras.Create(
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMeterings,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var cameraExists = this.cameras.Exists(id, this.userManager.GetUserId(User));

            if (!cameraExists)
            {
                return NotFound();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, CameraFormModel cameraModel)
        {
            var update = this.cameras.Edit(
                id,
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMeterings,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            if (!update == null)
            {
                return NotFound();
            }

            return RedirectToAction("Some action");
        }
    }
}
