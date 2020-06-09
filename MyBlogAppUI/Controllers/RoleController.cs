using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyBlog.Data;
using MyBlog.Data.AppClass;
using MyBlog.Data.Model;


namespace MyBlogAppUI.Controllers
{
    public class RoleController : BaseController
    {
        public ActionResult Index()
        {
           List<Role> data = Service.RoleManager.getRoles();
            return View(data);
        }
        public ActionResult InsertRole(Role r)
        {
            var result = Service.RoleManager.roleInsert(r);
            if (result == -1)
            {
                TempData["Message"] = "Girdiğiniz rol adı sistemde kayıtlı";
            }
            else if (result == 0)
            {
                TempData["Message"] = "Rol ekleme işlemi başarısız";
            }
            else
            {
                TempData["Message"] = "Rol sisteme eklenmiştir";
            }

            return RedirectToAction("Index", "Role");
        }
        public ActionResult UpdateRole(Role r)
        {
            
            var result = Service.RoleManager.UpdateRole(r);
            if (result == 0)
            {
                TempData["Message"] = "Güncelleme başarısız.";
            }

            else
            {
                TempData["Message"] = "Güncelleme başarılı.";
            }
            return RedirectToAction("Index", "Role");
        }
        public ActionResult RoleDelete(int id)
        {

            var data = Service.RoleManager.RoleDelete(id);
            return RedirectToAction("Index", "Role");
        }
      

    }
}