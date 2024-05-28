using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
    public interface ICommentDal: IRepository<Comment>
    {
        List<Comment> GetCommentByProductId(int productId);

        List<Comment> GetCommentByUserId(string userId);
    }
}
