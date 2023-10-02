using eticaret_business.Concrete;
using eticaret_v2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.Controllers
{
    public class LController : Controller
    {

        private ProductManager productmanager;
        public LController(ProductManager _productmanager)
        {
            this.productmanager = _productmanager;
        }
        public IActionResult List()
        {
            var p = new ProductViewModel()
            {
                products = productmanager.GetAll()
            };
            return View(p);
        }
    }
}
