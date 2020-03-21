using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Data;

namespace MyBlogAppUI.Controllers
{
    public class BaseController : Controller
    {

        private BlogDbContext _Db;
        public BlogDbContext Db
        {
            get
            {
                if (_Db == null)
                    _Db = new BlogDbContext();
                return _Db;
            }


        }
        private static DataService _Service;
        public static DataService Service
        {
            get
            {
                if (_Service == null)

                    _Service = new DataService();
                return _Service;


            }
        }

    }
}