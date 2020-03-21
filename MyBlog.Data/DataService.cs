
using MyBlog.Data.Manager;
using MyBlog.Data.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyBlog.Data
{
    public class DataService
    {
        public int userId { get; set; }
        private BlogDbContext _Context;
        public static string connectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["BlogDbContext"].ConnectionString;
            }
        }
        public DataService()
        {
            _Context = new BlogDbContext(connectionString);
        }
        private CategoryManager _CategoryManager;
        public CategoryManager CategoryManager
        {
            get
            {
                if (_CategoryManager == null)
                    _CategoryManager = new CategoryManager(_Context);
                return _CategoryManager;
            }
        }
        private ArticleManager _ArticleManager;

        public ArticleManager ArticleManager
        {
            get
                {
                if (_ArticleManager == null)
                    _ArticleManager = new ArticleManager(_Context);
                return _ArticleManager;
            }
            
        }
        private TagManager _TagManager;

        public TagManager TagManager
        {
            get {
                if (_TagManager == null)
                    _TagManager = new TagManager(_Context);
                return _TagManager;
            }
           
        }




    }
}
