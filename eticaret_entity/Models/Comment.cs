using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_entity.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        //public string Name{ get; set; }
        //public string dateTime { get; set; } = DateTime.Now.ToString();

        //public int ProductId { get; set; }
        //public ProductComment ProductComment { get; set; }
        //public CommentUser CommentUser { get; set; }
    }
}
