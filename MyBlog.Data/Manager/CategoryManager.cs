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
        public int InsertCategory(Category c)
        {
            var cat1 = _Context.Categories.Where(_ => _.CategoryName.ToUpper() == c.CategoryName.ToUpper()).FirstOrDefault();

            if (cat1 != null)
                return -1;
            c.CreateDate = GetNow;
            _Context.Categories.Add(c);
            return _Context.SaveChanges();
        }
        public int DeleteCategory(int id)
        {
            var cat = _Context.Categories.Where(_ => _.CategoryId == id).FirstOrDefault();
            _Context.Categories.Remove(cat);
            return _Context.SaveChanges();
        }
        public int updateCategory(Category c)
        {
            var _cat = _Context.Categories.Where(_ => _.CategoryId == c.CategoryId).FirstOrDefault();
            _cat.CategoryName = c.CategoryName;
            _cat.Explation = c.Explation;
            return _Context.SaveChanges();
        }
    }
}