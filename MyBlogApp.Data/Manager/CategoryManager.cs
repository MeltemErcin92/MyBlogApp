using MyBlogApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApp.Data.Manager
{
    public class CategoryManager : BaseManager
    {
        public CategoryManager(BlogDbContext ctx = null) : base(ctx)
        {
            
        }

        public List<Category> GetAllCategories()
        {
            return _Context.Categories.OrderBy(_=>_.Name).ToList();
        }


    }


}
