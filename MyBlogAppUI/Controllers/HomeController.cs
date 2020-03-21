
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
        
        // GET: Home
        public ActionResult Index()
        {
            var data = Service.ArticleManager.GetArticles().ToList();

            return View(data);
        }
        public PartialViewResult PopularArticles()
        {
            var data = Service.ArticleManager.GetPopularArticles();
            return PartialView("PopularArticles", data);
        }
       

    }
}