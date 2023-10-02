using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Abstract
{
    public interface ICommentRepository:IRepository<Comment>
    {
        List<Comment> GetAll();
        void Commentt(int productId);
        Comment GetByIdWithComment();
        Product commentid(int cid);
        //Comment GetCommentUser(int id);

    }
}
