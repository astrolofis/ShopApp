using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            }); 
        }        


        [HttpPost]
        public IActionResult Index(string name)
        {
            if (ModelState.IsValid)
            {
                return View(new ProductListModel()
                {
                    Products = _productService.GetByName(name),
                    ProductName = name
                });
            }
            return View();


        }
    }
}
