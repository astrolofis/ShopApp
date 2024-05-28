using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entities;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShopApp.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        private UserManager<ApplicationUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            _commentService= commentService;
            _userManager= userManager;
        }

        public IActionResult Index()
        {
            return View(new CommentListModel()
            {
                Comments = _commentService.GetCommentByUserId(_userManager.GetUserId(User))
            }) ;
        }

        public IActionResult AddingComment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddingComment(string comment , int rating, int productId)
        {
            
            if (ModelState.IsValid)
            {
                if (comment == null)
                {
                    comment = "...";
                }
                
                var entity = new Comment()
                {
                    CommentBody = comment,
                    Rating = rating,
                    CommentDate = DateTime.Now,
                    UserId = _userManager.GetUserId(User),
                    UserName = _userManager.GetUserName(User),
                    ProductId = productId
                };
                if (_commentService.Create(entity))
                {
                    return Redirect("/shop/details/" + productId);
                }
                return View();
            }
            
            
            return View();
        }

        [HttpPost]
        public IActionResult DeleteComment(int commentId)
        {
            var entity = _commentService.GetById(commentId);

            if (entity != null)
            {
                _commentService.Delete(entity);
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditComment(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            Comment comment = _commentService.GetById(id);
            
            if (comment == null)
            {
                return NotFound();
            }
            return View(new CommentModel()
            {  
                Id=comment.Id,
                CommentBody= comment.CommentBody,
                Rating= comment.Rating,
                ProductId= comment.ProductId
            });
        }

        [HttpPost]
        public IActionResult EditComment(CommentModel model)
        {
            if (ModelState.IsValid)
            {


                var entity = _commentService.GetById(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.CommentBody = model.CommentBody;
                entity.Rating = (int)model.Rating;
                entity.ProductId= model.ProductId;
                entity.CommentDate = DateTime.Now;
                //entity.UserId = _userManager.GetUserId(User);
                //entity.UserName = _userManager.GetUserName(User);

                

                _commentService.Update(entity);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
