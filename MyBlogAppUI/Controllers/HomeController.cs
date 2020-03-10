using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogAppUI.Controllers
{
    public class HomeController :BaseController
    {
        BlogDbContext db = new BlogDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PopularArticles()
        {
            var popularArticles = db.Articles.OrderByDescending(x => x.CreateDate).Take(4).ToList();
            return PartialView(popularArticles);
        }
    }
}