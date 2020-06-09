using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogAppUI.Controllers
{
    public class TagController : BaseController
    {
        // GET: Tag
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult GetAllTags()
        {
          var data= Service.TagManager.GetAllTags();
         
            return PartialView("TagPartialView", data);

        }

      
        [Authorize(Roles="Admin")]
        public PartialViewResult GetArticlesWithTags(int id)
        {
            var data = Service.TagManager.GetArticlesWithTags(id);
            return PartialView("ArticlePartialView", data);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Tags()
        {
            var tags = Service.TagManager.GetAllTags();
            return View(tags);
        }
        [HttpPost]
        public ActionResult InsertTag(Tag t)
        {
            var result = Service.TagManager.AddTag(t);
            if (result == -1)
            {
             TempData["Message"]= "Girdiğiniz tag adı zaten mevcuttur.";
            }
            else if(result==0)
            {
                TempData["Message"] = "Tag ekleme işlemi başarısız olmuştur.";

            }
            else
            {
                TempData["Message"]="Tag ekleme başarılı olmuştur.";
            }
            return RedirectToAction("Tags", "Tag");
        }
        public ActionResult TagDelete(int id)
        {
            var result = Service.TagManager.TagDelete(id);
            if (result == 0)
            {
                TempData["Message"] = "Tag silme işlemi başarısız olmuştur.";
            }
            else
            {
                TempData["Message"] = "Tag silme işlemi başarılı olmuştur.";
            }
            return RedirectToAction("Tags", "Tag");
        }
        public ActionResult UpdateTag(Tag t)
        {
            var result = Service.TagManager.TagUpdate(t);
            if (result == 0)
            {
                TempData["Message"] = "Güncelleme başarısız.";
            }
           
            else
            {
                TempData["Message"] = "Güncelleme başarılı.";
            }
            return RedirectToAction("Tags", "Tag");
        }
    }
}