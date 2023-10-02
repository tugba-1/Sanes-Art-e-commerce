//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using eticaret1_entity.Models;
//using eticaret1_Data.Abstract;
//using eticaret1.ViewModels;

//namespace eticaret1.Controllers
//{
//    public class CategoryController : Controller
//    {
//        private ICategoryRepository _CategoryRepository;
//        public CategoryController(ICategoryRepository categoryRepository)
//        {
//            this._CategoryRepository = categoryRepository;
//        }
//        public IActionResult Index(int id)
//        {
//            //var p = new Productt();
//            //p.Namee = "elbise";
//            //p.Pricee = 5;
//            //return View(p);      
//            //var products = new List<Productt>()
//            //{
//            //    new Productt {Namee = "Uzun Elbise", Pricee = 5, ImageUrl="D:/eticaret1/eticaret1/wwwroot/img/22136513_puskul-detayli-gomlek-elbise.jpeg"  },
//            //    new Productt {Namee = "Bot", Pricee = 8, ImageUrl="D:/eticaret1/eticaret1/wwwroot/img/22125449_siyah-deri-bot-9kkay4016x001.jpeg"  }                
//            //};
//            var productViewModel = new CategoryViewModel()
//            {
//                Categorys = _CategoryRepository.GetAll()
//            };
//            return View(productViewModel);
//        }
//        //public IActionResult Category() 
//        //{
//        //    var c = new Categoryy();
//        //    c.CategoryDescription = "Elbiseler";
//        //    return View(c);
//        //}
//    }
//}
