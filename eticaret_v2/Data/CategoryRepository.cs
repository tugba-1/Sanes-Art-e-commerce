//using eticaret_entity.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace eticaret_v2.Data
//{
//    public class CategoryRepository
//    {
//        private static List<Category> _categories = null;
//        static CategoryRepository()
//        {
//            _categories = new List<Category>
//                {
//                   new Category {Id=1,Name = "Karedeniz"},
//                   new Category {Id=2,Name = "Karma"}
//                };
//        }
//        public static List<Category> Categories
//        {
//            get
//            {
//                return _categories;
//            }
//        }
//        public static void AddProduct(Category category)
//        {
//            _categories.Add(category);
//        }
//        public static Category GetCategoryById(int id)
//        {
//            return _categories.FirstOrDefault(p => p.Id == id);
//        }
//    }
//}
