//using eticaret_v2.Models;
using eticaret_business.Concrete;
using eticaret_data;
using eticaret_data.Concrete.SQL;
using eticaret_entity.Models;
using eticaret_v2.Identity;
using eticaret_v2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using eticaret_v2.ViewModels;
//using eticaret_v2.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using eticaret_data.Concrete.SQL;


namespace eticaret_v2.Controllers
{
    public class eticaretController : Controller
    {

        private ProductManager productmanager;
        private CardManager _cardManager;
        private UserManager<Identity.Users> _userManager;
        private CommentManager commentmanager;
        public eticaretController(ProductManager _productmanager, CardManager cardManager, UserManager<Identity.Users> userManager, CommentManager _commentmanager)
        {
            this._cardManager = cardManager;
            this._userManager = userManager;
            this.productmanager = _productmanager;
            this.commentmanager = _commentmanager;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public class artContext : DbContext
        //{
        //    public DbSet<Product> Products { get; set; }
        //    public DbSet<Category> Categorys { get; set; }
        //    public DbSet<Order> Orders { get; set; }
        //    public static readonly ILoggerFactory MyLoggerFactory
        //         = LoggerFactory.Create(Builder => { Builder.AddConsole(); });
        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=DESKTOP-LMBQ9BU\SQLEXPRESS;Database=eticaret1;user=sa;password=1");
        //    }
        //}
        //public IActionResult Index(string category)
        //{
        //    //using (var db = new artContext())
        //    //{
        //    //var p = new List<Product>()
        //    //{
        //    //    //new Product {Name = "resim1"},
        //    //    //new Product {Name = "resim1"},
        //    //    //new Product {Name = "resim2"} //compenent ile başka klasöre aldı
        //    //};
        //    //p.Name = "resim1";
        //    //ViewBag.Name = "resim1";
        //    //var c = new Category();
        //    //{
        //    //    c.Name = "Karedeniz";
        //    //}
        //    //var pm = new ProductViewModel()
        //    //{
        //    // products = productmanager.GetAll()
        //    ////pm.categorys = CategoryRepository.Categories;
        //    //};

        //    //return View(pm);
        //    //var pm = new ProductViewModel()
        //    //{
        //    //    products = productmanager.GetHomePageProducts()
        //    //    //pm.categorys = CategoryRepository.Categories;
        //    //};

        //    //return View(pm);

        //    var p = new ProductViewModel()
        //    {
        //        products = productmanager.GetsProductByCategory(category)
        //    };
        //    return View(p);


        //    //}
        //}
        public IActionResult _details(int? id)
        {
            //return View(ProductRepository.GetProductById(id));
            //var pm = new ProductViewModel()
            //{
            Product product = productmanager.GetProductDetails((int)id);
            //var comment = commentmanager.commentid((int)id);
            //pm.categorys = CategoryRepository.Categories;
            //};
            //var cc = commentmanager.commentid((int)id);
            //commentmanager.Commentt((int)id);
            var Comment = commentmanager.GetAll();
            var userid = _userManager.Users;
            var Id = commentmanager.GetByIdWithComment();
            //Comment c = commentmanager.GetCommentUser((int)id);
            return View(new ProductDetailModel
            {
                products = product,
                categorys = product.ProductCategories.Select(i => i.Category).ToList(),
                //Comment = product.ProductComment.Select(i => i.Comment).ToList()
                Comment = Comment.Where(i=>i.ProductId==id).ToList(),
                ProductId=product.Id,
                CommentId=Id.CommentId + 1,
                //Users = c.CommentUser
                //userid.Where(i=>i.Id == Comment.Select(i=>i.UserId) .FirstOrDefault()).ToList()
            });
        }
        public IActionResult List(string category)
        {
            //const int page = 1;
            //const int PageSize = 1;
            //var p = new ProductViewModel()
            //{
            //    PageInfo = new PageInfo()
            //    {
            //        TotalItems = productmanager.GetCountByCategory(category),
            //        CurrentPage = page,
            //        ItemsPerPage = PageSize,
            //        CurrentCategory = category
            //    },
            //    products = productmanager.GetsProductByCategory(category, page, PageSize)
            //};
            //return View(p);

            var p = new ProductViewModel()
            {
                products = productmanager.GetsProductByCategory(category)
            };
            return View(p);
        }
        //public IActionResult Iletisim()
        //{
        //    return View();
        //}
        //public IActionResult Yaprak_Bilgi()
        //{
        //    return View();
        //}
        //public IActionResult IadeKosullari()
        //{
        //    return View();
        //}
        //public IActionResult Search(string q)
        //{
        //    var productviewmodel = new ProductViewModel()
        //    {
        //        products = productmanager.GetSearchResults(q)
        //    };
        //    return View(productviewmodel);
        //}
        public IActionResult Comment(int? id)
        {
            var c = commentmanager.GetByIdWithComment();
            var comment = commentmanager.GetAll();
            //var cc = commentmanager.commentid((int)cid);

            //var product = productmanager.GetByIdWithCategory(cid);
            //commentmanager.Commentt(id);
            Product product = productmanager.GetProductDetails((int)id);

            //var card = _cardManager.GetCardByUserId(_userManager.GetUserId(User));
            return View(new ProductDetailModel()
            {
                //Id = card.Id,
                //Id = commentmanager.Commentt(id),
                //CommentId = c.Id,
                ProductId = product.Id,
                CommentId = c.CommentId + 1,

                //ProductId = c.Id,
                ////Comment3 = comment.Where(i => i.ProductId == c3.ProductId).ToList(),
                //Comment = comment.Where(i => i.ProductId == cc.ProductId).ToList()

            });;
            //return View();
        }
        [HttpPost]
        public IActionResult Comment(Comment mycomment)
        {
            //using (var db = new artContext())
            //{
                //db.Comment.Add(mycomment);
                //db.SaveChanges();

                var entity = new Comment()
                {
                    Description = mycomment.Description
                };
                commentmanager.create(mycomment);
                return RedirectToAction("List", "eticaret");
            //}           
        }
        //[Route("Home/Comment/{Id}")]
        //public IActionResult Comment()
        //{
        //    using (var db = new artContext())
        //    {
        //        //SharedLayOutData();
        //        var DetailedPost = db.Comment.FirstOrDefault();
        //        return View(DetailedPost);
        //    }
        //}
        //{
        //    var products = ProductRepository.Products;

        //    if (id != null)
        //    {
        //        products = products.Where(p => p.CategoryId == id).ToList();
        //    }
        //    if (!string.IsNullOrEmpty(q))
        //    {
        //        products = products.Where(i => i.Name.Contains(q) || i.Name.ToLower().Contains(q)).ToList();
        //    }
        //    var productViewModel = new ProductViewModel()
        //    {
        //        products = products
        //    };

        //    return View(productViewModel);
        //}
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    ViewBag.Categories = new SelectList(CategoryRepository.Categories, "Id", "Name");
        //    return View(new Product());
        //}
        //[HttpPost]
        //public IActionResult Create(Product p)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ProductRepository.AddProduct(p);
        //        return RedirectToAction("List");
        //    }
        //    return View(p);
        //}

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    ViewBag.Categories = new SelectList(CategoryRepository.Categories, "Id", "Name");
        //    return View(ProductRepository.GetProductById(id));
        //}
        //[HttpPost]
        //public IActionResult Edit(Product p)
        //{
        //    ProductRepository.EditProduct(p);
        //    return RedirectToAction("List");
        //}
        //[HttpPost]
        //public IActionResult delete(int Id)
        //{
        //    ProductRepository.DeleteProduct(Id);
        //    return RedirectToAction("List");
        //}
        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        ////public IActionResult _details(int id)
        ////{

        ////    return View(ProductRepository.GetProductById(id));
        ////}
        ////public IActionResult _category(int? id)
        ////{
        ////    var productss = ProductRepository.Products;
        ////    if (id != null)
        ////    {
        ////        productss = productss.Where(p => p.CategoryId == id).ToList();
        ////    }
        ////    var prodcutviewmodel = new ProductViewModel()
        ////    {
        ////        products = productss
        ////    };
        ////    return View(prodcutviewmodel);
        ////}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        //[HttpGet]
    }
}
