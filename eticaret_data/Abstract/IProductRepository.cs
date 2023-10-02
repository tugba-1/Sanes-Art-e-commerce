using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Abstract
{
    internal interface IProductRepository:IRepository<Product>
    {
        Product GetProductDetails(int id);
        List<Product> GetAll();
        //List<Product> GetsProductByCategory(string name,int page,int PageSize);
        List<Product> GetsProductByCategory(string name);
        int GetCountByCategory(string category);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResults(string search);
        Product GetByIdWithCategory(int id);
        //List<Comment> GetComment(int id);
        void update(Product entity, int[] CategoryIds);

    }
}
