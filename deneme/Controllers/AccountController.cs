﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deneme.Identity;
using deneme.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace deneme.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser>UserManager;
        private RoleManager<ApplicationRole> RoleManager;


        public AccountController()
        {
            var userStore=new UserStore<ApplicationUser>(new IdentityVeriBaglam());
            UserManager=new UserManager<ApplicationUser>(userStore);

            var roleStore=new RoleStore<ApplicationRole>(new IdentityVeriBaglam());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);

        }



        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if(ModelState.IsValid)
            { 
                //Kayıt İşlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name=model.Name;
                user.Surname=model.Surname;
                user.Email=model.Email;
                user.UserName=model.UserName;

                IdentityResult result= UserManager.Create(user,model.Password);

                if (result.Succeeded) 
                {
                    //kullanıcı oluştu ve kullanıcıyı bşr role atayabilirsiniz.
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                    
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError","Kullanıcı Oluşturma Hatası");
                }
            }
            return View(model);
        }



        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid) 
            {
                //Login işlemleri
                var user = UserManager.Find(model.UserName,model.Password);

                if(user != null) 
                { 
                    //varolan kullanıcıyı sisteme dahil et
                    //ApplicationCookie oluşturup sisteme bırak.

                    var authManager= HttpContext.GetOwinContext().Authentication;


                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();

                    authProperties.IsPersistent = model.RememberMe;

                    authManager.SignIn(authProperties,identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        Redirect(ReturnUrl);
                    }


                    return RedirectToAction("Index", "Home");


                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }




            return View(model);
        }


        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }

    }
}