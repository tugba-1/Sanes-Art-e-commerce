using eticaret_business.Abstract;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_business.Concrete
{
    interface ICategoryService:IValidator<Category>
    {
        //Category GetById(int id);
        List<Category> GetAll();
        void create(Category entity);
        void update(Category entity);
        void delete(Category entity);
        Category GetByIdWithProducts(int categoryid);
    }
}
