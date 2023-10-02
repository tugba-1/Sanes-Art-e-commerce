using eticaret_business.Concrete;
using eticaret_entity.Models;
using eticaret_v2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using eticaret_v2.Identity;

namespace eticaret_v2.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private ProductManager productmanager;
        private CategoryManager categorymanager;
        private RoleManager<IdentityRole> rolemanager;
        private UserManager<Identity.Users> usermanager;

        public AdminController(ProductManager _productmanager, CategoryManager _categorymanager, 
            RoleManager<IdentityRole> _rolemanager, UserManager<Identity.Users> _usermanager)
        {
            this.productmanager = _productmanager;
            this.categorymanager = _categorymanager;
            this.rolemanager = _rolemanager;
            this.usermanager = _usermanager;
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await usermanager.FindByIdAsync(id);
            if(user != null)
            {
                var SelectedRole = await usermanager.GetRolesAsync(user);
                var roles = rolemanager.Roles.Select(i => i.Name);

                ViewBag.Roles = roles;
                return View(new UserDetailsModel()
                {
                    UserId=user.Id,
                    UserName=user.UserName,
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    Email=user.Email,
                    EmailConfirmed=user.EmailConfirmed,
                    SelectedRoles=SelectedRole
                });
            }
            return Redirect("~/admin/user/list");
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailsModel model, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await usermanager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;

                    var result = await usermanager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await usermanager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await usermanager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await usermanager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/user/list");
                    }
                }
                return Redirect("/admin/user/list");
            }

            return View(model);

        }
        public IActionResult UsersList()
        {
            return View(usermanager.Users);
        }
        [HttpGet]
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await rolemanager.FindByIdAsync(id);
            var members = new List<Identity.Users>();
            var nonmembers = new List<Identity.Users>();
            foreach(var user in usermanager.Users)
            {
                //var list = await usermanager.IsInRoleAsync(user, role.Id) 
                //      ?members : nonmembers;
                //list.Add(user);
                if (await usermanager.IsInRoleAsync(user, role.Id))
                {
                    members.Add(user);
                }
                else
                {
                    nonmembers.Add(user);
                }

            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);  
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            foreach (var userId in model.IdstoAdd??new string[]{})
            {
                var user = await usermanager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await usermanager.AddToRoleAsync(user, model.RoleId);
                    //if (!result.Succeeded)
                    //{
                    //    foreach (var error in result.Errors)
                    //    {
                    //        ModelState.AddModelError("", error.Description);
                    //    }
                    //}
                }
            }

            foreach (var userId in model.IdstoDelete??new string[]{})
            {
                var user = await usermanager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await usermanager.RemoveFromRoleAsync(user, model.RoleId);
                    //if (!result.Succeeded)
                    //{
                    //    foreach (var error in result.Errors)
                    //    {
                    //        ModelState.AddModelError("", error.Description);
                    //    }
                    //}
                }
            }
            return Redirect("/admin/role/" + model.RoleId);
        }
        public IActionResult RoleList()
        {
            return View(rolemanager.Roles);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await rolemanager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
            }
            return View(model);
        }
        public IActionResult ProductList()
        {
            return View(new ProductViewModel
            {
                products = productmanager.GetAll()
            });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreate product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    OrderId = product.OrderId,
                    ImgUrl = product.ImgUrl,
                    CategoryId = product.CategoryId
                };
                if (productmanager.create(entity))
                {
                    CreateMessage("Kayıt eklendi.", "success");
                    //TempData["message"] = $"{entity.Name} eklenmiştir.";
                    return RedirectToAction("ProductList");
                }
                CreateMessage(productmanager.ErrorMessage, "danger");
                return View(product);
            }
           return View (product);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var entity = productmanager.GetByIdWithCategory((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new ProductCreate()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                //OrderId = entity.OrderId,
                ImgUrl = entity.ImgUrl,
                CategoryId = entity.CategoryId,
                //IsApproved=entity.IsApproved,
                Description=entity.Description,
                SelectedCategory = entity.ProductCategories.Select(i => i.Category).ToList()
            };
            ViewBag.Categories = categorymanager.GetAll();
            return View(model); 
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductCreate product, int[] CategoryIds, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = productmanager.GetById(product.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = product.Name;
                entity.Price = product.Price;
                //entity.OrderId = product.OrderId;
                entity.ImgUrl = product.ImgUrl;
                //entity.IsApproved = product.IsApproved;
                entity.Description = product.Description;

                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var randomname = string.Format($"{Guid.NewGuid()}{extension}");
                    entity.ImgUrl = randomname;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", randomname);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                //Console.WriteLine(CategoryIds);

                if (productmanager.update(entity, CategoryIds))
                {
                    CreateMessage("Kayıt güncellendi.", "success");
                    return RedirectToAction("ProductList");
                }
                //TempData["message"] = $"{entity.Name} güncellenmiştir.";
                CreateMessage(productmanager.ErrorMessage, "danger");
                //return View(entity);
                //return RedirectToAction("ProductList");
            }
            ViewBag.Categories = categorymanager.GetAll();
            return View(product);
        }
        public IActionResult DeleteProduct(int Id)
        {
            var entity = productmanager.GetById(Id);
            if (entity != null)
            {
                productmanager.delete(entity);
            }
            TempData["message"] = $"{entity.Name} silinmiştir.";
            return RedirectToAction("ProductList");
        }

        public IActionResult CategoryList()
        {
            return View(new ProductDetailModel
            {
                categorys = categorymanager.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryCreate(Category category)
        {
            var entity = new Category()
            {
                Name = category.Name
            };
            categorymanager.create(entity);
            TempData["message"] = $"{entity.Name} eklenmiştir.";
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = categorymanager.GetByIdWithProducts((int)id);
            var model = new CategoryCreate()
            {
                Id = entity.Id,
                Name = entity.Name,
                products = entity.ProductCategories.Select(p => p.Product).ToList()
            };
            return View(model);
        }
        //[HttpPost]
        //public IActionResult CategoryEdit(CategoryCreate model)
        //{
        //    var entity = categorymanager.GetById(model.Id);
        //    if (entity == null)
        //    {
        //        return NotFound();
        //    }
        //    entity.Name = model.Name;

        //    categorymanager.update(entity);
        //    //TempData["message"] = $"{entity.Name} güncellenmiştir.";
        //    return RedirectToAction("CategoryList");
        //}
        //public IActionResult DeleteCategory(int Id)
        //{
        //    var entity = categorymanager.GetById(Id);
        //    if (entity != null)
        //    {
        //        categorymanager.delete(entity);
        //    }
        //    TempData["message"] = $"{entity.Name} silinmiştir.";
        //    return RedirectToAction("CategoryList");
        //}
        private void CreateMessage(string message, string alerttype)
        {
            var msg = new AlertMessage()
            {
                Message = message,
                AlertType = alerttype
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
        }
    }
}
