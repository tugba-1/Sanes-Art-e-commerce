using eticaret_business.Abstract;
using eticaret_data.Abstract;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_business.Concrete
{
    public interface ICommentService:IRepository<Comment>
    {
        List<Comment> GetAll();
        void Commentt(int ProductId);
        Comment GetByIdWithComment();
        Product commentid(int cid);
        //Comment GetCommentUser(int id);
    }
}
