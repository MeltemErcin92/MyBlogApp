using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Data.Model;

namespace MyBlog.Data.Manager
{
    public class TagManager : BaseManager
    {
        public TagManager(BlogDbContext ctx) : base(ctx)
        {
        }
        public List<Tag> GetAllTags()
        {
            //string sqlQuery = "select * from Tag";
            //return _Context.Database.SqlQuery<Tag>(sqlQuery).ToList();
            return _Context.Tags.ToList();
        }
        public List<Article> GetArticlesWithTags(int tagId)
        {

//            string sqlQuery = @"
//                                DECLARE @id int

//SELECT * FROM Article a LEFT JOIN dbo.ArticleTag at ON a.ArticleId=at.ArticleId
//WHERE at.TagId=@id
//";

            //var data = _Context.Database.SqlQuery<Article>(sqlQuery, id).ToList();


            //return data;   
            //sql sorgusu iler çağır
            return  _Context.Articles.Where(_ => _.Tags.Any(t => t.TagId == tagId)).ToList();
        }
        public int AddTag(Tag t)
        {
          
            var tag1 = _Context.Tags.Where(_ => _.TagName.ToUpper() == t.TagName.ToUpper()).FirstOrDefault();
           
            if (tag1 !=null)
                return -1;
            t.CreateDate = GetNow;
            _Context.Tags.Add(t);
            return _Context.SaveChanges();
        }
        public int TagDelete(int id)
        {
            var deger = _Context.Tags.Where(_ => _.TagId ==id).FirstOrDefault();
            _Context.Tags.Remove(deger);
            return _Context.SaveChanges();
        }
        public int TagUpdate(Tag t)
        {
            var tag = _Context.Tags.Where(_ => _.TagId == t.TagId).FirstOrDefault();
            tag.TagName = t.TagName;
            return _Context.SaveChanges();
        }
        
    }
}
