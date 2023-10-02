using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eticaret1_Data.eticaret1_Data.Abstract;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace eticaret1.Controllers
{
    public class HomeController : Controller
    {
        private eticaret1_Data.Abstract.IProductRepository _ProductRepository;
        public HomeController(eticaret1_Data.Abstract.IProductRepository productRepository)
        {
            this._ProductRepository = productRepository;
        }
        public IActionResult Index()
        {
            return  View(_ProductRepository);
            //var p = new Productt();
            //p.Namee = "elbise";
            //p.Pricee = 5;
            //return View(p);      
            //var products = new List<Productt>()
            //{
            //    new Productt {Namee = "Uzun Elbise", Pricee = 5, ImageUrl="D:/eticaret1/eticaret1/wwwroot/img/22136513_puskul-detayli-gomlek-elbise.jpeg"  },
            //    new Productt {Namee = "Bot", Pricee = 8, ImageUrl="D:/eticaret1/eticaret1/wwwroot/img/22125449_siyah-deri-bot-9kkay4016x001.jpeg"  }                
            //};
            //var productViewModel = new ProductViewModel()
            //{
            //    Products = _ProductRepository.GetAll()
            //};
            //return View(productViewModel);
        }
    }
}
//using eticaret1_entity.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
////using eticaret1_entity.Controllers;

//namespace eticaret1.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            var p =new Productt
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}

