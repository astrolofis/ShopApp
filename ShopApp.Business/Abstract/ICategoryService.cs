using ShopApp.Entities;
using System.Collections.Generic;

namespace ShopApp.Business.Abstract
{
    public interface ICategoryService
    {

        List<Category> GetAll();

        void Create(Category entity);

        void Update(Category entity);

        void Delete(Category entity);      
    }
}
