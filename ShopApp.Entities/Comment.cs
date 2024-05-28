using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDate { get; set; }

        public string CommentBody { get; set; }
        public int Rating { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
