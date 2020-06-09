using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MyBlogAppUI.Controllers
{
    public class CommentController : BaseController
    {

        public ViewResult Comments()
        {
            List<Comment> data = Service.CommentManager.AllComment();
            return View("Comments", data);
        }
     
        public ActionResult CommentUpdate(Comment c)
        {
            var result = Service.CommentManager.CommentUpdate(c);
            if (result == 0)
            {
                TempData["Message"] = "Güncelleme başarısız.";
            }

            else
            {
                TempData["Message"] = "Güncelleme başarılı.";
            }
            return RedirectToAction("Comments", "Comment");
        }



    }
}