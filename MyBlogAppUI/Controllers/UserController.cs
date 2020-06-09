using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                StringBuilder sb = new StringBuilder();
                var Name_ = user.username;
                var ıd = user.UserId;
                var parola = user.password;
             
                string[] deneme = new string[3];
                deneme[0] = ıd.ToString() + ":";
                deneme[1] = Name_ + ":";
                deneme[2] = parola.ToString();
                
                foreach (string list in deneme)
                {
                    sb.Append(list);
                }
               


                //Bunlar browserda tutulur timeout süresince bunlar sayesinde timeout süresinve login kalabiliriz bitince süre
                //bilgiler gider.
               
                var isPersistant = u.remember == "on" ? true : false;
                var timeout = FormsAuthentication.Timeout.TotalMinutes;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.username, DateTime.Now, DateTime.Now.AddMinutes(timeout),
                    isPersistant
                    , sb.ToString(),FormsAuthentication.FormsCookiePath);
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
        public ActionResult Users()
        {
             return View(Service.UserManager.getUsers()); 
        }
        public ActionResult UserDelete(int id)
        {
            var data = Service.UserManager.UserDelete(id);
            return RedirectToAction("Users", "User");
        }
        public ActionResult UpdateUser(User u)
        {
            var result = Service.UserManager.UpdateUser(u);
            if (result == 0)
            {
                TempData["Message"] = "Güncelleme başarısız.";
            }

            else
            {
                TempData["Message"] = "Güncelleme başarılı.";
            }
            return RedirectToAction("Users", "User");
        }
        public ActionResult UserEdit(int id)
        {
            User u = Service.UserManager.getUser(id);
            return View(u);
        }
        public ActionResult InsertUser(User u,HttpPostedFileBase imagePath)
        {
            int result = 0;
            if (imagePath != null && imagePath.ContentLength > 0)
            {
                var filename = Path.GetFileName(imagePath.FileName);
               var filePath= Server.MapPath("~/Images/User/");
                var fullPath=Path.Combine(filePath,filename);
               result = Service.UserManager.InsertUser(u, fullPath, imagePath);
            }
        
            if (result == -1)
            {
                TempData["Message"] = "Girdiğiniz Kullanıcı adı sistemde kayıtlı";
            }
            else if (result == 0)
            {
                TempData["Message"] = "Kullanıcı ekleme işlemi başarısız";
            }
            else
            {
                TempData["Message"] = "Kullanıcı sisteme eklenmiştir";
            }

            return RedirectToAction("Users", "User");
        }


    }
}