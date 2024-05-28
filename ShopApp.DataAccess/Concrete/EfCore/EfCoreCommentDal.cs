using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreCommentDal : EfCoreGenericRepository<Comment, ShopContext>, ICommentDal
    {
        public List<Comment> GetCommentByProductId(int productId)
        {
            using (var context = new ShopContext())
            {
                return context
                    .Comments
                    .Where(i => i.ProductId == productId)
                    .ToList();          

            }
        }

        public List<Comment> GetCommentByUserId(string userId)
        {
            using (var context = new ShopContext())
            {
                return context
                    .Comments
                    .Where(i => i.UserId == userId)
                    .ToList();
            }
        }
    }
}
