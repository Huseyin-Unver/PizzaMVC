using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using PizzaMVC.Entity;
using PizzaMVC.Identity;
using PizzaMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaMVC.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore =
            new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());

            RoleManager = new RoleManager<ApplicationRole>(roleStore);


        }

        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.UserName == username)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                     OrderNumber = i.OrderNumber,
                      OrderDate = i.OrderDate,
                       OrderState = i.OrderState,
                        Total = i.Total
                }).OrderByDescending(i=>i.OrderDate).ToList() ;
           
          

            return View(orders);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

               IdentityResult result = UserManager.Create(user,model.Password);

                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("useer"))
                    {

                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası");
                }
              
            }


            return View();
        }

       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.UserName, model.Password);

                if (user !=null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;    
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var autProoerties = new AuthenticationProperties();
                    autProoerties.IsPersistent = model.RememberMe;
                    authManager.SignIn(autProoerties, identityclaims);

                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        Redirect(ReturnUrl);

                    }

                    return RedirectToAction("Index", "Home");



                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı Bulunamadı");
                }
            }


            return View();
        }

        public ActionResult LogOut()
        {
            var autManager = HttpContext.GetOwinContext().Authentication;
            autManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}