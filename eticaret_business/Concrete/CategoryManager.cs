using eticaret_data.Abstract;
using eticaret_data.Concrete.SQL;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //private readonly IUnitOfWork _uniofwork;
        //public CategoryManager(IUnitOfWork unitofwork)
        //{
        //    _uniofwork = unitofwork;
        //}
        //public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        SqlCategoryRepository categoryRepository = new SqlCategoryRepository();

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void create(Category entity)
        {
            //iş kuralları
            categoryRepository.create(entity);
            //_uniofwork.save();
        }

        public void delete(Category entity)
        {
            categoryRepository.delete(entity);
            //_uniofwork.save();
        }
        public List<Category> GetAll()
        {
            using (var context = new artContext())
            {
                return context.Set<Category>().ToList();
            }
        }

        //public Category GetById(int id)
        //{
        //    return categoryRepository.GetById(id);
        //}

        public Category GetByIdWithProducts(int categoryid)
        {
            return categoryRepository.GetByIdWithProducts(categoryid); ;
        }

        public void update(Category entity)
        {
            categoryRepository.update(entity);
        }

        public bool Validation(Category entity)
        {
            throw new NotImplementedException();
        }

        //List<Category> ICategoryService.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //Category ICategoryService.GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
