using MyBlog.Data.Model;
using MyBlog.Data.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Manager
{
  public class ArticleManager : BaseManager
    {
        public ArticleManager(BlogDbContext ctx) : base(ctx)
        {

        }
        public List<Article> GetPopularArticles()
        {
            var data = _Context.Articles.OrderByDescending(x => x.CreateDate).Take(4).ToList();
            return data;

        }
        public List<Article> GetArticles()
        {
            return _Context.Articles.OrderByDescending(x => x.CreateDate).ToList();
        }

    }
}
