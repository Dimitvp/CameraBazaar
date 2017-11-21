namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Web.Models.Cameras;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CamerasController : Controller
    {
        [Authorize]
        public IActionResult Add() => this.View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddCamerasViewModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(cameraModel);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
