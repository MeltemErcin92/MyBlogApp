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
        public List<Article> GetArticlesByCatId(int CatId)
        {
            return _Context.Articles.Where(_ => _.CategoryId == CatId).ToList();
        }
        public Article ArticleDetail(int id)

        {
            return _Context.Articles.SingleOrDefault(_ => _.ArticleId == id);
        }
        public int DoComment(Comment c)
        {
            c.CreationDate = GetNow;

            _Context.Comments.Add(c);
            return _Context.SaveChanges();
        }
        public List<Article> SearchArticle(string s)
        {

            return _Context.Articles.Where(_ => _.Header.Contains(s)).ToList();
           


        }
    }
}
