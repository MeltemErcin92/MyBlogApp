using MyBlog.Data.AppClass;
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
        //Admin panel için
        public ActionResult Categories(CategoryResult cr)
        {
            var data = Service.CategoryManager.GetAllCategories();
            return View(data);
        }
        public PartialViewResult GetArticlesWithCategory(int id)
        {
            var data = Service.ArticleManager.GetArticlesByCatId(id);
            return PartialView("ArticlePartialView", data);
        }
        public ActionResult CategoryInsert(Category c)
        {
            var ind = Service.CategoryManager.InsertCategory(c);
            if (ind == -1)
            {
                TempData["Message"] = "Girdiğiniz kategori adı zaten mevcuttur.";
            }
            else if (ind == 0)
            {
                TempData["Message"] = "Kategori ekleme işlemi başarısız olmuştur.";

            }
            else
            {
                TempData["Message"] = "Kategori ekleme başarılı olmuştur.";
            }
            return RedirectToAction("Categories", "Category");
        }
        public ActionResult CategoryDelete(int id)
        {
            var sonuc = Service.CategoryManager.DeleteCategory(id);
            if (sonuc == 1)
            {
                TempData["Message"] = "Kategori silme işlemi başarılı.";
                
            }
            else
            {
                TempData["Message"] = "Kategori silme işlemi başarısız.";
            }
            return RedirectToAction("Categories","Category");
        }
        public ActionResult CategoryUpdate(Category c)
        {
            var indx = Service.CategoryManager.updateCategory(c);
            if (indx == 1)
            {
                TempData["Message"] = "Kategori güncelleme işlemi başarılı.";
            }else
            {
                TempData["Message"] = "Kategori güncelleme işlemi başarısız.";
            }
            return RedirectToAction("Categories", "Category");
        }
    }
}