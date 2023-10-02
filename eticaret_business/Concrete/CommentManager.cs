using eticaret_data.Abstract;
using eticaret_data.Concrete.SQL;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_business.Concrete
{

    public class CommentManager : ICommentService
    {
        //private readonly IUnitOfWork _uniofwork;
        //public CommentManager(IUnitOfWork unitofwork)
        //{
        //    _uniofwork = unitofwork;
        //}
        SqlCommentRepository commentRepository = new SqlCommentRepository();
        public void create(Comment entity)
        {
            commentRepository.create(entity);
            //_uniofwork.save();
        }

        public void delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {            
                return commentRepository.GetAll();            
        }
        public void Commentt(int productId)
        {
            commentRepository.Commentt(productId);
            //_uniofwork.save();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Comment GetByUserId(string userid)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetOrders(string UserId)
        {
            throw new NotImplementedException();
        }

        public void update(Comment entity)
        {
            throw new NotImplementedException();
        }

        //public List<Comment> GetAll()
        //{
        //    using (var context = new artContext())
        //    {
        //        return context.Set<Comment>().ToList();
        //    }
        //}
        public Comment GetByIdWithComment()
        {
            return commentRepository.GetByIdWithComment();
        }

        public Product commentid(int cid)
        {
             return commentRepository.commentid(cid);
        }

        public List<Comment> GetsProductByCategory(string name)
        {
            throw new NotImplementedException();
        }

        //public Comment GetCommentUser(int id)
        //{
        //    return _uniofwork.Comments.GetCommentUser(id);
        //}
    }
}
