﻿using ShopApp.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(100,MinimumLength =10,ErrorMessage ="Ürün ismi minimum 10 karakter maksimum 60 karakter olmalıdır")]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20000, MinimumLength = 10, ErrorMessage = "Ürün açıklaması minimum 10 karakter maksimum 200 karakter olmalıdır")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Fiyat belirtiniz")]
        [Range(1,10000)]
        public decimal? Price { get; set; }

        public List<Category> SelectedCategories { get; set; }
    }
}
