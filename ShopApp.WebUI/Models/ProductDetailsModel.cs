using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.WebUI.Models
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }

        public List<Category> Categories{ get; set; }

        public Comment Comment { get; set; }

        public List<Comment> Comments { get; set; }

        public double AvgRating()
        {
            double average = Math.Round(Comments.Average(c => c.Rating), 1);
            return average ;
        }
    }
}
