

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
         public ActionResult Admin()
        {
            return View();
        }
        public PartialViewResult PopularArticles()
        {
            var data = Service.ArticleManager.GetPopularArticles();
            return PartialView("PopularArticles", data);
        }
       
     public ActionResult ContactWe()
        {
            return View("ContactWe");
        }
        [HttpPost]
        public ActionResult SendMessage(Message msj)
        {
            if(msj.MessageSubject!=null && msj.Email != null)
            {
                Service.GeneralManager.Sendmessage(msj);
               
            }
           

            return RedirectToAction("ContactWe");
        }
        [HttpGet]
        public ActionResult SearchArticle()
        {

          return RedirectToAction("SearchArticle");
        }
        [HttpPost]
        public ActionResult SearchArticle(string s)
        {
            var data = Service.ArticleManager.SearchArticle(s);
            return PartialView("ArticlePartialView", data);
        }

    }
}