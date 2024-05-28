using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entities;
using ShopApp.WebUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        private ICommentService _commentService;

        public ShopController(IProductService productService, ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
        }

        public IActionResult Details(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            List<Comment> comment = _commentService.GetCommentByProductId((int)id);
            Product product = _productService.GetProductDetails((int)id);
            if(product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product=product,
                Categories=product.ProductCategories.Select(i=> i.Category).ToList(),
                Comments = comment
            });
        }

        public IActionResult List(string category, int page =1)
        {
            const int pageSize = 6;
            return View(new ProductListModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            }) ;
        }
    }
}
