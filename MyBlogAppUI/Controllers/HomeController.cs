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
            GetAllCategories();
            return View();
        }
        public PartialViewResult PopularArticles()
        {
            GetAllArticlesWithArticles();
            var popularArticles = Db.Articles.OrderByDescending(x => x.CreateDate).Take(4).ToList();
            return PartialView(popularArticles);
        }

        public void GetAllArticles()
        {
          var data= Db.Articles.ToList();
        }
        public void GetAllArticlesWithArticles()
        {
        string sqlQuery = @"
        select * from Article
                ";
           var data= Db.Database.SqlQuery<Article>(sqlQuery).ToList();
            var firstData = Db.Database.SqlQuery<Article>(sqlQuery).FirstOrDefault();
        }
        public void GetArticlesWithArticleId(int id)
        {
    string sqlQuery = @"
Declare @id INT={0}
select * from Article
where ArticleId=@id";
            var data = Db.Database.SqlQuery<Article>(sqlQuery,id).ToList();

        }
       public  List<Category> GetAllCategories()
        {
            var data = Service.CategoryManager.GetAllCategories();
            return data;
        }

    }
}