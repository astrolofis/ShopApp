using ShopApp.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ShopApp.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        void DeleteFromCategory(int categoryId, int productId);

        Category GetByIdWithProducts(int id);
    }
}
