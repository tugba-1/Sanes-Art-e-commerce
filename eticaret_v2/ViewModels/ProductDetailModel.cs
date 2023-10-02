//using eticaret_v2.Data;
//using eticaret_v2.Models;
using eticaret_entity.Models;
using eticaret_v2.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.ViewModels
{
    public class ProductDetailModel
    {
        public Product products { get; set; }
        public List<Category> categorys { get; set; }
        public List<Comment> Comment { get; set; }
        public List<eticaret_entity.Models.Users> Users { get; set; }
        public IEnumerable<Comment> Comment3 { get; set; }

        public IEnumerable<Comment> Description { get; set; }

        public string UserName { get; set; }

        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public List<eticaret_entity.Models.Users> UserId { get; set; }
        //public List<ProductComment> ProductComment { get; set; }
        //public class CommentItem
        //{
        //    public int Description { get; set; }
        //}

    }
    public class CommentModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CommentId { get; set; }
        public string Description { get; set; }
 
    }
}
