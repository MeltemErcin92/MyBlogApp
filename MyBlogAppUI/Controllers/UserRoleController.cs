using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogAppUI.Controllers
{
    public class UserRoleController :BaseController
    {
        // GET: UserRole
        public ActionResult Index()
        {
          //  var list = Service.UserRoleManager.GetUsersRoles();
            return View();
        }
        public ActionResult insertUserRole(int UserId,int RoleId)
        {
            var data = Service.UserRoleManager.insertUserRole(UserId, RoleId);
            if (data == 0)
            {
                TempData["Message"] = "Role ekleme işlemi başarısız";
            }
            else
            {
                TempData["Message"] = "Role sisteme eklenmiştir";
            }

            return RedirectToAction("Users", "User");
        }
        
    }
}