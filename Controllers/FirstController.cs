using System;
using System.IO;
using System.Linq;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace App.Controllers {
    public class FirstController : Controller {

        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService){
            _logger = logger;
            _productService = productService;
        }
        public string Index(){
            _logger.LogInformation("Index Action");
            _logger.LogWarning("Thong bao");
            return "Toi la index cua first";
        }

        public void Nothing(){
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("Hi", "xin chao");
        }

        public IActionResult Avatar(){
            //Startup.ContentRootPath
            string filePath = Path.Combine(dotnettest.Startup.ContentRootPath, "Files","ava2.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

           return File(bytes,"image/jpg");
        }

        public IActionResult IphonePrice(){
            return Json(new {productName = "Iphone",
                Price = 1000}
            );
        }

        public IActionResult Privacy(){
            var url = Url.Action("Privacy","Home");
            return LocalRedirect(url);
        }

        public IActionResult Google(){
            var url = "https://google.com";
            _logger.LogInformation("Chuyen huong den "+ url);
            return Redirect(url);
        }

        public IActionResult HelloView(string username){
            if(string.IsNullOrEmpty(username)){
                username = "Khách";
            }
            // return View("/MyView/xinchao1.cshtml",username);
            // return View("xinchao2",username);
            // return View((object)username);
            return View("xinchao3",username);
        }

        public IActionResult Readme(){
            var content = @"
            Hello xin chao cac ban
            Hello xin chao cac ban


            Lai la minh day yang
            con co ma di an dem            

            ";
            return Content(content, "text/plain");
        }
        
        [TempData]
        public string StatusMessage {get;set;}
        public IActionResult ViewProduct(int? id){
            var product = _productService.Where(x => x.Id == id).FirstOrDefault();
            if(product == null){
                // TempData["StatusMessage"] = "dasdsad";
                StatusMessage = "san pham khong co";
                return Redirect(Url.Action("Index","Home"));
            }
            // Model
            // return View(product);

            // ViewData
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;

            // return View("ViewProduct2");

            ViewBag.product = product;
            return View("ViewProduct3");

            //TempData =
            
        }
    }
}