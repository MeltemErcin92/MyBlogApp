using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Data;
using System.Web.Security;

namespace MyBlogAppUI.Controllers
{
    public class BaseController : Controller
    {

        private BlogDbContext _Db;
        public BlogDbContext Db
        {
            get
            {
                if (_Db == null)
                    _Db = new BlogDbContext();
                return _Db;
            }


        }
        private static DataService _Service;
        public static DataService Service
        {
            get
            {
                if (_Service == null)

                    _Service = new DataService();
                return _Service;


            }
        }
        public int UserId { get; set; }
        public string username { get; set; }
        //her istekte bu kısım çalışır amaç cookies teki dataları okumak
        public BaseController()
        {
            Authentication();
        }
        //Cookiyi buradan okuyoruz
        private void Authentication()
        {
            if (System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                    username = ticket.Name;
                    UserId = Convert.ToInt32(ticket.UserData);

                }
            }
        }
    }
}