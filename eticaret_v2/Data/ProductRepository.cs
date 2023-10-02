//using eticaret_entity.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace eticaret_v2.Data
//{
//    public static class ProductRepository
//    {
//        private static List<Product> _products =null;

//        static ProductRepository()
//        {
//            _products = new List<Product>
//            {
//                new Product {Id=1, Name = "resim1", ImgUrl = "IMG_2698.jpg", CategoryId=1},
//                new Product {Id=2,Name = "resim1", ImgUrl = "IMG_2729.jpg",CategoryId=1},
//                new Product {Id=3,Name = "resim2", ImgUrl = "IMG_3185.jpg", CategoryId=2}  
//            };
//        }
//        public static List<Product> Products
//        {
//            get
//            {
//                return _products;
//            }
//        }
//        public static void AddProduct(Product product)
//        {
//            _products.Add(product);
//        }
//        public static Product GetProductById(int id)
//        {
//            return _products.FirstOrDefault(p => p.Id == id);
//        }
//        public static void EditProduct(Product product)
//        {
//            foreach(var p in _products)
//            {
//                if(p.Id == product.Id)
//                {
//                    p.Name = product.Name;
//                    p.Price = product.Price;
//                    p.ImgUrl = product.ImgUrl;
//                }
//            }
//        }
//        public static void DeleteProduct(int id)
//        {
//            var product = GetProductById(id);
//            if (product != null)
//            {
//                _products.Remove(product);
//            }
//        }
//    }
//}
