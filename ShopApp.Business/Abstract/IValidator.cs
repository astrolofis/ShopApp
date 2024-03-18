using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Abstract
{
    public interface IValidator<T>
    {
        string ErrorMesssage {  get; set; }
        
        bool Validate(T entity);

    }
}
