using MyBlog.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Data.Manager
{
    public class CategoryManager:BaseManager
    {
        public CategoryManager(BlogDbContext ctx):base(ctx)
        {

        }
        public List<Category> GetAllCategories()
        {
            return _Context.Categories.OrderBy(_ => _.CategoryName).ToList();
        }
    }
}