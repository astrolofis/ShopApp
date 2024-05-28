using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal= commentDal;
        }


        public bool Create(Comment entity)
        {
            if (Validate(entity))
            {
                _commentDal.Create(entity);
                return true;
            }
            return false;
            //_commentDal.Create(entity);
        }

        public void Delete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public List<Comment> GetCommentByProductId(int productId)
        {
            return _commentDal.GetCommentByProductId(productId);
        }

        public List<Comment> GetCommentByUserId(string userId)
        {
            return _commentDal.GetCommentByUserId(userId);
        }

        public void Update(Comment entity)
        {
            _commentDal.Update(entity);
        }

        public string ErrorMesssage { get; set; }

        public bool Validate(Comment entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.CommentBody))
            {
                ErrorMesssage += "Ürün ismi giriniz.";
                isValid = false;
            }


            return isValid;
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
        }
    }
}
