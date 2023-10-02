using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        //List<T> GetAll();
        //List<T> GetAll();
        //List<T> GetOrders(string UserId);
        //List<T> GetsProductByCategory(string name);
        void create(T entity);
        void update(T entity);
        void delete(T entity);
        //T GetByUserId(string userid);
    }
}
