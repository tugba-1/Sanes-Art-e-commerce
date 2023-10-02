using System.Collections.Generic;
using eticaret_business.Concrete;
//using eticaret_v2.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticaret_v2.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private CategoryManager categoryManager;
        public CategoriesViewComponent(CategoryManager _categoryManager)
        {
            this.categoryManager = _categoryManager;
        }
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"]!= null)
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(categoryManager.GetAll());
        }
    }
}