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
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetAllTags()
        {
          var data= Service.TagManager.GetAllTags();
            return PartialView("TagPartialView", data);

        }
    }
}