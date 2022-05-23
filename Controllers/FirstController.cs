using System.IO;
using System.Linq;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;

        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public string Index()
        {
            _logger.LogInformation("Index action");
            _logger.LogError("Fail");
            return "Im index of First";
        }
        /*
        -Lay duong dan cua thu muc hien tai :
            + Dang ky dich vu trong file startup, su dung  property contentRootPath
            +Su dung dich vu vua dang ky, noi no voi 2 tham so sau : contentRootPath + "{folder}" + "{file_name}"
            +Sau do convert file anh ve dang bytes
            + Truyen 2 tham so vao function File(mang bytes, kieu du lieu tra ve)
        */
        public IActionResult GetFile()
        {
            string filePath = Path.Combine(Startup.contentRootPath,"Files","wolf.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }
        /*
        Cac cach truyen du lieu tu Controller qua View :
            - Qua View
            - Qua ViewData["key"] = "value"
            - Qua ViewBag.property = "value"
            - Qua TemData["key"] = "value"
        */
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if(product == null)
            {
                TempData["StatusMessage"] ="Product not found";
                return Redirect(Url.Action("Index", "Home"));
            }
                
            return View(product);
        }

    }

}