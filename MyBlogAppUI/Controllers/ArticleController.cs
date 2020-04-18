using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyBlogAppUI.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Comment(Comment comment)
        {
            var data = Service.ArticleManager.DoComment(comment);
           
            return RedirectToAction("ArticleDetail", new { id=comment.ArticleId});
          
        }
        public ActionResult ArticleDetail(int ?id)
        {
            var article = Service.ArticleManager.ArticleDetail(id.Value);
            return View(article);

        }
       
    }
}