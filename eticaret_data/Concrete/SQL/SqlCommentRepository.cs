using eticaret_data.Abstract;
using eticaret_entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Concrete.SQL
{
    public class SqlCommentRepository : SqlGenericRepository<Comment, artContext>, ICommentRepository
    {
        //public SqlCommentRepository(artContext context) : base(context)
        //{

        //}
        //private artContext context
        //{
        //    get { return context as artContext; }
        //}

        public List<Comment> GetAll()
        {
            using (var context = new artContext())
            {
                //var cmd = @"select Description from Comment where id=@p1";
                //context.Database.ExecuteSqlRaw(cmd, id);
                return context.Comment.ToList();
            }
        }
        public void Commentt(int productId)
        {
            using (var context = new artContext())
            {
                var cmd = @"  select  Description from Comment where Id = @p1  order by Id Desc  ";
                context.Database.ExecuteSqlRaw(cmd, productId);
            }
        }
        public Comment GetByIdWithComment()
        {
            using (var context = new artContext())
            {
                return context.Comment.OrderBy(i => i.CommentId)
                    //.Where(i => i.Id == id)
                    //.Include(i => i.Id)
                    //.ThenInclude(i => i.Category)
                    .LastOrDefault();
            }
        }
        public Product commentid(int cid)
        {
            using (var context = new artContext())
            {
                //var cmd = @"select Description from Comment where Id = @p1";
                //context.Database.ExecuteSqlRaw(cmd, cid);
                return context.Products
                    //.Include(i => i.ProductComment)
                    //.ThenInclude(i => i.Comment)
                    //.Where(i => i.Id == cid)
                    .FirstOrDefault();
                //.OrderBy(i => i.ProductComment.CommentId).LastOrDefault();
                //.Where(i => i.ProductId == 6 || i.ProductId == 3)
                ////.Include(i => i.ProductComment)
                ////.ThenInclude(i => i.Product)
                //.FirstOrDefault();
            }
        }
        //public Comment GetCommentUser(int id)
        //{
           
        //        return context.Comment
        //            .Where(i => i.ProductId == id)
        //            .Include(i => i.CommentUser)
        //            .ThenInclude(i => i.User)
        //            .FirstOrDefault();
            
        //}
    }
}
