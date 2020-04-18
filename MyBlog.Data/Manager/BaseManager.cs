using MyBlog.Data;
using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Data.Manager
{
    public class BaseManager
    {
        protected BlogDbContext _Context { get; set; }
        public BaseManager(BlogDbContext ctx)
        {
            _Context = ctx ?? new BlogDbContext(DataService.connectionString);
        }
        public DateTime GetNow {
            get
            {
                return DateTime.Now;
            }
        }
    }
}