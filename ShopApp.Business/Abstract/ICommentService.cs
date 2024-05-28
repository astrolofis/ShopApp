using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Abstract
{
    public interface ICommentService : IValidator<Comment>
    {
        Comment GetById(int id);

        bool Create(Comment entity);

        void Update(Comment entity);

        void Delete(Comment entity);      
        
        List<Comment> GetCommentByProductId(int productId);

        List<Comment> GetCommentByUserId(string userId);
    }
}
