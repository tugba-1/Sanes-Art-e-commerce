using eticaret_data.Abstract;
using eticaret_entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Concrete.SQL
{
    public class SqlCategoryRepository : SqlGenericRepository<Category,artContext>, ICategoryRepository
    {
        //public SqlCategoryRepository(artContext context) : base(context)
        //{

        //}
        //private artContext context
        //{

        //    get { return context as artContext; }
        //}
        public List<Category> GetAll()
        {
            using (var context = new artContext())
            {
                return context.Categorys.ToList();
            }
        }

        public Category GetByIdWithProducts(int categoryid)
        {
            using (var context = new artContext())
            {
                return context.Categorys
                    .Where(i => i.Id == categoryid)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();
            }
        }
    }
}
