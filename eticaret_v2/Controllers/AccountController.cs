using eticaret_business.Concrete;
using eticaret_v2.EmailServices;
using eticaret_v2.Identity;
using eticaret_v2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.Controllers
{
    //[AutoValidateAntiforgeryToken]
    public class AccountController:Controller
    {
        private UserManager<Users> _userManager;
        private SignInManager<Users> _signinmanager;
        private SmtpEmailSender _emailsender;
        private CardManager _cardManager;
        public AccountController(CardManager cardManager, UserManager<Users> userManager, SignInManager<Users> signinmanager, SmtpEmailSender emailSender)
        {
            _userManager = userManager;
            _signinmanager = signinmanager;
            _emailsender = emailSender;
            _cardManager = cardManager;
        }
        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {   //ERROR: Valid özelliği açıldığında, valid olmuyor bu yüzden sayfaya geri dönüyor!!!
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            var users = await _userManager.FindByEmailAsync(model.Email);

            if(users == null)
            {
                ModelState.AddModelError("Email", "Yanlış kullanıcı adı");
                //ModelState.AddModelError("Password", "Yanlış Paralo");
                return View(model);
            }
            if (!await _userManager.IsEmailConfirmedAsync(users))
            {
                ModelState.AddModelError("Email", "Lütfen email hesabınıza gelen link ile üyeliğinizi onaylayınız.");
                return View(model);
            }
            var result = await _signinmanager.PasswordSignInAsync(users, model.Password, true, false);
            if (result.Succeeded)
            {            
                return Redirect(model.ReturnUrl??"~/");               
            }
                //ModelState.AddModelError("UserName", "Yanlış İsim");
                ModelState.AddModelError("Password", "Yanlış Paralo");
            return View(model);
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                UserId = user.Id,
                token = code
            });
            //Console.WriteLine(url);
            //email
            await _emailsender.SendEmailAsync(Email, "Reset Password", $"Parolanızı yenilemek için linke <a href='https://localhost:5001{url}'>tıklayınız.</a>");
            return View();
        }
        public IActionResult ResetPassword(string UserId, string token)
        {
            if(UserId == null || token == null)
            {
                RedirectToAction("Index", "Home");
            }
                var model = new ResetPasswordModel { token = token };
                return View();                        
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.token, model.Password);
            if (result.Succeeded)
            {
                RedirectToAction("Login", "Account");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return Redirect("~/");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new Users
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                _cardManager.InitializeCard(user.Id);
                //generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Account", new { 
                    UserId=user.Id,
                    token=code
                });
                //Console.WriteLine(url);
                //email
                await _emailsender.SendEmailAsync(model.Email, "Hesabınızı onaylayınız.",$"Email hesabınız onaylamak için linke <a href='https://localhost:5001{url}'>tıklayınız.</a>");
                return RedirectToAction("Login", "Account");
            }
            ModelState.AddModelError("Password", "Hatalı giriş");
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string UserId, string token)
        {
            if(UserId==null || token == null)
            {
                CreateMessage("Geçersiz token.", "danger");
                return View();
            }
            var user = await _userManager.FindByIdAsync(UserId);
            if(user == null)
            {
                TempData["message"] = "Böyle bir kullanıcı yok.";
                return View();
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                CreateMessage("Hesabınız onaylandı.", "success");
                //TempData["message"] = "Hesabınız onaylandı.";
                return View();
            }
            CreateMessage("Hesabınız onaylanmadı.", "danger");
            //TempData["message"] = "Hesabınız onaylanmadı.";
            return View();
        }
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
