using eticaret_business.Abstract;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_business.Concrete
{
    interface IProductService: IValidator<Product>
    {
        Product GetById(int id);
        Product GetByIdWithCategory(int id);
        //List<Comment> GetComment(int id);
        List<Product> GetAll();
        bool create(Product entity);
        void update(Product entity);
        void delete(Product entity);
        Product GetProductDetails(int id);
        //List<Product> GetsProductByCategory(string name, int page,int PageSize);
        List<Product> GetsProductByCategory(string name);
        int GetCountByCategory(string category);
        List<Product> GetSearchResults(string search);
        bool update(Product entity, int[] CategoryIds);
        List<Product> GetHomePageProducts();
    }
}
