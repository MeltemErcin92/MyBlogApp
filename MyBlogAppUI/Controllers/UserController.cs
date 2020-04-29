using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyBlog.Data;
using MyBlog.Data.AppClass;
using MyBlog.Data.Model;


namespace MyBlogAppUI.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Admin","Home");
            }
            return View();
        }
      [HttpPost]
        public ActionResult Login(LoginResult u)

        {
          
            var user = Service.UserManager.CheckUser(u);
            if (user != null)
            {
                //Bunlar browserda tutulur timeout süresince bunlar sayesinde timeout süresinve login kalabiliriz bitince süre
                //bilgiler gider.
                var isPersistant = u.remember == "on" ? true : false;
                var timeout = FormsAuthentication.Timeout.TotalMinutes;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "", DateTime.Now, DateTime.Now.AddMinutes(timeout),
                    isPersistant
                    , user.UserId.ToString(),FormsAuthentication.FormsCookiePath);
                //Oluşturduğumuz saklayacağımız bilgileri şifreledik
                String EncriptTicket = FormsAuthentication.Encrypt(ticket);
                //Cookkie oluşturduk buradada
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, EncriptTicket);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Admin", "Home");
               
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}