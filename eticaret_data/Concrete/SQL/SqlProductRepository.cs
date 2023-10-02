using eticaret_data.Abstract;
using eticaret_entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Concrete.SQL
{
    public class SqlProductRepository : SqlGenericRepository<Product,artContext>, IRepository<Product>
    {
 
        //private artContext context
        //{
        //    get { return context as artContext; }
        //}
        public List<Product> GetAll()
        {
            using (var context = new artContext())
            {
                return context.Products.ToList();
            }
        }
        //public List<Product> GetsProductByCategory(string name, int page, int PageSize)
        //{
        //    using (var context = new artContext())
        //    {
        //        var products = context.Products.AsQueryable();
        //        if (!string.IsNullOrEmpty(name))
        //        {
        //            products = products.Include(i => i.ProductCategories)
        //                .ThenInclude(i => i.Category)
        //                .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == name.ToLower()))
        //                ;
        //        }
        //        return products.Skip((page-1)*PageSize).Take(PageSize).ToList();
        //    }
        //}
        public List<Product> GetsProductByCategory(string name)
        {
            using (var context = new artContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    products = products.Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == name.ToLower()))
                        ;
                }
                return products.ToList();
            }
        }
        public Product GetProductDetails(int id)
        {
            using (var context = new artContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }
        //public Product commentid(int cid)
        //{
        //    using (var context = new artContext())
        //    {
        //        //var cmd = @"select Description from Comment where Id = @p1";
        //        //context.Database.ExecuteSqlRaw(cmd, cid);
        //        return context.Products
        //            .Include(i => i.ProductComment)
        //            .ThenInclude(i => i.Comment)
        //            .Where(i => i.Id == cid)
        //            .FirstOrDefault();
        //        //.OrderBy(i => i.ProductComment.CommentId).LastOrDefault();
        //        //.Where(i => i.ProductId == 6 || i.ProductId == 3)
        //        ////.Include(i => i.ProductComment)
        //        ////.ThenInclude(i => i.Product)
        //        //.FirstOrDefault();
        //    }
        //}

        public int GetCountByCategory(string category)
        {
            using (var context = new artContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()))
                        ;
                }
                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new artContext())
            {
                return context.Products.Where(i => i.IsApproved).ToList();
            }
        }

        public List<Product> GetSearchResults(string search)
        {
            using (var context = new artContext())
            {
                var products = context.Products
                    .Where(i => i.Name.ToLower().Contains(search.ToLower()))
                    .AsQueryable();
                return products.ToList();
            }
        }

        public Product GetByIdWithCategory(int id)
        {
            using (var context = new artContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }


        public void update(Product entity, int[] CategoryIds)
        {
            using (var context = new artContext())
            {
                var product = context.Products
                   .Include(i => i.ProductCategories)
                   .FirstOrDefault(i => i.Id == entity.Id);
                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.ImgUrl = entity.ImgUrl;
                    product.OrderId = entity.OrderId;
                    product.CategoryId = entity.CategoryId;
                    product.IsApproved = entity.IsApproved;
                    product.Description = entity.Description;

                    product.ProductCategories = CategoryIds.Select(catid => new ProductCategory()
                    {
                        ProductId = entity.Id,
                        CategoryId = catid
                    }).ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}
