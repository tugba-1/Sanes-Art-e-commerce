using eticaret_data.Abstract;
using eticaret_data.Concrete.SQL;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_business.Concrete
{
    public class ProductManager : IProductService
    {
        SqlProductRepository productRepository = new SqlProductRepository();

        public bool create(Product entity)
        {
            //iş kuralları
            if (Validation(entity))
            {
                productRepository.create(entity);                
                return true;
            }
            return false;
        }

        public void delete(Product entity)
        {
            productRepository.delete(entity);
        }

        public List<Product> GetAll()
        {
 
                return productRepository.GetAll();
            
        }

        //public Product GetById(int id)
        //{
        //    return productRepository.GetById(id);
        //}

        public Product GetProductDetails(int id)
        {
            return productRepository.GetProductDetails(id);
        }

        //public List<Product> GetsProductByCategory(string name, int page, int PageSize)
        //{
        //    return productRepository.GetsProductByCategory(name,page,PageSize);
        //}
        public List<Product> GetsProductByCategory(string name)
        {
            return productRepository.GetsProductByCategory(name);
        }

        public void update(Product entity)
        {
            productRepository.update(entity);
        }

  
        public int GetCountByCategory(string category)
        {
           return productRepository.GetCountByCategory(category);
        }

        public List<Product> GetSearchResults(string search)
        {
            return productRepository.GetSearchResults(search);
        }

        public Product GetByIdWithCategory(int id)
        {
            return productRepository.GetByIdWithCategory(id);
        }

        public bool update(Product entity, int[] CategoryIds)
        {
            if (Validation(entity))
            {
                if (CategoryIds.Length == 0)
                {
                    ErrorMessage += "Ürün için en az bir kategori seçmelisiniz.";
                    return false;
                }
                productRepository.update(entity, CategoryIds);
                return true;
            }
            return false;
        }
        public string ErrorMessage { get; set; }

        public bool Validation(Product entity)
        {
            var IsValid=true;
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "İsim Giriniz \n";
                IsValid = false;
            }
            if (entity.Price<0)
            {
                ErrorMessage += "Fiyat negatif olamaz.\n";
                IsValid = false;
            }
            return IsValid;
        }

        public List<Product> GetHomePageProducts()
        {
            return productRepository.GetHomePageProducts();
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        //public void Dispose()
        //{
        //    _uniofwork.Dispose();
        //}

        //public List<Comment> GetComment(int id)
        //{
        //    return productRepository.GetComment(id);
        //}
    }
}
