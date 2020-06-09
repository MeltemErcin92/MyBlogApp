using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogApp.Data.Model;

namespace MyBlogApp.Data.Manager
{
    public class ArticleManager : BaseManager
    {
        //Bu kısımda Article ile alakalı Database İşlemleri yapılacaktır

        public ArticleManager(BlogDbContext ctx) : base(ctx)
        {

        }

        //var populerArticles = Db.Articles.OrderByDescending(x => x.CreateDate).Take(4).ToList();


        public List<Article> GetPopulerArticles() {

            var data =_Context.Articles.OrderByDescending(a => a.CreateDate).Take(4).ToList();

            //#region 2.Yöntem
            //string sqlQuery = "Select top 4 * from Article order by CreateDate desc";
            //var data = _Context.Database.SqlQuery<Article>(sqlQuery).ToList();
            //#endregion 2.Yöntem

            return data;
        }


        public List<Article> GetArticles()
        {
           return _Context.Articles.OrderByDescending(_=>_.CreateDate).ToList();           
        }

        public List<Article> GetArticlesByCatId(int catId) {

            return _Context.Articles.Where(_ => _.CategoryId == catId).ToList();
        }


        public Article ArticleDetail(int id)
        {
            return _Context.Articles.SingleOrDefault(_ => _.ArticleId == id);
        }


        public int DoComment(Comment c) {
            if (c.ConnectedCommendId == null)
                c.ConnectedCommendId = 0;
            c.CreationDate = GetDateTimeNow;
            _Context.Comments.Add(c);
            return _Context.SaveChanges();
        }

    }
}
