using MyBlogApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MyBlogApp.Data.Manager;

namespace MyBlogApp.Data
{
    public class DataService
    {
        public int UserId { get; set; }


        private BlogDbContext _Context;

        public static string ConnectionStringName {
            get
             {
                return ConfigurationManager.ConnectionStrings["BlogDbContext"].ConnectionString;
            }
        }

        public static string ConnectionStringNameProduction
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["BlogDbContextProduction"].ConnectionString;
            }
        }


        public DataService()
        {
            //Private olan "_Context" değişkeni Constructor içerisinde oluşturulur
            _Context = new BlogDbContext(ConnectionStringNameProduction);
        }


        private  CategoryManager _CategoryManager;

        public  CategoryManager CategoryManager
        {
            get {
                if (_CategoryManager == null)
                    _CategoryManager = new CategoryManager(_Context);
                return _CategoryManager;
            }
        }


        private ArticleManager _ArticleManager;

        public ArticleManager ArticleManager
        {
            get {
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


        private GeneralManager _GeneralManager;

        public GeneralManager GeneralManager
        {
            get {

                if (_GeneralManager == null)
                    _GeneralManager = new GeneralManager(_Context);
                return _GeneralManager;

            }
        }


        private UserManager _UserManager;

        public UserManager UserManager
        {
            get
            {
                if (_UserManager == null)
                    _UserManager = new UserManager(_Context);
                return _UserManager;

            }
        }

    }
}
