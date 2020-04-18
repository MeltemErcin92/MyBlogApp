using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogAppUI.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index(int id)
        {
            
            return View(id);
        }
        public PartialViewResult getCategories()
        {
            var data = Service.CategoryManager.GetAllCategories().ToList();
            return PartialView("CategoryPartialView",data);
        }
        public PartialViewResult GetArticlesWithCategory(int id)
        {
            var data = Service.ArticleManager.GetArticlesByCatId(id);
            return PartialView("ArticlePartialView", data);
        }
    }
}