using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        List<Category> GetAll();
        Category GetByIdWithProducts(int categoryid);
    }
}
