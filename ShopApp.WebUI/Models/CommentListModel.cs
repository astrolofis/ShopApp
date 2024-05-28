using ShopApp.Entities;
using System.Collections.Generic;

namespace ShopApp.WebUI.Models
{
    public class CommentListModel
    {
        public Comment Comment { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
