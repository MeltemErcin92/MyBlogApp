using MyBlog.Data;
using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogAppUI.Manager
{
    public class BaseManager
    {
        protected BlogDbContext _Context { get; set; }
        public BaseManager(BlogDbContext ctx)
        {
            _Context = ctx ?? new BlogDbContext(DataService.connectionString);
        }
    }
}