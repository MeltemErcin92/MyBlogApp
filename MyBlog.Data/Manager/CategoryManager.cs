using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogAppUI.Manager
{
    public class CategoryManager:BaseManager
    {
        public CategoryManager(BlogDbContext ctx=null):base(ctx)
        {

        }
        public List<Category> GetAllCategories()
        {
            return _Context.Categories.ToList();
        }
    }
}