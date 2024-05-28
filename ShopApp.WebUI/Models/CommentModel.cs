using ShopApp.Entities;
using System;

namespace ShopApp.WebUI.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string CommentBody { get; set; }

        public double Rating { get; set; }

        //public DateTime CommentDate { get; set; }

        public int ProductId { get; set; }

        //public Comment Comment { get; set; }
    }
}
